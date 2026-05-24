using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmInfImpressao : Form
    {
        public FrmInfImpressao(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmInfImpressao_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao iniciado.");
                }
                //
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cbbImpressoras.Items.Add(printer);
                }
                //    
                if (_Formulario == 0)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 1)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 2)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 3)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 4)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Checked = false;
                }
                else if (_Formulario == 5)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 6)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 7)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 8)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 9)
                {
                    //VAGO
                }
                else if (_Formulario == 10)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 11)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 12)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(58mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    chkbMostrarLogo.Enabled = false;
                    chkbMostrarLogo.Checked = false;
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 13)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 14)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 15)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 16)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 17)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 18)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 19)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 20)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 21)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 22)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 23)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Enabled = false;
                    chkbMostrarLogo.Checked = false;
                }
                else if (_Formulario == 24)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Enabled = false;
                    chkbMostrarLogo.Checked = false;
                }
                else if (_Formulario == 25)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 26)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 27)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 28)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(58mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 29)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(58mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 30)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 31)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 32)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 33)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 34)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 35)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 36)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 37)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 38)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 39)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 40)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 41)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 42)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 43)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 44)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 45)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Checked = true;
                }
                else if (_Formulario == 46)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(58mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 47)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(58mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Enabled = false;
                    chkbMostrarLogo.Checked = false;
                }
                else if (_Formulario == 48)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Enabled = false;
                    chkbMostrarLogo.Checked = false;
                }
                else if (_Formulario == 49)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 50)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Checked = true;
                }
                else if (_Formulario == 51)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Checked = true;
                }
                else if (_Formulario == 52)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                    chkbMostrarLogo.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInfImpressao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInfImpressao.");
                }
            }
        }

        private void cbbTipoImpressao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpressao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImpressoras_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImpressoras_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarLogo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarLogo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpressao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpressao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImpressoras_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImpressoras_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNCopia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnGerarPDF.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void cbbTipoImpressao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbImpressoras.Enabled == false)
                {
                    btnGerarPDF.Select();
                }
                else
                {
                    cbbImpressoras.Select();
                }
            }
        }

        private void cbbImpressoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtNCopia.Enabled == true)
                {
                    txtNCopia.Select();
                }
                else
                {
                    btnGerarPDF.Select();
                }
            }
        }

        private void txtNCopia_Enter(object sender, EventArgs e)
        {
            txtNCopia.BackColor = Color.LightBlue;
        }

        private void txtNCopia_Leave(object sender, EventArgs e)
        {
            if (txtNCopia.Text.Contains("'") || txtNCopia.Text.Contains(";") || txtNCopia.Text.Contains("=") || txtNCopia.Text.Contains("-"))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNCopia.Text = null;
                txtNCopia.Select();
            }
            if (txtNCopia.Text == "0")
            {
                MessageBox.Show("Valor não permitido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtNCopia.Text = null;
                txtNCopia.Select();
            }
            txtNCopia.BackColor = Color.White;
        }

        private void FrmInfImpressao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmInfImpressao_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao foi finalizado.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao foi finalizado.");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                btnGerarPDF.Select();
                if (_Formulario == 0)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasReceber._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasReceber._Impressora = cbbImpressoras.Text;
                        bllContasReceber._Numero_Copias = txtNCopia.Text;
                        bllContasReceber._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 1)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasReceber._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasReceber._Impressora = cbbImpressoras.Text;
                        bllContasReceber._Numero_Copias = txtNCopia.Text;
                        bllContasReceber._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 2)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasReceber._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasReceber._Impressora = cbbImpressoras.Text;
                        bllContasReceber._Numero_Copias = txtNCopia.Text;
                        bllContasReceber._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 3)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasReceber._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasReceber._Impressora = cbbImpressoras.Text;
                        bllContasReceber._Numero_Copias = txtNCopia.Text;
                        bllContasReceber._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 4)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasPagar._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasPagar._Impressora = cbbImpressoras.Text;
                        bllContasPagar._Numero_Copias = txtNCopia.Text;
                        bllContasPagar._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 5)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasPagar._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasPagar._Impressora = cbbImpressoras.Text;
                        bllContasPagar._Numero_Copias = txtNCopia.Text;
                        bllContasPagar._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 6)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasPagar._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasPagar._Impressora = cbbImpressoras.Text;
                        bllContasPagar._Numero_Copias = txtNCopia.Text;
                        bllContasPagar._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 7)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllVenda._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllVenda._Impressora = cbbImpressoras.Text;
                        bllVenda._Numero_Copias = txtNCopia.Text;
                        bllVenda._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 8)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllVenda._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllVenda._Impressora = cbbImpressoras.Text;
                        bllVenda._Numero_Copias = txtNCopia.Text;
                        bllVenda._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 9)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllVenda._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllVenda._Impressora = cbbImpressoras.Text;
                        bllVenda._Numero_Copias = txtNCopia.Text;
                        bllVenda._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 10)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllProduto._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllProduto._Impressora = cbbImpressoras.Text;
                        bllProduto._Numero_Copias = txtNCopia.Text;
                        bllProduto._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 11)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllProduto._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllProduto._Impressora = cbbImpressoras.Text;
                        bllProduto._Numero_Copias = txtNCopia.Text;
                        bllProduto._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 12)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllHistCaixa._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllHistCaixa._Impressora = cbbImpressoras.Text;
                        bllHistCaixa._Numero_Copias = txtNCopia.Text;
                        bllHistCaixa._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 13)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSaidasProdutos._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSaidasProdutos._Impressora = cbbImpressoras.Text;
                        bllSaidasProdutos._Numero_Copias = txtNCopia.Text;
                        bllSaidasProdutos._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 14)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllEntradasProdutos._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllEntradasProdutos._Impressora = cbbImpressoras.Text;
                        bllEntradasProdutos._Numero_Copias = txtNCopia.Text;
                        bllEntradasProdutos._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 15)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllFluxoCaixa._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllFluxoCaixa._Impressora = cbbImpressoras.Text;
                        bllFluxoCaixa._Numero_Copias = txtNCopia.Text;
                        bllFluxoCaixa._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 16)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSangriaSuprimento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSangriaSuprimento._Impressora = cbbImpressoras.Text;
                        bllSangriaSuprimento._Numero_Copias = txtNCopia.Text;
                        bllSangriaSuprimento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 17)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSangriaSuprimento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSangriaSuprimento._Impressora = cbbImpressoras.Text;
                        bllSangriaSuprimento._Numero_Copias = txtNCopia.Text;
                        bllSangriaSuprimento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 18)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllDevolucao._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllDevolucao._Impressora = cbbImpressoras.Text;
                        bllDevolucao._Numero_Copias = txtNCopia.Text;
                        bllDevolucao._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 19)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOrcamento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOrcamento._Impressora = cbbImpressoras.Text;
                        bllOrcamento._Numero_Copias = txtNCopia.Text;
                        bllOrcamento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 20)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllClieCons._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllClieCons._Impressora = cbbImpressoras.Text;
                        bllClieCons._Numero_Copias = txtNCopia.Text;
                        bllClieCons._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 21)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllClieCons._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllClieCons._Impressora = cbbImpressoras.Text;
                        bllClieCons._Numero_Copias = txtNCopia.Text;
                        bllClieCons._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 22)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllProduto._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllProduto._Impressora = cbbImpressoras.Text;
                        bllProduto._Numero_Copias = txtNCopia.Text;
                        bllProduto._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 23)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllProduto._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllProduto._Impressora = cbbImpressoras.Text;
                        bllProduto._Numero_Copias = txtNCopia.Text;
                        bllProduto._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 24)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllProduto._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllProduto._Impressora = cbbImpressoras.Text;
                        bllProduto._Numero_Copias = txtNCopia.Text;
                        bllProduto._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 25)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllFormaPagamento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllFormaPagamento._Impressora = cbbImpressoras.Text;
                        bllFormaPagamento._Numero_Copias = txtNCopia.Text;
                        bllFormaPagamento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 26)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllFornecedor._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllFornecedor._Impressora = cbbImpressoras.Text;
                        bllFornecedor._Numero_Copias = txtNCopia.Text;
                        bllFornecedor._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 27)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllFornecedor._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllFornecedor._Impressora = cbbImpressoras.Text;
                        bllFornecedor._Numero_Copias = txtNCopia.Text;
                        bllFornecedor._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 28)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllVenda._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllVenda._Impressora = cbbImpressoras.Text;
                        bllVenda._Numero_Copias = txtNCopia.Text;
                        bllVenda._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 29)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOrcamento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOrcamento._Impressora = cbbImpressoras.Text;
                        bllOrcamento._Numero_Copias = txtNCopia.Text;
                        bllOrcamento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 30)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllGrupo._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllGrupo._Impressora = cbbImpressoras.Text;
                        bllGrupo._Numero_Copias = txtNCopia.Text;
                        bllGrupo._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 31)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllGrupo._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllGrupo._Impressora = cbbImpressoras.Text;
                        bllGrupo._Numero_Copias = txtNCopia.Text;
                        bllGrupo._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 32)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSubGrupo._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSubGrupo._Impressora = cbbImpressoras.Text;
                        bllSubGrupo._Numero_Copias = txtNCopia.Text;
                        bllSubGrupo._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 33)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSubGrupo._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSubGrupo._Impressora = cbbImpressoras.Text;
                        bllSubGrupo._Numero_Copias = txtNCopia.Text;
                        bllSubGrupo._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 34)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllFuncionario._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllFuncionario._Impressora = cbbImpressoras.Text;
                        bllFuncionario._Numero_Copias = txtNCopia.Text;
                        bllFuncionario._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 35)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllFuncionario._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllFuncionario._Impressora = cbbImpressoras.Text;
                        bllFuncionario._Numero_Copias = txtNCopia.Text;
                        bllFuncionario._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 36)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllAbert_Fech_Caixa._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllAbert_Fech_Caixa._Impressora = cbbImpressoras.Text;
                        bllAbert_Fech_Caixa._Numero_Copias = txtNCopia.Text;
                        bllAbert_Fech_Caixa._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 37)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllUsuario._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllUsuario._Impressora = cbbImpressoras.Text;
                        bllUsuario._Numero_Copias = txtNCopia.Text;
                        bllUsuario._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 38)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllMarca._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllMarca._Impressora = cbbImpressoras.Text;
                        bllMarca._Numero_Copias = txtNCopia.Text;
                        bllMarca._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 39)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllMarca._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllMarca._Impressora = cbbImpressoras.Text;
                        bllMarca._Numero_Copias = txtNCopia.Text;
                        bllMarca._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 40)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllDevolucao._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllDevolucao._Impressora = cbbImpressoras.Text;
                        bllDevolucao._Numero_Copias = txtNCopia.Text;
                        bllDevolucao._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 41)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllControleCheque._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllControleCheque._Impressora = cbbImpressoras.Text;
                        bllControleCheque._Numero_Copias = txtNCopia.Text;
                        bllControleCheque._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 42)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllDFe._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllDFe._Impressora = cbbImpressoras.Text;
                        bllDFe._Numero_Copias = txtNCopia.Text;
                        bllDFe._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 43)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllAniversariante._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllAniversariante._Impressora = cbbImpressoras.Text;
                        bllAniversariante._Numero_Copias = txtNCopia.Text;
                        bllAniversariante._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 44)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllValidade._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllValidade._Impressora = cbbImpressoras.Text;
                        bllValidade._Numero_Copias = txtNCopia.Text;
                        bllValidade._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 45)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOS._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOS._Impressora = cbbImpressoras.Text;
                        bllOS._Numero_Copias = txtNCopia.Text;
                        bllOS._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 46)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOS._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOS._Impressora = cbbImpressoras.Text;
                        bllOS._Numero_Copias = txtNCopia.Text;
                        bllOS._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 47)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllPSP._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllPSP._Impressora = cbbImpressoras.Text;
                        bllPSP._Numero_Copias = txtNCopia.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 48)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSangriaSuprimento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSangriaSuprimento._Impressora = cbbImpressoras.Text;
                        bllSangriaSuprimento._Numero_Copias = txtNCopia.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 49)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllComissao._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllComissao._Impressora = cbbImpressoras.Text;
                        bllComissao._Numero_Copias = txtNCopia.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 50)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOrcamento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        bllOrcamento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOrcamento._Impressora = cbbImpressoras.Text;
                        bllOrcamento._Numero_Copias = txtNCopia.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 51)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOS._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOS._Impressora = cbbImpressoras.Text;
                        bllOS._Numero_Copias = txtNCopia.Text;
                        bllOS._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 52)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Tipo de impressão >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllClieCons._Tipo_Impressao = cbbTipoImpressao.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImprimir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImprimir.");
                }
                cbbImpressoras.Text = null;
                cbbTipoImpressao.Text = null;
                txtNCopia.Text = null;
                chkbMostrarLogo.Checked = false;
            }
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Tipo de impressão: É o estilo em que o relatório será impresso.\n\n2 - Imprimir em: É onde o usuário seleciona a impressora em que o relatório será impresso.\n\n3 - Número de cópias: Quantidade de folhas serão impressas.\n\n4 - Mostrar logo-marca na impressão: Para mostrar a logo-marca configurada na impressão do relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbTipoImpressao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 1)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 2)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 3)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 4)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 5)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 6)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 7)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 8)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 9)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 10)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 11)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 12)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 13)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 14)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 15)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 16)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 17)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 18)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 19)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 20)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 21)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 22)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 23)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 24)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 25)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 26)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 27)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 28)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 29)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 30)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 31)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 32)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 33)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 34)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 35)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 36)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 37)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 38)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 39)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 40)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 41)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 43)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 44)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 45)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 46)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 47)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 48)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 49)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 50)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 51)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 52)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void chkbMostrarLogo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
