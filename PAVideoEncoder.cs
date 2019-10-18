using FFmpeg_Output_Wrapper;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MediaInfoDotNet;

namespace PA_Video_Encoder
{
    public partial class PAVideoEncoder : Form
    {
        readonly String GUIdir = Application.StartupPath;

        readonly String LOG_dir = Application.StartupPath + "\\LOGS";

        readonly String file_settings = Application.StartupPath + "\\settings\\settings.ini";

        readonly String ffmpeg_x86 = Application.StartupPath + "\\ffmpeg\\ffmpeg_fve_x86.exe";
        readonly String ffmpeg_x64 = Application.StartupPath + "\\ffmpeg\\ffmpeg_fve_x64.exe";

        String filtro = "File video supportati|";
        
        String label_tab_lista = "Lista files e impostazioni";

        String azione_fine_coda = "Non fare niente";

        readonly String[] estensioni_video = { ".mkv", ".mp4", ".ts", ".avi", ".mov", ".ogm", ".mpg", ".mpeg", ".m4v", ".webm" };

        String comando = String.Empty, durata = String.Empty, fc = String.Empty;

        Boolean pause = false;

        public static Boolean forza_chiusura = false;

        String file_attuale = "Nessuno", file_finale = String.Empty;

        List<String> formati_scelti = new List<String>();

        Int32 indice_percentuale = 0, exit_code = Int32.MinValue, sec_trasc = 0;

        Thread t;
        ThreadStart ts;

        System.Diagnostics.Process processo_codifica = new System.Diagnostics.Process();
        
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        private static void SuspendProcess(int pid)
        {
            var process = System.Diagnostics.Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (System.Diagnostics.ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
        }

        public static void ResumeProcess(int pid)
        {
            var process = System.Diagnostics.Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (System.Diagnostics.ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);

                CloseHandle(pOpenThread);
            }
        }

        public PAVideoEncoder()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT", false);
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            toolStripComboBox2.Items.Clear();
            toolStripComboBox3.Items.Clear();
            toolStripComboBox4.Items.Clear();

            toolStripMenuItem33.Image = SystemIcons.Information.ToBitmap();

            for (Int32 i = 0; i < compatibilita.Items.Count; i++)
            {
                toolStripComboBox2.Items.Add(compatibilita.Items[i].ToString());
            }
            for (Int32 i = 0; i < qualita.Items.Count; i++)
            {
                toolStripComboBox4.Items.Add(qualita.Items[i].ToString());
            }
            for (Int32 i = 0; i < risoluz.Items.Count; i++)
            {
                toolStripComboBox3.Items.Add(risoluz.Items[i].ToString());
            }
            
            foreach (String s in estensioni_video)
            {
                filtro += "*" + s.ToLower() + ";" + "*" + s.ToUpper() + ";";
            }

            filtro = filtro.Trim(';');
            filtro += "|";

            foreach (String s in estensioni_video)
            {
                filtro += "File " + s.Trim('.').ToUpper() + "|*" + s.ToLower() + ";" + "*" + s.ToUpper() + "|";
            }

            filtro = filtro.Trim('|');
            ferma_tutto();
            toolStripComboBox1.Text = "Non fare niente";

            infoToolStripMenuItem.Image = SystemIcons.Information.ToBitmap();

            if (!Directory.Exists(LOG_dir))
                Directory.CreateDirectory(LOG_dir);

            if (!Directory.Exists(Path.GetDirectoryName(file_settings)))
                Directory.CreateDirectory(Path.GetDirectoryName(file_settings));

            LeggiImpostazioni(file_settings);

            b_avvia.Enabled = false;
            this.Activate();

            if (Environment.GetCommandLineArgs().Count() > 1)
            {
                List<String> d = new List<String>();
                for (Int32 i = 1; i < Environment.GetCommandLineArgs().Count(); i++)
                    d.Add(Environment.GetCommandLineArgs()[i]);
                recupera_fd(d.ToArray());
            }
        }

        public void LeggiImpostazioni_WindowsState(String Value)
        {
            switch (Value)
            {
                case "Maximized":
                    this.WindowState = FormWindowState.Maximized;
                    break;
                default:
                    this.WindowState = FormWindowState.Normal;
                    break;
                case "Minimized":
                    this.WindowState = FormWindowState.Minimized;
                    break;
            }
        }

        public void LeggiImpostazioni_Compatibilita(String Value)
        {
            if (toolStripComboBox2.Items.Contains(Value))
                toolStripComboBox2.Text = Value;
            else
                toolStripComboBox2.Text = "Bluray AAC";
        }

        public void LeggiImpostazioni_Risoluzione(String Value)
        {
            if (toolStripComboBox3.Items.Contains(Value))
                toolStripComboBox3.Text = Value;
            else
                toolStripComboBox3.Text = "720p";
        }

        public void LeggiImpostazioni_Qualita(String Value)
        {
            if (toolStripComboBox4.Items.Contains(Value))
                toolStripComboBox4.Text = Value;
            else
                toolStripComboBox4.Text = "Media";
        }

        public void LeggiImpostazioni(String FileINI)
        {
            if (System.IO.File.Exists(file_settings))
            {
                IniFile ini = new IniFile(file_settings);

                if (ini.KeyExists("WindowState"))
                {
                    LeggiImpostazioni_WindowsState(ini.Read("WindowState"));
                }

                if (ini.KeyExists("comp"))
                {
                    LeggiImpostazioni_Compatibilita(ini.Read("comp"));
                }
                else
                    toolStripComboBox2.Text = "Bluray AAC";

                if (ini.KeyExists("qual"))
                {
                    LeggiImpostazioni_Qualita(ini.Read("qual"));
                }
                else
                    toolStripComboBox4.Text = "Media";

                if (ini.KeyExists("risoluz"))
                {
                    LeggiImpostazioni_Risoluzione(ini.Read("risoluz"));
                }
                else
                    toolStripComboBox3.Text = "720p";
            }
            else
            {
                toolStripComboBox2.Text = "Bluray AAC";
                toolStripComboBox3.Text = "720p";
                toolStripComboBox4.Text = "Media";
            }
        }

        private void DGV_video_DragEnter(object sender, DragEventArgs e)
        {
            String[] dati = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (String s in dati)
            {
                if (Path.HasExtension(s) == true)
                {
                    if (estensioni_video.Contains(Path.GetExtension(s).ToLower()) == true)
                    {
                        e.Effect = DragDropEffects.Copy;
                        break;
                    }
                }
                else
                {
                    foreach (String t in Directory.GetFiles(s, "*", SearchOption.AllDirectories))
                    {
                        if (estensioni_video.Contains(Path.GetExtension(t).ToLower()) == true)
                        {
                            e.Effect = DragDropEffects.Copy;
                            break;
                        }
                    }
                }
            }
        }

        private void DGV_video_DragDrop(object sender, DragEventArgs e)
        {
            String[] dati = (String[])e.Data.GetData(DataFormats.FileDrop);
            recupera_fd(dati);
        }

