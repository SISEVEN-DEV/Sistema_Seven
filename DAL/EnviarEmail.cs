using System;

namespace DAL
{
    public class EnviarEmail : IDisposable
    {
        private string _Smtp_Hotmail_Outlook;
        private int _Porta_Hotmail_Outlook;
        private string _Smtp_Gmail;
        private int _Porta_Gmail;
        private string _Smtp_Yahoo;
        private int _Porta_Yahoo;
        private string _Prioridade;
        private byte _SSL;
        private byte _Html;

        public byte Html
        {
            get { return _Html; }
            set { _Html = value; }
        }

        public string Smtp_Hotmail_Outlook
        {
            get { return _Smtp_Hotmail_Outlook; }
            set { _Smtp_Hotmail_Outlook = value; }
        }

        public int Porta_Hotmail_Outlook
        {
            get { return _Porta_Hotmail_Outlook; }
            set { _Porta_Hotmail_Outlook = value; }
        }

        public string Smtp_Gmail
        {
            get { return _Smtp_Gmail; }
            set { _Smtp_Gmail = value; }
        }

        public int Porta_Gmail
        {
            get { return _Porta_Gmail; }
            set { _Porta_Gmail = value; }
        }

        public string Smtp_Yahoo
        {
            get { return _Smtp_Yahoo; }
            set { _Smtp_Yahoo = value; }
        }

        public int Porta_Yahoo
        {
            get { return _Porta_Yahoo; }
            set { _Porta_Yahoo = value; }
        }

        public string Prioridade
        {
            get { return _Prioridade; }
            set { _Prioridade = value; }
        }

        public byte SSL
        {
            get { return _SSL; }
            set { _SSL = value; }
        }

        public void Dispose()
        {
            _Smtp_Hotmail_Outlook = null;
            _Porta_Hotmail_Outlook = 0;
            _Smtp_Gmail = null;
            _Porta_Gmail = 0;
            _Smtp_Yahoo = null;
            _Porta_Yahoo = 0;
            _Prioridade = null;
            _SSL = 0;
            _Html = 0;
        }
    }
}
