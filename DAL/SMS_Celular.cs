using System;

namespace DAL
{
    public class SMS_Celular : IDisposable
    {
        private int _Codigo;
        private int _Cod_SMS;
        private string _Celular;
        private short _Cod_Ordem;
        private string _Tipo_Destinatario;
        private int _Cod_Destinatario;
        private string _Nome_Destinatario;
        private byte _Status_SMS;

        public byte Status_SMS
        {
            get { return _Status_SMS; }
            set { _Status_SMS = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_SMS
        {
            get { return _Cod_SMS; }
            set { _Cod_SMS = value; }
        }

        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        public short Cod_Ordem
        {
            get { return _Cod_Ordem; }
            set { _Cod_Ordem = value; }
        }

        public string Tipo_Destinario
        {
            get { return _Tipo_Destinatario; }
            set { _Tipo_Destinatario = value; }
        }

        public int Cod_Destinatario
        {
            get { return _Cod_Destinatario; }
            set { _Cod_Destinatario = value; }
        }

        public string Nome_Destinatario
        {
            get { return _Nome_Destinatario; }
            set { _Nome_Destinatario = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_SMS = 0;
            _Celular = null;
            _Cod_Ordem = 0;
            _Tipo_Destinatario = null;
            _Cod_Destinatario = 0;
            _Nome_Destinatario = null;
            _Status_SMS = 0;
        }
    }
}