        public void recupera_fd(String[] dati)
        {
            List<String> temp = new List<String>();
            Boolean es_cart = false;
            try
            {
                foreach (String s in dati)
                {
                    if (Path.HasExtension(s) == true)
                    {
                        if (estensioni_video.Contains(Path.GetExtension(s).ToLower()) == true)
                        {
                            DGV_video.Rows.Add(Path.GetFileName(s), toolStripComboBox2.Text, toolStripComboBox3.Text, toolStripComboBox4.Text, "PRONTO", Path.GetDirectoryName(s));
                        }
                    }
                    else
                    {
                        Seleziona_formati sf = new Seleziona_formati(estensioni_video);
                        sf.ShowInTaskbar = false;
                        sf.Icon = this.Icon;
                        sf.TopLevel = true;
                        sf.StartPosition = FormStartPosition.CenterParent;
                        if (es_cart == false)
                        {
                            if (sf.ShowDialog() == DialogResult.OK)
                            {
                                es_cart = true;
                            }
                        }
                        if (es_cart == true)
                        {
                            formati_scelti = PA_Video_Encoder.Seleziona_formati.formati_scelti;
                            foreach (String t in Directory.GetFiles(s, "*", SearchOption.AllDirectories))
                            {
                                if (formati_scelti.Contains(Path.GetExtension(t).ToLower()) == true)
                                {
                                    temp.Add(t);
                                }
                                else
                                {
                                    if (estensioni_video.Contains(Path.GetExtension(t).ToLower()) == true)
                                    {
                                        temp.Add(t);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach(String s in temp)
                {
                    DGV_video.Rows.Add(Path.GetFileName(s), toolStripComboBox2.Text, toolStripComboBox3.Text, toolStripComboBox4.Text, "PRONTO", Path.GetDirectoryName(s));
                }

                if (DGV_video.Rows.Count > 0)
                {
                    b_avvia.Enabled = true;
                    tb_help.Visible = false;
                }

                temp.Clear();
                tab_autohardsubber.Text = label_tab_lista + " (Totale files: " + DGV_video.Rows.Count.ToString() + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void b_avvia_Click(object sender, EventArgs e)
        {
            Boolean presente = false;
            foreach (String s in System.IO.Directory.GetFiles(Path.GetDirectoryName(ffmpeg_x64)))
            {
                if (Path.GetFileName(s).ToLower().Contains(Path.GetFileName(ffmpeg_x64)) || Path.GetFileName(s).ToLower().Contains(Path.GetFileName(ffmpeg_x86)))
                {
                    presente = true;
                }
            }
            if (b_avvia.Text.StartsWith("A") && presente == true)
            {
                DGV_video.ClearSelection();
                indice_percentuale = 0;
                ts = new ThreadStart(encode);
                t = new Thread(ts);
                t.Start();
                timer_tempo.Start();
                b_avvia.Text = "Ferma";
                ripristinaImpostazioniToolStripMenuItem3.Enabled = false;
                ripristinaImpostazioniToolStripMenuItem3.ShortcutKeys = Keys.None;
                b_pause.Visible = true;
                b_pause.Enabled = true;
                b_agg_cart.Visible = false;
                b_agg_files.Visible = false;
                b_incolla.Visible = false;
                b_rimuovi.Visible = false;
                DGV_video.ReadOnly = true;
                b_avvia.BackColor = Color.OrangeRed;
                strumentiToolStripMenuItem.Enabled = false;
                modificaToolStripMenuItem.Enabled = false;
                pb_tot.Value = 0;
                ts_perc.Text = pb_tot.Value.ToString() + "%";
                l_vel.Text = "Velocità: 0";
                l_dim_prev.Text = "Dimensione stimata: 0";
                ts_perc.Text = "0,00%";
                l_dim_att.Text = "Dimensione attuale: 0";
                l_temp_rim.Text = "Tempo rimanente: 0";
                l_temp_trasc.Text = "Posizione video: 0";
                file_attuale = "Nessuno";
            }
            else
            {
                if (presente == true)
                {
                    ferma_tutto();
                    pause = false;
                    b_pause.Text = "Pausa";
                    b_avvia.Text = "Avvia";
                    b_pause.Visible = false;
                    b_agg_cart.Visible = true;
                    b_agg_files.Visible = true;
                    b_incolla.Visible = true;
                    b_rimuovi.Visible = true;
                    b_avvia.BackColor = Color.LawnGreen;
                    ripristinaImpostazioniToolStripMenuItem3.Enabled = true;
                    ripristinaImpostazioniToolStripMenuItem3.ShortcutKeys = (Keys)Shortcut.CtrlR;
                    DGV_video.ReadOnly = false;
                    timer_tempo.Stop();
                    DGV_video.Columns[DGV_video.Columns["input"].Index].ReadOnly = true;
                    DGV_video.Columns[DGV_video.Columns["stato"].Index].ReadOnly = true;
                    DGV_video.Columns[DGV_video.Columns["percorso_orig"].Index].ReadOnly = true;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "FERMATO - " + ts_perc.Text;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.Yellow;
                    strumentiToolStripMenuItem.Enabled = true;
                    modificaToolStripMenuItem.Enabled = true;
                    file_attuale = "Nessuno";
                }
                else
                {
                    MessageBox.Show("Eseguibile di FFmpeg non trovato. Finché mancherà l'eseguibile di FFmpeg, il programma non potrà funzionare.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void encode()
        {
            for (Int32 q = 0; q < DGV_video.Rows.Count; q++)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    rtb_log.Text = String.Empty;
                });
                DataGridViewRow d = DGV_video.Rows[q];
                sec_trasc = 0;
                comando = String.Empty;
                indice_percentuale = d.Index;
                
                this.Invoke((MethodInvoker)delegate ()
                {
                    ts_avanz.Text = "Avanzamento elaborazione - Nessun file in elaborazione";
                });

                String file_video = Path.Combine(d.Cells[DGV_video.Columns["percorso_orig"].Index].Value.ToString(), d.Cells[DGV_video.Columns["input"].Index].Value.ToString());
                String profilo = d.Cells[DGV_video.Columns["compatibilita"].Index].Value.ToString();
                String qualita = d.Cells[DGV_video.Columns["qualita"].Index].Value.ToString();
                String risoluzione_f = d.Cells[DGV_video.Columns["risoluz"].Index].Value.ToString();

                Boolean stop = false;

                comando = String.Empty;

                file_attuale = Path.GetFileName(file_video);

                if (stop == false)
                {
                    switch (profilo)
                    {
                        case "Remux MKV":
                            remux_mkv(file_video, profilo);
                            break;
                        case "Remux MP4":
                            remux_mp4(file_video, profilo, qualita);
                            break;
                        default:
                            switch (d.Cells["risoluz"].Value.ToString())
                            {
                                case "1080p":
                                    Codifica(file_video, qualita, profilo, 1920, 1080);
                                    break;
                                case "900p":
                                    Codifica(file_video, qualita, profilo, 1600, 900);
                                    break;
                                case "720p":
                                    Codifica(file_video, qualita, profilo, 1280, 720);
                                    break;
                                case "576p":
                                    Codifica(file_video, qualita, profilo, 1024, 576);
                                    break;
                                case "480p":
                                    Codifica(file_video, qualita, profilo, 864, 486);
                                    break;
                                case "396p":
                                    Codifica(file_video, qualita, profilo, 704, 396);
                                    break;
                            }
                            break;
                    }

                    Thread.Sleep(100);

                    if (exit_code == 0)
                    {
                        if (rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.CheckState == CheckState.Checked)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                ts_avanz.Text = "Rimuovo il file sorgente";
                            });
                            try
                            {
                                Int32 c = 0, indice_riga = 0;
                                for (Int32 j = 0; j < DGV_video.Rows.Count; j++)
                                {
                                    if (DGV_video.Rows[j].Cells[DGV_video.Columns["input"].Index].Value.ToString() == file_video)
                                    {
                                        indice_riga = DGV_video.Rows[j].Index;
                                        break;
                                    }
                                }
                                for (Int32 k = indice_riga; k < DGV_video.Rows.Count; k++)
                                {
                                    if (DGV_video.Rows[k].Cells[DGV_video.Columns["input"].Index].Value.ToString() == file_video)
                                    {
                                        c++;
                                    }
                                }
                                if (c <= 1)
                                {
                                    System.IO.File.Delete(file_video);
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            Environment.CurrentDirectory = GUIdir;
            Thread.Sleep(500);
            switch (azione_fine_coda)
            {
                case "Chiudi l'applicazione":
                    forza_chiusura = true;
                    this.Close();
                    break;
                case "Stand-by":
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                case "Spegni il PC":
                    System.Diagnostics.Process.Start("shutdown", "/s /t 120");
                    if (MessageBox.Show("Il PC si spegnerà entro due minuti a partire dalle " + DateTime.Now.TimeOfDay.ToString() + ".\nPer annullare, premere OK.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("shutdown", "/a");
                        MessageBox.Show("L'arresto del PC è stato cancellato.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                b_avvia.Text = "Avvia";
                b_pause.Enabled = false;
                b_agg_cart.Enabled = true;
                b_agg_files.Enabled = true;
                b_incolla.Enabled = true;
                b_rimuovi.Enabled = true;
                ripristinaImpostazioniToolStripMenuItem3.Enabled = true;
                ripristinaImpostazioniToolStripMenuItem3.ShortcutKeys = (Keys)Shortcut.CtrlR;
                DGV_video.ReadOnly = false;
                timer_tempo.Stop();
                DGV_video.ContextMenuStrip.Enabled = true;
                DGV_video.Columns[DGV_video.Columns["input"].Index].ReadOnly = true;
                DGV_video.Columns[DGV_video.Columns["stato"].Index].ReadOnly = true;
                DGV_video.Columns[DGV_video.Columns["percorso_orig"].Index].ReadOnly = true;
                strumentiToolStripMenuItem.Enabled = true;
                modificaToolStripMenuItem.Enabled = true;
                file_attuale = "Nessuno";
                ts_avanz.Text = "Avanzamento elaborazione - Nessuna elaborazione";
            });
        }

        public void remux_mp4(String v, String prof, String qual)
        {
            String comando_remux = " -y -i \"" + v + "\"";
            String mp4_finale = Path.GetDirectoryName(v) + "\\" + Path.GetFileNameWithoutExtension(v) + "[" + prof + "].mp4";
            file_finale = mp4_finale;

            MediaFile m = new MediaFile(v);

            Int32 cont_video = 0, cont_audio = 0, cont_sub = 0;
            foreach (MediaInfoDotNet.Models.VideoStream vid in m.Video)
            {
                if (vid.Format.ToLower().Contains("mpeg") || vid.Format.ToLower().Contains("avc") || vid.Format.ToLower().Contains("hevc"))
                {
                    comando_remux += " -map 0:" + (vid.ID - 1).ToString() + " -c:v:" + cont_video.ToString() + " copy";
                    String framerate = (vid.FrameRate / 1000.0).ToString();
                    comando_remux += " -r " + framerate.Replace(",", ".");
                    fc = Math.Round((Double)vid.FrameCount/* / 1000.0*/, 0, MidpointRounding.AwayFromZero).ToString();
                    Double altezza = vid.Height;
                    Double larghezza = vid.Width;
                    String aspect = Math.Round(larghezza / altezza, 3, MidpointRounding.AwayFromZero).ToString();
                    durata = TimeSpan.FromMilliseconds(vid.Duration).ToString(@"hh\:mm\:ss");
                }
                else
                {
                    comando_remux += " -map 0:" + (vid.ID - 1).ToString() + " -c:v:" + cont_video.ToString() + " libx264";
                    String framerate = (vid.FrameRate / 1000.0).ToString().Replace(",", ".");
                    comando_remux += " -r " + framerate;
                    fc = Math.Round((Double)vid.FrameCount/* / 1000.0*/, 0, MidpointRounding.AwayFromZero).ToString();
                    
                    String aspect = Math.Round((Double)vid.Width / (Double)vid.Height, 3, MidpointRounding.AwayFromZero).ToString();
                    durata = TimeSpan.FromMilliseconds(vid.Duration).ToString("HH:mm:ss");
                    
                    switch (qual)
                    {
                        case "Altissima":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.Altissima().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.Altissima().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.Altissima().AQmode.ToString();
                            break;
                        case "Alta":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.Alta().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.Alta().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.Alta().AQmode.ToString();
                            break;
                        case "Medio-alta":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.MedioAlta().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.MedioAlta().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.MedioAlta().AQmode.ToString();
                            break;
                        case "Media":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.Media().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.Media().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.Media().AQmode.ToString();
                            break;
                        case "Medio-bassa":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.MedioBassa().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.MedioBassa().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.MedioBassa().AQmode.ToString();
                            break;
                        case "Bassa":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.Bassa().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.Bassa().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.Bassa().AQmode.ToString();
                            break;
                        case "Bassissima":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.Bassissima().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.Bassissima().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.Bassissima().AQmode.ToString();
                            break;
                        case "Bozza":
                            comando += " -crf " + new ImpostazioniProfiliCodifica.QualitaVideo.Bozza().CRF.ToString() + " -preset:v " + new ImpostazioniProfiliCodifica.QualitaVideo.Bozza().Preset + " -aq-mode " + new ImpostazioniProfiliCodifica.QualitaVideo.Bozza().AQmode.ToString();
                            break;
                    }

                    comando_remux += " -profile:v:" + cont_video.ToString() + " high -level:v:" + cont_video.ToString() + " 4.1";

                    if (vid.miOption("ScanType").StartsWith("P") == false)
                    {
                        comando += " -vf yadif";
                    }
                }
                cont_video++;
            }
            foreach (MediaInfoDotNet.Models.AudioStream aud in m.Audio)
            {
                CatturaAudio ca = new CatturaAudio(aud);

                if (ca.Formato.ToLower().Contains("ac-3") || ca.Formato.ToLower().StartsWith("mpeg") || ca.Formato.ToLower().Contains("aac"))
                {
                    comando_remux += " -map 0:" + ca.Indice.ToString() + " -c:a:" + cont_audio.ToString() + " copy";
                }
                else
                {
                    if (ca.Lossless == true)
                    {
                        comando_remux += " -map 0:" + ca.Indice.ToString() + " -c:a:" + cont_audio.ToString() + " alac -ac:" + cont_audio.ToString() + " " + ca.Canali.ToString();
                    }
                    else
                    {
                        comando_remux += " -map 0:" + ca.Indice.ToString() + " -c:a:" + cont_audio.ToString() + " aac -ac:" + cont_audio.ToString() + " " + ca.Canali.ToString();
                        switch (qual)
                        {
                            case "Altissima":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (192 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                            case "Alta":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (160 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                            case "Medio-alta":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (144 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                            case "Media":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (112 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                            case "Medio-bassa":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (96 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                            case "Bassa":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (64 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                            case "Bassissima":
                                comando_remux += " -b:a:" + cont_audio.ToString() + " " + (48 * (ca.Canali / 2.0)).ToString() + "k";
                                break;
                        }
                    }
                }
                cont_audio++;
            }

            foreach (MediaInfoDotNet.Models.TextStream txt in m.Text)
            {
                if (txt.Format == "Timed Text")
                {
                    comando_remux += " -map 0:" + txt.ID.ToString() + " -c:s:" + cont_sub.ToString() + " copy";
                }
                cont_sub++;
            }

            comando_remux += " \"" + mp4_finale + "\"";

            Environment.CurrentDirectory = Path.GetDirectoryName(ffmpeg_x64);
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            processo_codifica = new System.Diagnostics.Process();
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            if (Environment.Is64BitOperatingSystem == true)
            {
                psi.FileName = Path.GetFileName(ffmpeg_x64);
            }
            else
            {
                psi.FileName = Path.GetFileName(ffmpeg_x86);
            }
            
            psi.Arguments = comando_remux;

            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            processo_codifica.OutputDataReceived += Processo_codifica_OutputDataReceived;
            processo_codifica.ErrorDataReceived += Processo_codifica_ErrorDataReceived;
            processo_codifica.StartInfo = psi;
            processo_codifica.Start();
            processo_codifica.BeginOutputReadLine();
            processo_codifica.BeginErrorReadLine();
            processo_codifica.WaitForExit();
            processo_codifica.CancelOutputRead();
            processo_codifica.CancelErrorRead();
            exit_code = processo_codifica.ExitCode;
            if (exit_code == 0)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    ts_perc.Text = "100.00%";
                    pb_tot.Value = pb_tot.Maximum;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "OK - " + ts_perc.Text;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.LightGreen;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "ERRORE - " + ts_perc.Text;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.Red;
                });
            }

            CreaLOG();

            this.Invoke((MethodInvoker)delegate ()
            {
                ts_avanz.Text = "Avanzamento elaborazione - Nessuna elaborazione";
            });

        }

        public void remux_mkv(String v, String prof)
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(ffmpeg_x86);
            String mkv_finale = Path.GetDirectoryName(v) + "\\" + Path.GetFileNameWithoutExtension(v) + "[" + prof + "].mkv";
            file_finale = mkv_finale;
            String comando = " -i \"" + v + "\" -map 0 -c copy \"" + mkv_finale + "\"";
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.Arguments = comando;
            psi.FileName = Path.GetFileName(ffmpeg_x86);
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            processo_codifica = new System.Diagnostics.Process();
            processo_codifica.StartInfo = psi;
            processo_codifica.ErrorDataReceived += Processo_codifica_ErrorDataReceived;
            processo_codifica.OutputDataReceived += Processo_codifica_OutputDataReceived;
            this.Invoke((MethodInvoker)delegate ()
            {
                ts_avanz.Text = "Avanzamento elaborazione - Remux in corso del file '" + Path.GetFileName(v) + "'";
            });
            processo_codifica.Start();
            processo_codifica.BeginErrorReadLine();
            processo_codifica.BeginOutputReadLine();
            processo_codifica.WaitForExit();
            processo_codifica.CancelErrorRead();
            switch (processo_codifica.ExitCode)
            {
                case 0:
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        ts_perc.Text = "100.00%";
                        pb_tot.Value = pb_tot.Maximum;
                        DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "OK - " + ts_perc.Text;
                        DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.LightGreen;
                    });
                    break;
                default:
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "ERRORE - " + ts_perc.Text;
                        DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.Red;
                    });
                    break;

            }

            CreaLOG();

            this.Invoke((MethodInvoker)delegate ()
            {
                ts_avanz.Text = "Avanzamento elaborazione - Nessuna elaborazione";
            });
        }

        public void CreaLOG()
        {
            if (Directory.Exists(LOG_dir) == false)
            {
                Directory.CreateDirectory(LOG_dir);
            }
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    List<String> LOG_info = rtb_log.Lines.ToList();
                    LOG_info.RemoveAll(String.IsNullOrWhiteSpace);
                    System.IO.File.WriteAllLines(LOG_dir + "\\" + Path.GetFileNameWithoutExtension(file_finale) + " - LOG.txt", LOG_info.ToArray());
                });
            }
            catch { }
        }

        public String ResizeAuto(String AspectR, Int32 LargDest, Double LargOrig, Int32 AltDest, Double AltOrig)
        {
            if (Convert.ToDouble(LargOrig / AltOrig) >= (4.0 / 3.0))
            {
                Int32 LFin = CalcolaLarghezzaFinale(Convert.ToInt32(LargOrig), LargDest, Convert.ToInt32(AltOrig));
                if (LFin > 0)
                {
                    return ",scale=\"" + LFin + ":trunc(ow/a/2)*2\"";
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                Int32 AFin = CalcolaAltezzaFinale(Convert.ToInt32(AltOrig), AltDest, Convert.ToInt32(LargOrig));
                if (AFin > 0)
                {
                    return ",scale=\"trunc(oh*a/2)*2:" + AFin + "\"";
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        public Int32 CalcolaLarghezzaFinale(Int32 LargO, Int32 LargD, Int32 AltO)
        {
            if (LargO < LargD)
            {
                if (LargO % 2 == 0)
                {
                    if (AltO % 2 == 0)
                        return 0;
                    else
                        return LargO;
                }
                else
                {
                    return LargO - 1;
                }
            }
            else
            {
                if (LargO > LargD)
                {
                    return LargD;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Int32 CalcolaAltezzaFinale(Int32 AltO, Int32 AltD, Int32 LargO)
        {
            if (AltO < AltD)
            {
                if (AltO % 2 == 0)
                {
                    if (LargO % 2 == 0)
                        return 0;
                    else
                        return AltO;
                }
                else
                {
                    return AltO - 1;
                }
            }
            else
            {
                if (AltO > AltD)
                {
                    return AltD;
                }
                else
                {
                    return 0;
                }
            }
        }

        private void Processo_codifica_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                try
                {
                    FFmpegOutputWrapperNET ff = new FFmpegOutputWrapperNET(e.Data.Trim());
                    String temp_extra = e.Data;
                    if (temp_extra.ToLower().Trim().StartsWith("frame") == false)
                    {
                        rtb_log.Text += temp_extra + "\n";
                        rtb_log.SelectionStart = rtb_log.Text.Length;
                        rtb_log.ScrollToCaret();
                    }
                    try
                    {
                        Int32 frames = Convert.ToInt32(ff.Frames);
                        pb_tot.Maximum = Convert.ToInt32(TimeSpan.Parse(durata).TotalSeconds);
                        String fps = ff.Fps;
                        l_vel.Text = "Velocità: " + fps + " fps";
                        String size = ff.Size.Replace("kB", "");
                        l_dim_att.Text = "Dimensione attuale: " + Arrotonda(Convert.ToDouble(size) / 1024.0, 2) + " MB";
                        l_temp_trasc.Text = "Posizione video: " + ff.Time.ToString();
                        ts_avanz.Text = "Avanzamento elaborazione - Codifica del file \"" + file_attuale + "\"";
                        ts_perc.Text = Arrotonda(((Double)pb_tot.Value / pb_tot.Maximum) * 100.0, 2) + "%";
                        pb_tot.Value = Convert.ToInt32(ff.Time.TotalSeconds);

                        DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "IN CORSO - " + ts_perc.Text;
                        DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.White;

                        String bitrate = ff.Bitrate.Remove(ff.Bitrate.IndexOf("k"));

                        if (fps.Contains("."))
                            fps = fps.Remove(fps.IndexOf("."));
                        Int32 tempo_restante = ((Convert.ToInt32(fc) - Convert.ToInt32(ff.Frames)) / Convert.ToInt32(ff.Fps));
                        l_temp_rim.Text = "Tempo rimanente: " + TimeSpan.FromSeconds(tempo_restante).ToString(@"hh\:mm\:ss");
                        Double bitrate_kb = Convert.ToDouble(bitrate.Remove(bitrate.IndexOf("."))) / 8 / 1024.0;
                        Double dimens_stimata = Math.Round(bitrate_kb * TimeSpan.Parse(durata).TotalSeconds, 2);
                        l_dim_prev.Text = "Dimensione stimata: " + dimens_stimata + " MB";
                    }
                    catch// (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        //DGV_log.Rows.Insert(0, DateTime.Now.ToString(), ex.Message + " -> " + ecc);
                    }
                }
                catch { }
            });
        }

        private void Processo_codifica_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(e.Data) == false)
                    {
                        rtb_log.Text = String.Empty;
                        rtb_log.Text += e.Data;
                    }
                }
                catch { }
            });
        }

        public void AvviaCodifica()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(ffmpeg_x64);
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            processo_codifica = new System.Diagnostics.Process();
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            if (Environment.Is64BitOperatingSystem == true)
            {
                psi.FileName = Path.GetFileName(ffmpeg_x64);
            }
            else
            {
                psi.FileName = Path.GetFileName(ffmpeg_x86);
            }
            
            psi.Arguments = comando;

            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            processo_codifica.OutputDataReceived += Processo_codifica_OutputDataReceived;
            processo_codifica.ErrorDataReceived += Processo_codifica_ErrorDataReceived;
            processo_codifica.StartInfo = psi;
            processo_codifica.Start();
            processo_codifica.BeginOutputReadLine();
            processo_codifica.BeginErrorReadLine();
            processo_codifica.WaitForExit();
            processo_codifica.CancelOutputRead();
            processo_codifica.CancelErrorRead();
            exit_code = processo_codifica.ExitCode;
            if (exit_code == 0)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    ts_perc.Text = "100.00%";
                    pb_tot.Value = pb_tot.Maximum;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "OK - " + ts_perc.Text;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.LightGreen;
                    ts_avanz.Text = "Avanzamento elaborazione - Nessuno";
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Value = "ERRORE - " + ts_perc.Text;
                    DGV_video.Rows[indice_percentuale].Cells[DGV_video.Columns["stato"].Index].Style.BackColor = Color.Red;
                    ts_avanz.Text = "Avanzamento elaborazione - Nessuno";
                });
            }

            CreaLOG();
        }

        public void Codifica(String video, String qualita, String prof, Int32 largh, Int32 alt)
        {
            MediaFile media = new MediaFile(video);

            List<CatturaAudio> ca = new List<CatturaAudio>();
            CatturaVideo cv = new CatturaVideo(media);

            ImpostazioniProfiliCodifica.QualitaVideo.Altissima q_altissima = new ImpostazioniProfiliCodifica.QualitaVideo.Altissima();
            ImpostazioniProfiliCodifica.QualitaVideo.Alta q_alta = new ImpostazioniProfiliCodifica.QualitaVideo.Alta();
            ImpostazioniProfiliCodifica.QualitaVideo.MedioAlta q_medioalta = new ImpostazioniProfiliCodifica.QualitaVideo.MedioAlta();
            ImpostazioniProfiliCodifica.QualitaVideo.Media q_media = new ImpostazioniProfiliCodifica.QualitaVideo.Media();
            ImpostazioniProfiliCodifica.QualitaVideo.MedioBassa q_mediobassa = new ImpostazioniProfiliCodifica.QualitaVideo.MedioBassa();
            ImpostazioniProfiliCodifica.QualitaVideo.Bassa q_bassa = new ImpostazioniProfiliCodifica.QualitaVideo.Bassa();
            ImpostazioniProfiliCodifica.QualitaVideo.Bassissima q_bassissima = new ImpostazioniProfiliCodifica.QualitaVideo.Bassissima();
            ImpostazioniProfiliCodifica.QualitaVideo.Bozza q_bozza = new ImpostazioniProfiliCodifica.QualitaVideo.Bozza();

            ImpostazioniProfiliCodifica.ParametriVideo parametri_video = new ImpostazioniProfiliCodifica.ParametriVideo(media);

            fc = Math.Round((Double)cv.TotaleFrames, 0, MidpointRounding.AwayFromZero).ToString();


            foreach (MediaInfoDotNet.Models.AudioStream a in media.Audio)
            {
                ca.Add(new CatturaAudio(a));
            }

            comando = " -y -i \"" + video + "\" -map 0:" + cv.Indice;

            comando += " -c:v:" + cv.Indice + " " + q_altissima.CODEC;
            
            cv.Framerate = cv.Framerate.ToString().Replace(",", ".");

            if (Convert.ToDouble(cv.Framerate) > 0)
                comando += " -r " + cv.Framerate;

            durata = cv.DurataPrecisa.ToString();
            
            switch (qualita)
            {
                case "Altissima":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_altissima.CRF.ToString().Replace(',', '.') + " -preset:v " + q_altissima.Preset + " -aq-mode " + q_altissima.AQmode.ToString();
                            break;
                    }
                    break;
                case "Alta":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_alta.CRF.ToString().Replace(',', '.') + " -preset:v " + q_alta.Preset + " -aq-mode " + q_alta.AQmode.ToString();
                            break;
                    }
                    break;
                case "Medio-alta":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_medioalta.CRF.ToString().Replace(',', '.') + " -preset:v " + q_medioalta.Preset + " -aq-mode " + q_medioalta.AQmode.ToString();
                            break;
                    }
                    break;
                case "Media":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_media.CRF.ToString().Replace(',', '.') + " -preset:v " + q_media.Preset + " -aq-mode " + q_media.AQmode.ToString();
                            break;
                    }
                    break;
                case "Medio-bassa":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_mediobassa.CRF.ToString().Replace(',', '.') + " -preset:v " + q_mediobassa.Preset + " -aq-mode " + q_mediobassa.AQmode.ToString();
                            break;
                    }
                    break;
                case "Bassa":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_bassa.CRF.ToString().Replace(',', '.') + " -preset:v " + q_bassa.Preset + " -aq-mode " + q_bassa.AQmode.ToString();
                            break;
                    }
                    break;
                case "Bassissima":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_bassissima.CRF.ToString().Replace(',', '.') + " -preset:v " + q_bassissima.Preset + " -aq-mode " + q_bassissima.AQmode.ToString();
                            break;
                    }
                    break;
                case "Bozza":
                    switch (prof.Split(' ')[0])
                    {
                        default:
                            comando += " -crf: " + q_bozza.CRF.ToString().Replace(',', '.') + " -preset:v " + q_bozza.Preset + " -aq-mode " + q_bozza.AQmode.ToString();
                            break;
                    }
                    break;
            }
            switch (prof.Split(' ')[0])
            {
                case "Bluray":
                    comando += " " + parametri_video.BLURAY;
                    break;
            }
            if (ca.Count > 0)
            {
                List<CatturaAudio> temp3 = new List<CatturaAudio>();
                Int32 cont_audio = 0;
                foreach (CatturaAudio c in ca)
                {
                    if (c.Default == true || c.Forzata == true)
                    {
                        temp3.Clear();
                        temp3.Add(c);
                    }
                }
                if (temp3.Count == 0)
                {
                    temp3.Clear();
                    temp3.Add(new CatturaAudio(media.Audio[0]));
                }
                if(temp3.Count==0)
                {
                    temp3 = ca;
                }

                foreach (CatturaAudio c in temp3)
                {
                    ImpostazioniProfiliAudio parametri_audio = new ImpostazioniProfiliAudio(prof, qualita, c);

                    switch (c.Formato)
                    {
                        case "MP3":
                            if (prof.StartsWith("XviD"))
                            {
                                if (c.BitrateVariabile == true)
                                {
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -b:a:" + cont_audio + " " + parametri_audio.Bitrate + "k";
                                }
                                else
                                {
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " copy";
                                }
                            }
                            else
                            {
                                if (prof.StartsWith("Work"))
                                {
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                                }
                                else
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -b:a:" + cont_audio + " " + parametri_audio.Bitrate + "k";
                            }
                            break;
                        case "AAC":
                            if (prof.StartsWith("Bluray AAC") || prof.StartsWith("PS3") || prof.StartsWith("Xbox") || prof.StartsWith("Streaming"))
                            {
                                if (prof.StartsWith("Streaming") && c.Canali > 2)
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -b:a:" + cont_audio + " " + parametri_audio.Bitrate + "k";
                                else
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " copy";
                            }
                            else
                            {
                                if (prof.StartsWith("Work"))
                                {
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                                }
                                else
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -b:a:" + cont_audio + " " + parametri_audio.Bitrate + "k";
                            }
                            break;
                        case "AC-3":
                            if (prof.StartsWith("Bluray AC3"))
                            {
                                comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " copy";
                            }
                            else
                            {
                                if (prof.StartsWith("Work"))
                                {
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                                }
                                else
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -b:a:" + cont_audio + " " + parametri_audio.Bitrate + "k";
                            }
                            break;
                        case "Vorbis":
                            if (prof.StartsWith("Work"))
                            {
                                if (c.Canali > 1)
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                                else
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " copy";
                            }
                            else
                            {
                                comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                            }
                            break;
                        default:
                            if (prof.StartsWith("Work"))
                            {
                                if (c.Canali > 2)
                                    comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                                comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -q:a:" + cont_audio + " " + parametri_audio.Q;
                            }
                            else
                                comando += " -map 0:" + c.Indice.ToString() + " -c:a:" + cont_audio + " " + parametri_audio.CODEC + " -ac:a:" + cont_audio + " " + parametri_audio.Canali + " -b:a:" + cont_audio + " " + parametri_audio.Bitrate + "k";
                            break;
                    }
                    cont_audio++;
                }
            }
            else
            {
                comando += " -an";
            }

            comando += FiltriCodifica(cv, largh, alt) + " -aspect " + cv.AspectRatio;

            if (prof.ToLower().Contains("xvid"))
            {
                file_finale = Path.GetDirectoryName(video) + "\\" + Path.GetFileNameWithoutExtension(video) + "[" + prof + " " + alt.ToString() + "p, " + qualita + "].avi";
            }
            else
            {
                if (prof.StartsWith("Work") == true)
                {
                    file_finale = Path.GetDirectoryName(video) + "\\" + Path.GetFileNameWithoutExtension(video) + "[" + prof + " " + alt.ToString() + "p, " + qualita + "].mkv";
                }
                else
                {
                    file_finale = Path.GetDirectoryName(video) + "\\" + Path.GetFileNameWithoutExtension(video) + "[" + prof + " " + alt.ToString() + "p, " + qualita + "].mp4";
                }
            }

            if (ca != null)
                comando += " -metadata:s:a title=\"\"";
            comando += " \"" + file_finale + "\"";
            AvviaCodifica();
        }

        public String FiltriCodifica(CatturaVideo cv, Int32 largh, Int32 alt)
        {
            String temp = String.Empty;

            if (cv.Interlacciato == true)
            {
                temp += ",yadif";
            }

            temp += ResizeAuto(cv.AspectRatio, largh, cv.Larghezza, alt, cv.Altezza);
            if (String.IsNullOrWhiteSpace(temp) == false)
            {
                return " -vf " + temp.Trim(',');
            }
            else
                return String.Empty;
        }

        public void ferma_tutto()
        {
            try
            {
                t.Abort();
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ffmpeg_x64)))
                {
                    p.Kill();
                }
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ffmpeg_x86)))
                {
                    p.Kill();
                }
            }
            catch { }
        }

        private void FVE_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Activate();
            if (forza_chiusura == true)
            {
                e.Cancel = false;
                chiudi();
            }
            else
            {
                if (MessageBox.Show("Si sta per chiudere l'applicazione. Continuare?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    chiudi();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        public void chiudi()
        {
            try
            {
                ferma_tutto();
                
                foreach (String s in Directory.GetFiles(Path.GetDirectoryName(ffmpeg_x64)))
                {
                    if (Path.GetFileName(s).ToLower().Contains("sub"))
                        System.IO.File.Delete(s);
                }
            }
            catch { }
            IniFile ini = new IniFile(file_settings);
            ini.Write("WindowState", this.WindowState.ToString());
        }

        private void rimuoviIFileSelezionatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in DGV_video.SelectedRows)
            {
                DGV_video.Rows.Remove(d);
            }
            if (DGV_video.Rows.Count == 0)
            {
                b_avvia.Enabled = false;
                tb_help.Visible = true;
            }
            tab_autohardsubber.Text = label_tab_lista + " (Totale files: " + DGV_video.Rows.Count.ToString() + ")";
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void confermaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in DGV_video.SelectedRows)
            {
                d.Cells[DGV_video.Columns["compatibilita"].Index].Value = toolStripComboBox2.Text;
                String p = d.Cells[DGV_video.Columns["compatibilita"].Index].Value.ToString();
            }
        }

        private void confermaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in DGV_video.SelectedRows)
            {
                d.Cells[DGV_video.Columns["risoluz"].Index].Value = toolStripComboBox4.Text;
            }
        }

        public static string Arrotonda(Double cifra, Int32 decimali)
        {
            return String.Format("{0:f" + decimali + "}", cifra);
        }

        private void IncollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Collections.Specialized.StringCollection data = new System.Collections.Specialized.StringCollection();
            if (Clipboard.GetFileDropList().Count > 0)
                data = Clipboard.GetFileDropList();
            else
            {
                if (Clipboard.ContainsText() == true)
                {
                    String[] c = Clipboard.GetText().Split('\n');
                    for (Int32 i = 0; i < c.Count() - 1; i++)
                        data.Add(c[i]);
                }
            }
            String[] temp = new String[data.Count];
            data.CopyTo(temp, 0);
            recupera_fd(temp);
        }

        private void salvaImpostazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(file_settings);

            ini.Write("comp", toolStripComboBox2.Text);
            ini.Write("risoluz", toolStripComboBox3.Text);
            ini.Write("qual", toolStripComboBox4.Text);

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About(this.Text, this.Text.Split(' ')[5]);
            a.Icon = this.Icon;
            a.ShowInTaskbar = false;
            a.ShowDialog();
        }

        private void b_agg_files_Click(object sender, EventArgs e)
        {
            apri_video.Filter = filtro;
            if (apri_video.ShowDialog() == DialogResult.OK)
            {
                foreach (String s in apri_video.FileNames)
                {
                    DGV_video.Rows.Add(Path.GetFileName(s), toolStripComboBox2.Text, toolStripComboBox3.Text, toolStripComboBox4.Text, "PRONTO", Path.GetDirectoryName(s));
                }
                b_avvia.Enabled = true;
                tab_autohardsubber.Text = label_tab_lista + " (Totale files: " + DGV_video.Rows.Count.ToString() + ")";
                tb_help.Visible = false;
            }
        }

        private void b_agg_cart_Click(object sender, EventArgs e)
        {
            if (apri_cartella.ShowDialog() == DialogResult.OK)
            {
                Seleziona_formati sf = new Seleziona_formati(estensioni_video);
                sf.Icon = this.Icon;
                sf.TopLevel = true;
                sf.StartPosition = FormStartPosition.CenterParent;
                sf.ShowInTaskbar = false;
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    foreach (String s in Directory.GetFiles(apri_cartella.SelectedPath, "*", SearchOption.AllDirectories))
                    {
                        if (PA_Video_Encoder.Seleziona_formati.formati_scelti.Contains(Path.GetExtension(s).ToLower()) == true)
                        {
                            DGV_video.Rows.Add(Path.GetFileName(s), toolStripComboBox2.Text, toolStripComboBox3.Text, toolStripComboBox4.Text, "PRONTO", Path.GetDirectoryName(s));
                        }
                    }
                }
                if (DGV_video.Rows.Count > 0)
                {
                    b_avvia.Enabled = true;
                    tb_help.Visible = false;
                    tab_autohardsubber.Text = label_tab_lista + " (Totale files: " + DGV_video.Rows.Count.ToString() + ")";
                }
            }
        }

        private void b_incolla_Click(object sender, EventArgs e)
        {
            IncollaToolStripMenuItem_Click(sender, e);
        }

        private void B_rimuovi_Click(object sender, EventArgs e)
        {
            rimuoviIFileSelezionatiToolStripMenuItem_Click(sender, e);
        }

        private void ripristinaImpostazioniToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ripristinare programma/impostazioni e riavviare l'applicazione?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                forza_chiusura = true;
                if (Directory.Exists(Path.GetDirectoryName(file_settings)))
                {
                    Directory.Delete(Path.GetDirectoryName(file_settings), true);
                }
                if (Directory.Exists(LOG_dir))
                {
                    Directory.Delete(LOG_dir, true);
                }
                Application.Restart();
            }
        }

        private void oKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (Int32 i=DGV_video.Rows.Count-1; i>=0; i--)
            {
                if (DGV_video.Rows[i].Cells[DGV_video.Columns["stato"].Index].Value.ToString().ToLower().Contains(oKToolStripMenuItem.Text.ToLower()))
                    DGV_video.Rows.RemoveAt(DGV_video.Rows[i].Index);
            }
        }

        private void fermatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (Int32 i = DGV_video.Rows.Count - 1; i >= 0; i--)
            {
                if (DGV_video.Rows[i].Cells[DGV_video.Columns["stato"].Index].Value.ToString().ToLower().Contains(fermatoToolStripMenuItem.Text.ToLower()))
                    DGV_video.Rows.RemoveAt(DGV_video.Rows[i].Index);
            }
        }

        private void timer_tempo_Tick(object sender, EventArgs e)
        {
            TimeSpan tp = TimeSpan.FromSeconds((Double)sec_trasc);
            l_tempo_trasc.Text = "Tempo trascorso: " + tp.ToString(@"hh\:mm\:ss");
            sec_trasc++;
        }

        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String link = Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".lnk";
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut(link) as IWshShortcut;
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Save();
        }

        private void cancellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + "\\" + Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".lnk");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void tuttiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si vuole veramente cancellare tutti i files nella lista?\nAvviso: la cancellazione viene effettuata in maniera DEFINITIVA.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cancella_files_lista(String.Empty);
            }
        }

        public void cancella_files_lista(String quali)
        {
            Int32 cont_files_canc = 0;
            Dictionary<String, String> files_non_canc = new Dictionary<String, String>();
            for (Int32 i = DGV_video.Rows.Count - 1; i >= 0; i--)
            {
                String nome_file = DGV_video.Rows[i].Cells[DGV_video.Columns["input"].Index].Value.ToString();
                try
                {
                    switch (quali)
                    {
                        case "Ok":
                            if (DGV_video.Rows[i].Cells[DGV_video.Columns["stato"].Index].Value.ToString().ToLower().Contains(oKToolStripMenuItem.Text.ToLower()))
                            {
                                System.IO.File.Delete(nome_file);
                                DGV_video.Rows.Remove(DGV_video.Rows[i]);
                                cont_files_canc++;
                            }
                            break;
                        case "Fermato":
                            if (DGV_video.Rows[i].Cells[DGV_video.Columns["stato"].Index].Value.ToString().ToLower().Contains(fermatoToolStripMenuItem.Text.ToLower()))
                            {
                                System.IO.File.Delete(nome_file);
                                DGV_video.Rows.Remove(DGV_video.Rows[i]);
                                cont_files_canc++;
                            }
                            break;
                        case "Errore":
                            if (DGV_video.Rows[i].Cells[DGV_video.Columns["stato"].Index].Value.ToString().ToLower().Contains(erroreToolStripMenuItem.Text.ToLower()))
                            {
                                System.IO.File.Delete(nome_file);
                                DGV_video.Rows.Remove(DGV_video.Rows[i]);
                                cont_files_canc++;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    files_non_canc.Add(DGV_video.Rows[i].Cells[DGV_video.Columns["input"].Index].Value.ToString(), ex.Message);
                }
            }
            if (files_non_canc.Count > 0)
            {
                MessageBox.Show("Totale files cancellati: " + cont_files_canc.ToString(), this.Text);
            }
        }

        private void completatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si vuole veramente cancellare tutti i files nella lista?\nAvviso: la cancellazione viene effettuata in maniera DEFINITIVA.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cancella_files_lista("Ok");
            }
        }

        private void fermatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si vuole veramente cancellare tutti i files nella lista?\nAvviso: la cancellazione viene effettuata in maniera DEFINITIVA.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cancella_files_lista("Fermato");
            }
        }

        private void conErroriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si vuole veramente cancellare tutti i files nella lista?\nAvviso: la cancellazione viene effettuata in maniera DEFINITIVA.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cancella_files_lista("Errore");
            }
        }

        private void rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            azione_fine_coda = toolStripComboBox1.Text;
        }

        private void DGV_video_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_video.Rows.Count > 0)
            {
                if (e.ColumnIndex == DGV_video.Columns["compatibilita"].Index)
                {
                    String p = DGV_video.Rows[e.RowIndex].Cells[DGV_video.Columns["compatibilita"].Index].Value.ToString();
                }
            }
        }

        private void b_pause_Click(object sender, EventArgs e)
        {
            if (pause == false)
            {
                SuspendProcess(processo_codifica.Id);
                pause = true;
                b_pause.Text = "Riprendi";
                b_pause.BackColor = Color.LawnGreen;
            }
            else
            {
                ResumeProcess(processo_codifica.Id);
                pause = false;
                b_pause.Text = "Pausa";
                b_pause.BackColor = Color.Yellow;
            }
        }

        private void erroreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (Int32 i = DGV_video.Rows.Count - 1; i >= 0; i--)
            {
                if (DGV_video.Rows[i].Cells[DGV_video.Columns["stato"].Index].Value.ToString().ToLower().Contains(erroreToolStripMenuItem.Text.ToLower()))
                    DGV_video.Rows.RemoveAt(DGV_video.Rows[i].Index);
            }
        }

        private void confermaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in DGV_video.SelectedRows)
            {
                d.Cells[DGV_video.Columns["qualita"].Index].Value = toolStripComboBox4.Text;
            }
        }

        private void ApriCartellaLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LOG_dir);
        }

        private void DGV_video_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DGV_video.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    class IniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }

    }

    public class CatturaAudio
    {
        public String Formato { get; set; }
        public String Profilo { get; set; }
        public Double Canali { get; set; }
        public Int32 Indice { get; set; }
        public Boolean BitrateVariabile { get; set; }
        public Boolean Forzata { get; set; }
        public Boolean Default { get; set; }            
        public Boolean Lossless { get; set; }

        public CatturaAudio(MediaInfoDotNet.Models.AudioStream a)
        {
            Cattura(a);
        }

        protected void Cattura(MediaInfoDotNet.Models.AudioStream a)
        {
            Forzata = a.Forced;
            Default = a.Default;
            Formato = a.Format;
            if (a.CompressionMode.ToLower().EndsWith("y"))
                Lossless = false;
            else
                Lossless = true;

            
            if(String.IsNullOrWhiteSpace(Formato))
            {
                Formato = String.Empty;
            }

            Profilo = a.FormatProfile;
            
            if(String.IsNullOrWhiteSpace(Profilo))
            {
                Profilo = String.Empty;
            }

            Indice = a.ID - 1;

            Canali = Convert.ToDouble(a.Channels);

            if (a.BitRateMode == "CBR")
            {
                BitrateVariabile = true;
            }
            else
            {
                BitrateVariabile = false;
            }
        }
    }

    public class CatturaVideo
    {
        public String File { get; set; }
        public Int32 Indice { get; set; }
        public String AspectRatio { get; set; }
        public Double Larghezza { get; set; }
        public Double Altezza { get; set; }
        public String Framerate { get; set; }
        public Boolean Interlacciato { get; set; }
        public TimeSpan DurataPrecisa { get; set; }
        public Int32 TotaleFrames { get; set; }

        public CatturaVideo(MediaFile media)
        {
            Cattura(media);
        }

        protected void Cattura(MediaFile media)
        {
            File = media.filePath;
            Indice = media.Video[0].ID - 1;
            AspectRatio = media.Video[0].DisplayAspectRatio.ToString().Replace(",", ".");
            if (String.IsNullOrWhiteSpace(AspectRatio))
                AspectRatio = String.Empty;
            Framerate = (media.Video[0].FrameRate).ToString();
            DurataPrecisa = TimeSpan.FromMilliseconds(media.Video[0].Duration);
            TotaleFrames = media.Video[0].FrameCount;
            if (media.Video[0].miOption("ScanType").StartsWith("P"))
            {
                Interlacciato = false;
            }
            else
            {
                Interlacciato = true;
            }
            Larghezza = media.Video[0].Width;
            Altezza = media.Video[0].Height;
        }
    }

    public class ImpostazioniProfiliCodifica
    {
        public class ParametriVideo
        {
            public String BLURAY { get; }
            
            public ParametriVideo(MediaFile media)
            {
                BLURAY = " -profile:v high -level:v 4.1 -bluray-compat 1 -maxrate 50000k -bufsize 70000k -pix_fmt yuv420p";
            }
        }

        public class QualitaVideo
        {
            public class Altissima
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public Altissima()
                {
                    CRF = 17;
                    CODEC = "libx264";
                    Preset = "veryslow";
                    AQmode = 3;
                }
            }
            public class Alta
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public Alta()
                {
                    CODEC = "libx264";
                    Preset = "slower";
                    AQmode = 3;
                    CRF = 20;
                }
            }
            public class MedioAlta
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public MedioAlta()
                {
                    CODEC = "libx264";
                    Preset = "slow";
                    AQmode = 2;
                    CRF = 23;
                }
            }
            public class Media
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public Media()
                {
                    CODEC = "libx264";
                    Preset = "medium";
                    AQmode = 2;
                    CRF = 26;
                }
            }
            public class MedioBassa
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public MedioBassa()
                {
                    CODEC = "libx264";
                    Preset = "fast";
                    AQmode = 2;
                    CRF = 29;
                }
            }
            public class Bassa
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public Bassa()
                {
                    CODEC = "libx264";
                    Preset = "faster";
                    AQmode = 2;
                    CRF = 32;
                }
            }
            public class Bassissima
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public Bassissima()
                {
                    CODEC = "libx264";
                    Preset = "veryfast";
                    AQmode = 1;
                    CRF = 35;
                }
            }
            public class Bozza
            {
                public Double CRF { get; }
                public String Preset { get; }
                public Double AQmode { get; }
                public String CODEC { get; }

                public Bozza()
                {
                    CODEC = "libx264";
                    Preset = "superfast";
                    AQmode = 1;
                    CRF = 38;
                }
            }
        }
    }

    public class ImpostazioniProfiliAudio
    {
        public Double Bitrate { get; set; }
        public Double Q { get; set; }
        public Double Canali { get; set; }
        public String CODEC { get; set; }

        public ImpostazioniProfiliAudio(String profilo, String qualita, CatturaAudio audio)
        {
            switch (qualita)
            {
                case "Altissima":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 160 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                            Bitrate = Double.NaN;
                            Q = 7;
                            CODEC = "libvorbis";
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 96 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali >= 2)
                                        Canali = 2;
                                    Bitrate = 128 * Canali;
                                    Q = Double.NaN;
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 192 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Alta":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 128 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                            Bitrate = Double.NaN;
                            Q = 6;
                            CODEC = "libvorbis";
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 96 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali >= 2)
                                        Canali = 2;
                                    Bitrate = 96 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 160 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Medio-alta":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 112 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                            Bitrate = Double.NaN;
                            Q = 5;
                            CODEC = "libvorbis";
                            Canali = audio.Canali;
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 80 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali >= 2)
                                        Canali = 2;
                                    Bitrate = 80 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 144 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Media":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 96 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            Bitrate = Double.NaN;
                            Q = 4;
                            CODEC = "libvorbis";
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 80 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali > 2)
                                        Canali = 2;
                                    Bitrate = 80 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 128 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Medio-bassa":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 80 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            Bitrate = Double.NaN;
                            Q = 3;
                            CODEC = "libvorbis";
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 80 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali > 2)
                                        Canali = 2;
                                    Bitrate = 64 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 96 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Bassa":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 64 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            Bitrate = Double.NaN;
                            Q = 2;
                            CODEC = "libvorbis";
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 64 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali > 2)
                                        Canali = 2;
                                    Bitrate = 48 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 64 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Bassissima":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 48 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            Bitrate = Double.NaN;
                            Q = 1;
                            CODEC = "libvorbis";
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 48 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali > 2)
                                        Canali = 2;
                                    Bitrate = 32 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 48 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
                case "Bozza":
                    if (profilo.ToLower().Contains("xvid"))
                    {
                        Bitrate = 32 * Convert.ToInt32(audio.Canali);
                        Q = Double.NaN;
                        CODEC = "libmp3lame";
                        if (audio.Canali >= 2)
                            Canali = 2;
                        else
                            Canali = audio.Canali;
                    }
                    else
                    {
                        if (profilo.ToLower().Contains("workraw"))
                        {
                            Bitrate = Double.NaN;
                            Q = 0;
                            CODEC = "libvorbis";
                            if (audio.Canali >= 1)
                                Canali = 1;
                            else
                                Canali = audio.Canali;
                        }
                        else
                        {
                            if (profilo.ToLower().Contains("ac3"))
                            {
                                Bitrate = 32 * Convert.ToInt32(audio.Canali);
                                Q = Double.NaN;
                                CODEC = "ac3";
                                Canali = audio.Canali;
                            }
                            else
                            {
                                if (profilo.ToLower().Contains("xbox"))
                                {
                                    if (audio.Canali > 2)
                                        Canali = 2;
                                    Bitrate = 24 * Canali;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                                else
                                {
                                    if (profilo.ToLower().Contains("streaming"))
                                    {
                                        if (audio.Canali >= 2)
                                            Canali = 2;
                                        else
                                            Canali = audio.Canali;
                                    }
                                    else
                                        Canali = audio.Canali;
                                    Bitrate = 32 * Convert.ToInt32(Canali) / 2;
                                    Q = Double.NaN;
                                    CODEC = "aac";
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}