using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace PA_Video_Encoder
{
    public partial class About : Form
    {
        public About(String titolo, String versione)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT", false);
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            l_titolo.Text = titolo;
            l_vers.Text = "Versione: " + versione;
            this.Text = "Informazioni - " + titolo;
        }
    }
}
