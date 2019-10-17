namespace PA_Video_Encoder
{
    partial class PAVideoEncoder
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAVideoEncoder));
            this.tasto_destro_files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rimuoviIFileSelezionatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.IncollaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriCartellaLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salvaImpostazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ripristinaImpostazioniToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compatibilitàToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_compatibilita = new System.Windows.Forms.ToolStripComboBox();
            this.confermaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.risoluzioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_risoluz = new System.Windows.Forms.ToolStripComboBox();
            this.confermaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.qualitàToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_qualita = new System.Windows.Forms.ToolStripComboBox();
            this.confermaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.strumentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviTuttiIFileConEsitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancellaIFilesNellaListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuttiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conErroriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.integraConIlMenùContestualeDiWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancellaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impostazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allaFineDellaCodaDiLavoroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_tempo_trasc = new System.Windows.Forms.Label();
            this.l_dim_prev = new System.Windows.Forms.Label();
            this.l_dim_att = new System.Windows.Forms.Label();
            this.l_temp_rim = new System.Windows.Forms.Label();
            this.l_temp_trasc = new System.Windows.Forms.Label();
            this.l_vel = new System.Windows.Forms.Label();
            this.tab_tna = new System.Windows.Forms.TabControl();
            this.tab_autohardsubber = new System.Windows.Forms.TabPage();
            this.tb_help = new System.Windows.Forms.TextBox();
            this.DGV_video = new System.Windows.Forms.DataGridView();
            this.input = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compatibilita = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.risoluz = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualita = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.stato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percorso_orig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_log = new System.Windows.Forms.TabPage();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ll_icons = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.apri_video = new System.Windows.Forms.OpenFileDialog();
            this.apri_cartella = new System.Windows.Forms.FolderBrowserDialog();
            this.timer_tempo = new System.Windows.Forms.Timer(this.components);
            this.tt_encode = new System.Windows.Forms.ToolTip(this.components);
            this.barra_stato = new System.Windows.Forms.StatusStrip();
            this.pb_tot = new System.Windows.Forms.ToolStripProgressBar();
            this.ts_perc = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_avanz = new System.Windows.Forms.ToolStripStatusLabel();
            this.b_agg_files = new System.Windows.Forms.Button();
            this.b_agg_cart = new System.Windows.Forms.Button();
            this.b_rimuovi = new System.Windows.Forms.Button();
            this.b_avvia = new System.Windows.Forms.Button();
            this.b_pause = new System.Windows.Forms.Button();
            this.b_incolla = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox4 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox5 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
            this.tasto_destro_files.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_tna.SuspendLayout();
            this.tab_autohardsubber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_video)).BeginInit();
            this.tab_log.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tasto_destro_files
            // 
            this.tasto_destro_files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rimuoviIFileSelezionatiToolStripMenuItem,
            this.toolStripSeparator1,
            this.IncollaToolStripMenuItem});
            this.tasto_destro_files.Name = "tasto_destro_files";
            this.tasto_destro_files.Size = new System.Drawing.Size(202, 54);
            // 
            // rimuoviIFileSelezionatiToolStripMenuItem
            // 
            this.rimuoviIFileSelezionatiToolStripMenuItem.Name = "rimuoviIFileSelezionatiToolStripMenuItem";
            this.rimuoviIFileSelezionatiToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.rimuoviIFileSelezionatiToolStripMenuItem.Text = "Rimuovi i file selezionati";
            this.rimuoviIFileSelezionatiToolStripMenuItem.Click += new System.EventHandler(this.rimuoviIFileSelezionatiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // IncollaToolStripMenuItem
            // 
            this.IncollaToolStripMenuItem.Name = "IncollaToolStripMenuItem";
            this.IncollaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.IncollaToolStripMenuItem.Text = "Incolla";
            this.IncollaToolStripMenuItem.Click += new System.EventHandler(this.IncollaToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriCartellaLogsToolStripMenuItem,
            this.toolStripSeparator2,
            this.salvaImpostazioniToolStripMenuItem,
            this.ripristinaImpostazioniToolStripMenuItem3,
            this.toolStripSeparator8,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // apriCartellaLogsToolStripMenuItem
            // 
            this.apriCartellaLogsToolStripMenuItem.Name = "apriCartellaLogsToolStripMenuItem";
            this.apriCartellaLogsToolStripMenuItem.Size = new System.Drawing.Size(339, 22);
            this.apriCartellaLogsToolStripMenuItem.Text = "Apri cartella logs";
            this.apriCartellaLogsToolStripMenuItem.Click += new System.EventHandler(this.ApriCartellaLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(336, 6);
            // 
            // salvaImpostazioniToolStripMenuItem
            // 
            this.salvaImpostazioniToolStripMenuItem.Name = "salvaImpostazioniToolStripMenuItem";
            this.salvaImpostazioniToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.salvaImpostazioniToolStripMenuItem.Size = new System.Drawing.Size(339, 22);
            this.salvaImpostazioniToolStripMenuItem.Text = "Salva impostazioni";
            this.salvaImpostazioniToolStripMenuItem.Click += new System.EventHandler(this.salvaImpostazioniToolStripMenuItem_Click);
            // 
            // ripristinaImpostazioniToolStripMenuItem3
            // 
            this.ripristinaImpostazioniToolStripMenuItem3.Name = "ripristinaImpostazioniToolStripMenuItem3";
            this.ripristinaImpostazioniToolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ripristinaImpostazioniToolStripMenuItem3.Size = new System.Drawing.Size(339, 22);
            this.ripristinaImpostazioniToolStripMenuItem3.Text = "Ripristina le impostazioni e il programma";
            this.ripristinaImpostazioniToolStripMenuItem3.Click += new System.EventHandler(this.ripristinaImpostazioniToolStripMenuItem3_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(336, 6);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(339, 22);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compatibilitàToolStripMenuItem,
            this.risoluzioneToolStripMenuItem,
            this.qualitàToolStripMenuItem});
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.modificaToolStripMenuItem.Text = "Modifica";
            // 
            // compatibilitàToolStripMenuItem
            // 
            this.compatibilitàToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmb_compatibilita,
            this.confermaToolStripMenuItem});
            this.compatibilitàToolStripMenuItem.Name = "compatibilitàToolStripMenuItem";
            this.compatibilitàToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.compatibilitàToolStripMenuItem.Text = "Compatibilità";
            // 
            // cmb_compatibilita
            // 
            this.cmb_compatibilita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_compatibilita.Items.AddRange(new object[] {
            "Bluray AAC",
            "Bluray AC3",
            "Remux MP4",
            "Remux MKV"});
            this.cmb_compatibilita.Name = "cmb_compatibilita";
            this.cmb_compatibilita.Size = new System.Drawing.Size(190, 23);
            // 
            // confermaToolStripMenuItem
            // 
            this.confermaToolStripMenuItem.Name = "confermaToolStripMenuItem";
            this.confermaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.confermaToolStripMenuItem.Text = "Conferma";
            this.confermaToolStripMenuItem.Click += new System.EventHandler(this.confermaToolStripMenuItem_Click);
            // 
            // risoluzioneToolStripMenuItem
            // 
            this.risoluzioneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmb_risoluz,
            this.confermaToolStripMenuItem2});
            this.risoluzioneToolStripMenuItem.Name = "risoluzioneToolStripMenuItem";
            this.risoluzioneToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.risoluzioneToolStripMenuItem.Text = "Risoluzione";
            // 
            // cmb_risoluz
            // 
            this.cmb_risoluz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_risoluz.Items.AddRange(new object[] {
            "1080p",
            "900p",
            "720p",
            "576p",
            "480p",
            "396p"});
            this.cmb_risoluz.Name = "cmb_risoluz";
            this.cmb_risoluz.Size = new System.Drawing.Size(121, 23);
            // 
            // confermaToolStripMenuItem2
            // 
            this.confermaToolStripMenuItem2.Name = "confermaToolStripMenuItem2";
            this.confermaToolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.confermaToolStripMenuItem2.Text = "Conferma";
            this.confermaToolStripMenuItem2.Click += new System.EventHandler(this.confermaToolStripMenuItem2_Click);
            // 
            // qualitàToolStripMenuItem
            // 
            this.qualitàToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmb_qualita,
            this.confermaToolStripMenuItem1});
            this.qualitàToolStripMenuItem.Name = "qualitàToolStripMenuItem";
            this.qualitàToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.qualitàToolStripMenuItem.Text = "Qualità";
            // 
            // cmb_qualita
            // 
            this.cmb_qualita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_qualita.Items.AddRange(new object[] {
            "Altissima",
            "Alta",
            "Medio-alta",
            "Media",
            "Medio-bassa",
            "Bassa",
            "Bassissima",
            "Bozza"});
            this.cmb_qualita.Name = "cmb_qualita";
            this.cmb_qualita.Size = new System.Drawing.Size(121, 23);
            // 
            // confermaToolStripMenuItem1
            // 
            this.confermaToolStripMenuItem1.Name = "confermaToolStripMenuItem1";
            this.confermaToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.confermaToolStripMenuItem1.Text = "Conferma";
            this.confermaToolStripMenuItem1.Click += new System.EventHandler(this.confermaToolStripMenuItem1_Click);
            // 
            // strumentiToolStripMenuItem
            // 
            this.strumentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaToolStripMenuItem,
            this.cancellaIFilesNellaListaToolStripMenuItem,
            this.toolStripSeparator4,
            this.integraConIlMenùContestualeDiWindowsToolStripMenuItem});
            this.strumentiToolStripMenuItem.Name = "strumentiToolStripMenuItem";
            this.strumentiToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.strumentiToolStripMenuItem.Text = "Strumenti";
            // 
            // listaToolStripMenuItem
            // 
            this.listaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rimuoviTuttiIFileConEsitoToolStripMenuItem});
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.listaToolStripMenuItem.Text = "Pulisci lista";
            // 
            // rimuoviTuttiIFileConEsitoToolStripMenuItem
            // 
            this.rimuoviTuttiIFileConEsitoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oKToolStripMenuItem,
            this.fermatoToolStripMenuItem,
            this.erroreToolStripMenuItem});
            this.rimuoviTuttiIFileConEsitoToolStripMenuItem.Name = "rimuoviTuttiIFileConEsitoToolStripMenuItem";
            this.rimuoviTuttiIFileConEsitoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.rimuoviTuttiIFileConEsitoToolStripMenuItem.Text = "Rimuovi tutti i file con esito...";
            // 
            // oKToolStripMenuItem
            // 
            this.oKToolStripMenuItem.Name = "oKToolStripMenuItem";
            this.oKToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.oKToolStripMenuItem.Text = "Ok";
            this.oKToolStripMenuItem.Click += new System.EventHandler(this.oKToolStripMenuItem_Click);
            // 
            // fermatoToolStripMenuItem
            // 
            this.fermatoToolStripMenuItem.Name = "fermatoToolStripMenuItem";
            this.fermatoToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.fermatoToolStripMenuItem.Text = "Fermato";
            this.fermatoToolStripMenuItem.Click += new System.EventHandler(this.fermatoToolStripMenuItem_Click);
            // 
            // erroreToolStripMenuItem
            // 
            this.erroreToolStripMenuItem.Name = "erroreToolStripMenuItem";
            this.erroreToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.erroreToolStripMenuItem.Text = "Errore";
            this.erroreToolStripMenuItem.Click += new System.EventHandler(this.erroreToolStripMenuItem_Click);
            // 
            // cancellaIFilesNellaListaToolStripMenuItem
            // 
            this.cancellaIFilesNellaListaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tuttiToolStripMenuItem,
            this.completatiToolStripMenuItem,
            this.fermatiToolStripMenuItem,
            this.conErroriToolStripMenuItem});
            this.cancellaIFilesNellaListaToolStripMenuItem.Name = "cancellaIFilesNellaListaToolStripMenuItem";
            this.cancellaIFilesNellaListaToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.cancellaIFilesNellaListaToolStripMenuItem.Text = "Cancella i files nella lista";
            // 
            // tuttiToolStripMenuItem
            // 
            this.tuttiToolStripMenuItem.Name = "tuttiToolStripMenuItem";
            this.tuttiToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.tuttiToolStripMenuItem.Text = "Tutti";
            this.tuttiToolStripMenuItem.Click += new System.EventHandler(this.tuttiToolStripMenuItem_Click);
            // 
            // completatiToolStripMenuItem
            // 
            this.completatiToolStripMenuItem.Name = "completatiToolStripMenuItem";
            this.completatiToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.completatiToolStripMenuItem.Text = "Completati";
            this.completatiToolStripMenuItem.Click += new System.EventHandler(this.completatiToolStripMenuItem_Click);
            // 
            // fermatiToolStripMenuItem
            // 
            this.fermatiToolStripMenuItem.Name = "fermatiToolStripMenuItem";
            this.fermatiToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.fermatiToolStripMenuItem.Text = "Fermati";
            this.fermatiToolStripMenuItem.Click += new System.EventHandler(this.fermatiToolStripMenuItem_Click);
            // 
            // conErroriToolStripMenuItem
            // 
            this.conErroriToolStripMenuItem.Name = "conErroriToolStripMenuItem";
            this.conErroriToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.conErroriToolStripMenuItem.Text = "Con errori";
            this.conErroriToolStripMenuItem.Click += new System.EventHandler(this.conErroriToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(303, 6);
            // 
            // integraConIlMenùContestualeDiWindowsToolStripMenuItem
            // 
            this.integraConIlMenùContestualeDiWindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaToolStripMenuItem,
            this.cancellaToolStripMenuItem});
            this.integraConIlMenùContestualeDiWindowsToolStripMenuItem.Name = "integraConIlMenùContestualeDiWindowsToolStripMenuItem";
            this.integraConIlMenùContestualeDiWindowsToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.integraConIlMenùContestualeDiWindowsToolStripMenuItem.Text = "Integra con il menù contestuale di Windows";
            // 
            // creaToolStripMenuItem
            // 
            this.creaToolStripMenuItem.Name = "creaToolStripMenuItem";
            this.creaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.creaToolStripMenuItem.Text = "Crea";
            this.creaToolStripMenuItem.Click += new System.EventHandler(this.creaToolStripMenuItem_Click);
            // 
            // cancellaToolStripMenuItem
            // 
            this.cancellaToolStripMenuItem.Name = "cancellaToolStripMenuItem";
            this.cancellaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.cancellaToolStripMenuItem.Text = "Cancella";
            this.cancellaToolStripMenuItem.Click += new System.EventHandler(this.cancellaToolStripMenuItem_Click);
            // 
            // impostazioniToolStripMenuItem
            // 
            this.impostazioniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem,
            this.allaFineDellaCodaDiLavoroToolStripMenuItem});
            this.impostazioniToolStripMenuItem.Name = "impostazioniToolStripMenuItem";
            this.impostazioniToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.impostazioniToolStripMenuItem.Text = "Impostazioni";
            // 
            // rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem
            // 
            this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.Name = "rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem";
            this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.Size = new System.Drawing.Size(359, 22);
            this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.Text = "Rimuovi i files sorgenti dopo una corretta conversione";
            this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem.Click += new System.EventHandler(this.rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem_Click);
            // 
            // allaFineDellaCodaDiLavoroToolStripMenuItem
            // 
            this.allaFineDellaCodaDiLavoroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.allaFineDellaCodaDiLavoroToolStripMenuItem.Name = "allaFineDellaCodaDiLavoroToolStripMenuItem";
            this.allaFineDellaCodaDiLavoroToolStripMenuItem.Size = new System.Drawing.Size(359, 22);
            this.allaFineDellaCodaDiLavoroToolStripMenuItem.Text = "Alla fine della coda di lavoro";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Non fare niente",
            "Chiudi l\'applicazione",
            "Stand-by",
            "Spegni il PC"});
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Non fare niente",
            "Chiudi l\'applicazione",
            "Stand-by",
            "Spegni il PC"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.l_tempo_trasc);
            this.groupBox1.Controls.Add(this.l_dim_prev);
            this.groupBox1.Controls.Add(this.l_dim_att);
            this.groupBox1.Controls.Add(this.l_temp_rim);
            this.groupBox1.Controls.Add(this.l_temp_trasc);
            this.groupBox1.Controls.Add(this.l_vel);
            this.groupBox1.Location = new System.Drawing.Point(12, 571);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1127, 63);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni";
            // 
            // l_tempo_trasc
            // 
            this.l_tempo_trasc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_tempo_trasc.AutoSize = true;
            this.l_tempo_trasc.Location = new System.Drawing.Point(202, 18);
            this.l_tempo_trasc.Name = "l_tempo_trasc";
            this.l_tempo_trasc.Size = new System.Drawing.Size(98, 13);
            this.l_tempo_trasc.TabIndex = 5;
            this.l_tempo_trasc.Text = "Tempo trascorso: 0";
            // 
            // l_dim_prev
            // 
            this.l_dim_prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_dim_prev.AutoSize = true;
            this.l_dim_prev.Location = new System.Drawing.Point(432, 39);
            this.l_dim_prev.Name = "l_dim_prev";
            this.l_dim_prev.Size = new System.Drawing.Size(110, 13);
            this.l_dim_prev.TabIndex = 4;
            this.l_dim_prev.Text = "Dimensione stimata: 0";
            // 
            // l_dim_att
            // 
            this.l_dim_att.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_dim_att.AutoSize = true;
            this.l_dim_att.Location = new System.Drawing.Point(432, 18);
            this.l_dim_att.Name = "l_dim_att";
            this.l_dim_att.Size = new System.Drawing.Size(109, 13);
            this.l_dim_att.TabIndex = 3;
            this.l_dim_att.Text = "Dimensione attuale: 0";
            // 
            // l_temp_rim
            // 
            this.l_temp_rim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_temp_rim.AutoSize = true;
            this.l_temp_rim.Location = new System.Drawing.Point(202, 39);
            this.l_temp_rim.Name = "l_temp_rim";
            this.l_temp_rim.Size = new System.Drawing.Size(101, 13);
            this.l_temp_rim.TabIndex = 2;
            this.l_temp_rim.Text = "Tempo rimanente: 0";
            // 
            // l_temp_trasc
            // 
            this.l_temp_trasc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_temp_trasc.AutoSize = true;
            this.l_temp_trasc.Location = new System.Drawing.Point(6, 39);
            this.l_temp_trasc.Name = "l_temp_trasc";
            this.l_temp_trasc.Size = new System.Drawing.Size(93, 13);
            this.l_temp_trasc.TabIndex = 1;
            this.l_temp_trasc.Text = "Posizione video: 0";
            // 
            // l_vel
            // 
            this.l_vel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_vel.AutoSize = true;
            this.l_vel.Location = new System.Drawing.Point(6, 18);
            this.l_vel.Name = "l_vel";
            this.l_vel.Size = new System.Drawing.Size(57, 13);
            this.l_vel.TabIndex = 0;
            this.l_vel.Text = "Velocità: 0";
            // 
            // tab_tna
            // 
            this.tab_tna.AllowDrop = true;
            this.tab_tna.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_tna.Controls.Add(this.tab_autohardsubber);
            this.tab_tna.Controls.Add(this.tab_log);
            this.tab_tna.Location = new System.Drawing.Point(12, 119);
            this.tab_tna.Name = "tab_tna";
            this.tab_tna.SelectedIndex = 0;
            this.tab_tna.Size = new System.Drawing.Size(1131, 446);
            this.tab_tna.TabIndex = 11;
            // 
            // tab_autohardsubber
            // 
            this.tab_autohardsubber.AllowDrop = true;
            this.tab_autohardsubber.Controls.Add(this.tb_help);
            this.tab_autohardsubber.Controls.Add(this.DGV_video);
            this.tab_autohardsubber.Location = new System.Drawing.Point(4, 22);
            this.tab_autohardsubber.Name = "tab_autohardsubber";
            this.tab_autohardsubber.Padding = new System.Windows.Forms.Padding(3);
            this.tab_autohardsubber.Size = new System.Drawing.Size(1123, 420);
            this.tab_autohardsubber.TabIndex = 0;
            this.tab_autohardsubber.Text = "Lista files e impostazioni (Totale files: 0)";
            this.tab_autohardsubber.UseVisualStyleBackColor = true;
            // 
            // tb_help
            // 
            this.tb_help.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_help.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tb_help.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_help.Enabled = false;
            this.tb_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_help.Location = new System.Drawing.Point(278, 160);
            this.tb_help.Multiline = true;
            this.tb_help.Name = "tb_help";
            this.tb_help.ReadOnly = true;
            this.tb_help.Size = new System.Drawing.Size(565, 94);
            this.tb_help.TabIndex = 5;
            this.tb_help.Text = "Per aggiungere file o cartelle,\r\nusare i pulsanti in alto o trascinarli nella lis" +
    "ta\r\ntramite drag&drop.";
            this.tb_help.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DGV_video
            // 
            this.DGV_video.AllowDrop = true;
            this.DGV_video.AllowUserToAddRows = false;
            this.DGV_video.AllowUserToResizeColumns = false;
            this.DGV_video.AllowUserToResizeRows = false;
            this.DGV_video.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_video.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_video.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.input,
            this.compatibilita,
            this.risoluz,
            this.qualita,
            this.stato,
            this.percorso_orig});
            this.DGV_video.ContextMenuStrip = this.tasto_destro_files;
            this.DGV_video.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV_video.Location = new System.Drawing.Point(6, 6);
            this.DGV_video.Name = "DGV_video";
            this.DGV_video.RowHeadersWidth = 35;
            this.DGV_video.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_video.Size = new System.Drawing.Size(1111, 408);
            this.DGV_video.TabIndex = 2;
            this.DGV_video.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_video_CellValueChanged);
            this.DGV_video.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_video_CurrentCellDirtyStateChanged);
            this.DGV_video.DragDrop += new System.Windows.Forms.DragEventHandler(this.DGV_video_DragDrop);
            this.DGV_video.DragEnter += new System.Windows.Forms.DragEventHandler(this.DGV_video_DragEnter);
            // 
            // input
            // 
            this.input.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.input.HeaderText = "File video";
            this.input.Name = "input";
            this.input.ReadOnly = true;
            this.input.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.input.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.input.Width = 52;
            // 
            // compatibilita
            // 
            this.compatibilita.HeaderText = "Compatibilità";
            this.compatibilita.Items.AddRange(new object[] {
            "Bluray AAC",
            "Bluray AC3",
            "Remux MP4",
            "Remux MKV"});
            this.compatibilita.MinimumWidth = 185;
            this.compatibilita.Name = "compatibilita";
            this.compatibilita.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.compatibilita.Width = 185;
            // 
            // risoluz
            // 
            this.risoluz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.risoluz.HeaderText = "Risoluzione";
            this.risoluz.Items.AddRange(new object[] {
            "1080p",
            "900p",
            "720p",
            "576p",
            "480p",
            "396p"});
            this.risoluz.Name = "risoluz";
            this.risoluz.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.risoluz.Width = 67;
            // 
            // qualita
            // 
            this.qualita.HeaderText = "Qualità";
            this.qualita.Items.AddRange(new object[] {
            "Altissima",
            "Alta",
            "Medio-alta",
            "Media",
            "Medio-bassa",
            "Bassa",
            "Bassissima",
            "Bozza"});
            this.qualita.Name = "qualita";
            this.qualita.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.qualita.Width = 80;
            // 
            // stato
            // 
            this.stato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.stato.DefaultCellStyle = dataGridViewCellStyle4;
            this.stato.HeaderText = "Stato";
            this.stato.MinimumWidth = 120;
            this.stato.Name = "stato";
            this.stato.ReadOnly = true;
            this.stato.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.stato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stato.Width = 120;
            // 
            // percorso_orig
            // 
            this.percorso_orig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.percorso_orig.HeaderText = "Percorso originale";
            this.percorso_orig.Name = "percorso_orig";
            this.percorso_orig.ReadOnly = true;
            this.percorso_orig.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.percorso_orig.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.percorso_orig.Width = 87;
            // 
            // tab_log
            // 
            this.tab_log.Controls.Add(this.rtb_log);
            this.tab_log.Location = new System.Drawing.Point(4, 22);
            this.tab_log.Name = "tab_log";
            this.tab_log.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log.Size = new System.Drawing.Size(1123, 420);
            this.tab_log.TabIndex = 1;
            this.tab_log.Text = "LOG";
            this.tab_log.UseVisualStyleBackColor = true;
            // 
            // rtb_log
            // 
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Location = new System.Drawing.Point(3, 3);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(1117, 414);
            this.rtb_log.TabIndex = 0;
            this.rtb_log.Text = "";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(330, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 86);
            this.button2.TabIndex = 16;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(493, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(10, 86);
            this.button5.TabIndex = 17;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // ll_icons
            // 
            this.ll_icons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ll_icons.AutoSize = true;
            this.ll_icons.Location = new System.Drawing.Point(1044, 27);
            this.ll_icons.Name = "ll_icons";
            this.ll_icons.Size = new System.Drawing.Size(99, 17);
            this.ll_icons.TabIndex = 19;
            this.ll_icons.TabStop = true;
            this.ll_icons.Text = "http://dryicons.com";
            this.ll_icons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_icons.UseCompatibleTextRendering = true;
            this.ll_icons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_icons_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(997, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Icons by";
            // 
            // apri_video
            // 
            this.apri_video.Filter = "File video supportati| *.mkv;*.MKV;*.mp4;*.MP4;*.m2ts;*.M2TS;*.ts;*.TS;*.avi;*.AV" +
    "I| File MKV|*.mkv;*.MKV|File MP4|*.mp4;*.MP4|File M2TS|*.m2ts;*.M2TS|File TS|*.t" +
    "s;*.TS|File AVI|*.avi;*.AVI";
            this.apri_video.Multiselect = true;
            this.apri_video.RestoreDirectory = true;
            this.apri_video.Title = "Aggiungi un video";
            // 
            // apri_cartella
            // 
            this.apri_cartella.Description = "Seleziona una cartella";
            this.apri_cartella.ShowNewFolderButton = false;
            // 
            // timer_tempo
            // 
            this.timer_tempo.Interval = 1000;
            this.timer_tempo.Tick += new System.EventHandler(this.timer_tempo_Tick);
            // 
            // tt_encode
            // 
            this.tt_encode.AutoPopDelay = 7500;
            this.tt_encode.InitialDelay = 500;
            this.tt_encode.IsBalloon = true;
            this.tt_encode.ReshowDelay = 100;
            this.tt_encode.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tt_encode.ToolTipTitle = "Riquadro codifica/remux";
            // 
            // barra_stato
            // 
            this.barra_stato.Location = new System.Drawing.Point(0, 639);
            this.barra_stato.Name = "barra_stato";
            this.barra_stato.Size = new System.Drawing.Size(1155, 22);
            this.barra_stato.TabIndex = 23;
            // 
            // pb_tot
            // 
            this.pb_tot.Name = "pb_tot";
            this.pb_tot.Size = new System.Drawing.Size(300, 18);
            // 
            // ts_perc
            // 
            this.ts_perc.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ts_perc.Name = "ts_perc";
            this.ts_perc.Size = new System.Drawing.Size(42, 19);
            this.ts_perc.Text = "0,00%";
            // 
            // ts_avanz
            // 
            this.ts_avanz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_avanz.Name = "ts_avanz";
            this.ts_avanz.Size = new System.Drawing.Size(207, 19);
            this.ts_avanz.Text = "Avanzamento elaborazione - Nessuno";
            this.ts_avanz.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // b_agg_files
            // 
            this.b_agg_files.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_agg_files.Image = ((System.Drawing.Image)(resources.GetObject("b_agg_files.Image")));
            this.b_agg_files.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_agg_files.Location = new System.Drawing.Point(12, 27);
            this.b_agg_files.Name = "b_agg_files";
            this.b_agg_files.Size = new System.Drawing.Size(100, 86);
            this.b_agg_files.TabIndex = 12;
            this.b_agg_files.Text = "Aggiungi video";
            this.b_agg_files.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_agg_files.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_agg_files.UseVisualStyleBackColor = true;
            this.b_agg_files.Click += new System.EventHandler(this.b_agg_files_Click);
            // 
            // b_agg_cart
            // 
            this.b_agg_cart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_agg_cart.Image = ((System.Drawing.Image)(resources.GetObject("b_agg_cart.Image")));
            this.b_agg_cart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_agg_cart.Location = new System.Drawing.Point(118, 27);
            this.b_agg_cart.Name = "b_agg_cart";
            this.b_agg_cart.Size = new System.Drawing.Size(100, 86);
            this.b_agg_cart.TabIndex = 15;
            this.b_agg_cart.Text = "Aggiungi cartelle";
            this.b_agg_cart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_agg_cart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_agg_cart.UseVisualStyleBackColor = true;
            this.b_agg_cart.Click += new System.EventHandler(this.b_agg_cart_Click);
            // 
            // b_rimuovi
            // 
            this.b_rimuovi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_rimuovi.Image = ((System.Drawing.Image)(resources.GetObject("b_rimuovi.Image")));
            this.b_rimuovi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_rimuovi.Location = new System.Drawing.Point(346, 27);
            this.b_rimuovi.Name = "b_rimuovi";
            this.b_rimuovi.Size = new System.Drawing.Size(141, 86);
            this.b_rimuovi.TabIndex = 14;
            this.b_rimuovi.Text = "Rimuovi files selezionati";
            this.b_rimuovi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_rimuovi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_rimuovi.UseVisualStyleBackColor = true;
            this.b_rimuovi.Click += new System.EventHandler(this.B_rimuovi_Click);
            // 
            // b_avvia
            // 
            this.b_avvia.Image = ((System.Drawing.Image)(resources.GetObject("b_avvia.Image")));
            this.b_avvia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_avvia.Location = new System.Drawing.Point(509, 27);
            this.b_avvia.Name = "b_avvia";
            this.b_avvia.Size = new System.Drawing.Size(100, 86);
            this.b_avvia.TabIndex = 5;
            this.b_avvia.Text = "AVVIA";
            this.b_avvia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_avvia.UseVisualStyleBackColor = true;
            this.b_avvia.Click += new System.EventHandler(this.b_avvia_Click);
            // 
            // b_pause
            // 
            this.b_pause.Enabled = false;
            this.b_pause.Image = ((System.Drawing.Image)(resources.GetObject("b_pause.Image")));
            this.b_pause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_pause.Location = new System.Drawing.Point(615, 27);
            this.b_pause.Name = "b_pause";
            this.b_pause.Size = new System.Drawing.Size(62, 67);
            this.b_pause.TabIndex = 22;
            this.b_pause.Text = "PAUSA";
            this.b_pause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_pause.UseVisualStyleBackColor = true;
            this.b_pause.Click += new System.EventHandler(this.b_pause_Click);
            // 
            // b_incolla
            // 
            this.b_incolla.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_incolla.Image = ((System.Drawing.Image)(resources.GetObject("b_incolla.Image")));
            this.b_incolla.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_incolla.Location = new System.Drawing.Point(224, 27);
            this.b_incolla.Name = "b_incolla";
            this.b_incolla.Size = new System.Drawing.Size(100, 86);
            this.b_incolla.TabIndex = 21;
            this.b_incolla.Text = "Incolla";
            this.b_incolla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_incolla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_incolla.UseVisualStyleBackColor = true;
            this.b_incolla.Click += new System.EventHandler(this.b_incolla_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem7,
            this.toolStripMenuItem14,
            this.toolStripMenuItem29,
            this.toolStripMenuItem32});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripSeparator3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "File";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(339, 22);
            this.toolStripMenuItem3.Text = "Apri cartella logs";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ApriCartellaLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(336, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(339, 22);
            this.toolStripMenuItem4.Text = "Salva impostazioni";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.salvaImpostazioniToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(339, 22);
            this.toolStripMenuItem5.Text = "Ripristina le impostazioni e il programma";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ripristinaImpostazioniToolStripMenuItem3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(336, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(339, 22);
            this.toolStripMenuItem6.Text = "Esci";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem10,
            this.toolStripMenuItem12});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem7.Text = "Modifica";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2,
            this.toolStripMenuItem9});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem8.Text = "Compatibilità";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "PS3",
            "Xbox360",
            "Bluray AAC",
            "Bluray AC3",
            "Remux MP4",
            "Remux MKV",
            "Streaming HTML5 H.264",
            "XviD MP3",
            "Workraw",
            "Streaming HTML5 H.265"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(190, 23);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(250, 22);
            this.toolStripMenuItem9.Text = "Conferma";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.confermaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox3,
            this.toolStripMenuItem11});
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem10.Text = "Risoluzione";
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox3.Items.AddRange(new object[] {
            "1080p",
            "900p",
            "720p",
            "576p",
            "480p",
            "396p"});
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem11.Text = "Conferma";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.confermaToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox4,
            this.toolStripMenuItem13});
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem12.Text = "Qualità";
            // 
            // toolStripComboBox4
            // 
            this.toolStripComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox4.Items.AddRange(new object[] {
            "Altissima",
            "Alta",
            "Medio-alta",
            "Media",
            "Medio-bassa",
            "Bassa",
            "Bassissima",
            "Bozza"});
            this.toolStripComboBox4.Name = "toolStripComboBox4";
            this.toolStripComboBox4.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem13.Text = "Conferma";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.confermaToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem21,
            this.toolStripSeparator9,
            this.toolStripMenuItem26});
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem14.Text = "Strumenti";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17});
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(306, 22);
            this.toolStripMenuItem16.Text = "Pulisci lista";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20});
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItem17.Text = "Rimuovi tutti i file con esito...";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem18.Text = "Ok";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem19.Text = "Fermato";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem20.Text = "Errore";
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem22,
            this.toolStripMenuItem23,
            this.toolStripMenuItem24,
            this.toolStripMenuItem25});
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(306, 22);
            this.toolStripMenuItem21.Text = "Cancella i files nella lista";
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem22.Text = "Tutti";
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem23.Text = "Completati";
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem24.Text = "Fermati";
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem25.Text = "Con errori";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(303, 6);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem27,
            this.toolStripMenuItem28});
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(306, 22);
            this.toolStripMenuItem26.Text = "Integra con il menù contestuale di Windows";
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem27.Text = "Crea";
            // 
            // toolStripMenuItem28
            // 
            this.toolStripMenuItem28.Name = "toolStripMenuItem28";
            this.toolStripMenuItem28.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem28.Text = "Cancella";
            // 
            // toolStripMenuItem29
            // 
            this.toolStripMenuItem29.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem30,
            this.toolStripMenuItem31});
            this.toolStripMenuItem29.Name = "toolStripMenuItem29";
            this.toolStripMenuItem29.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuItem29.Text = "Impostazioni";
            // 
            // toolStripMenuItem30
            // 
            this.toolStripMenuItem30.Name = "toolStripMenuItem30";
            this.toolStripMenuItem30.Size = new System.Drawing.Size(359, 22);
            this.toolStripMenuItem30.Text = "Rimuovi i files sorgenti dopo una corretta conversione";
            // 
            // toolStripMenuItem31
            // 
            this.toolStripMenuItem31.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox5});
            this.toolStripMenuItem31.Name = "toolStripMenuItem31";
            this.toolStripMenuItem31.Size = new System.Drawing.Size(359, 22);
            this.toolStripMenuItem31.Text = "Alla fine della coda di lavoro";
            // 
            // toolStripComboBox5
            // 
            this.toolStripComboBox5.AutoCompleteCustomSource.AddRange(new string[] {
            "Non fare niente",
            "Chiudi l\'applicazione",
            "Stand-by",
            "Spegni il PC"});
            this.toolStripComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox5.Items.AddRange(new object[] {
            "Non fare niente",
            "Chiudi l\'applicazione",
            "Stand-by",
            "Spegni il PC"});
            this.toolStripComboBox5.Name = "toolStripComboBox5";
            this.toolStripComboBox5.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem33});
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem32.Text = "?";
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem33.Text = "Info";
            this.toolStripMenuItem33.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // PAVideoEncoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1155, 661);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.barra_stato);
            this.Controls.Add(this.ll_icons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_agg_files);
            this.Controls.Add(this.b_agg_cart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.b_rimuovi);
            this.Controls.Add(this.b_avvia);
            this.Controls.Add(this.b_pause);
            this.Controls.Add(this.tab_tna);
            this.Controls.Add(this.b_incolla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1171, 700);
            this.Name = "PAVideoEncoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAVE - PA Video Encoder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FVE_FormClosing);
            this.tasto_destro_files.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_tna.ResumeLayout(false);
            this.tab_autohardsubber.ResumeLayout(false);
            this.tab_autohardsubber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_video)).EndInit();
            this.tab_log.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_vel;
        private System.Windows.Forms.Label l_temp_trasc;
        private System.Windows.Forms.Label l_dim_att;
        private System.Windows.Forms.Label l_dim_prev;
        private System.Windows.Forms.ContextMenuStrip tasto_destro_files;
        private System.Windows.Forms.ToolStripMenuItem rimuoviIFileSelezionatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compatibilitàToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmb_compatibilita;
        private System.Windows.Forms.ToolStripMenuItem confermaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualitàToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmb_qualita;
        private System.Windows.Forms.ToolStripMenuItem confermaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem strumentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem IncollaToolStripMenuItem;
        private System.Windows.Forms.TabControl tab_tna;
        private System.Windows.Forms.TabPage tab_autohardsubber;
        private System.Windows.Forms.DataGridView DGV_video;
        private System.Windows.Forms.TabPage tab_log;
        private System.Windows.Forms.ToolStripMenuItem salvaImpostazioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Button b_agg_files;
        private System.Windows.Forms.Button b_rimuovi;
        private System.Windows.Forms.Button b_agg_cart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.LinkLabel ll_icons;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.OpenFileDialog apri_video;
        public System.Windows.Forms.FolderBrowserDialog apri_cartella;
        private System.Windows.Forms.Button b_incolla;
        private System.Windows.Forms.TextBox tb_help;
        private System.Windows.Forms.ToolStripMenuItem ripristinaImpostazioniToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem impostazioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rimuoviTuttiIFileConEsitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroreToolStripMenuItem;
        private System.Windows.Forms.Label l_tempo_trasc;
        private System.Windows.Forms.Label l_temp_rim;
        private System.Windows.Forms.Timer timer_tempo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem integraConIlMenùContestualeDiWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancellaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancellaIFilesNellaListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tuttiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conErroriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rimuoviIFilesSorgentiDopoUnaCorrettaConversioneToolStripMenuItem;
        private System.Windows.Forms.Button b_pause;
        private System.Windows.Forms.ToolStripMenuItem allaFineDellaCodaDiLavoroToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolTip tt_encode;
        private System.Windows.Forms.Button b_avvia;
        private System.Windows.Forms.ToolStripMenuItem risoluzioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmb_risoluz;
        private System.Windows.Forms.ToolStripMenuItem confermaToolStripMenuItem2;
        private System.Windows.Forms.StatusStrip barra_stato;
        private System.Windows.Forms.ToolStripStatusLabel ts_avanz;
        private System.Windows.Forms.ToolStripProgressBar pb_tot;
        private System.Windows.Forms.ToolStripStatusLabel ts_perc;
        private System.Windows.Forms.ToolStripMenuItem apriCartellaLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn input;
        private System.Windows.Forms.DataGridViewComboBoxColumn compatibilita;
        private System.Windows.Forms.DataGridViewComboBoxColumn risoluz;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualita;
        private System.Windows.Forms.DataGridViewTextBoxColumn stato;
        private System.Windows.Forms.DataGridViewTextBoxColumn percorso_orig;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem23;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem24;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem26;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem27;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem28;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem29;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem30;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem31;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem32;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem33;
    }
}

