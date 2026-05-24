using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PSP : IDisposable
    {
        private short _Codigo;
        private string _Nome_Recebedor;
        private string _CEP;
        private string _UF;
        private string _Cidade;
        private string _Nome_PSP;
        private string _Tipo_Chave;
        private string _Ambiente;
        private string _Chave_PIX;
        private string _Acess_Token;
        private int _Timeout;
        private string _Scopes;
        private string _Pesquisar;
        private byte _QRDinamico;

        public byte QRDinamico
        {
            get { return _QRDinamico; }
            set { _QRDinamico = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        public string Scopes
        {
            get { return _Scopes; }
            set { _Scopes = value; }
        }

        public short Codigo
        { 
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nome_Recebedor
        {
            get { return _Nome_Recebedor; }
            set { _Nome_Recebedor = value; }
        }
        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        public string Nome_PSP
        {
            get { return _Nome_PSP; }
            set { _Nome_PSP = value; }
        }

        public string Tipo_Chave
        {
            get { return _Tipo_Chave; }
            set { _Tipo_Chave = value; }
        }

        public string Ambiente
        {
            get { return _Ambiente; }
            set { _Ambiente = value; }
        }

        public string Chave_PIX
        {
            get { return _Chave_PIX; }
            set { _Chave_PIX = value; }
        }

        public string Acess_Token
        {
            get { return _Acess_Token; }
            set { _Acess_Token = value; }
        }
        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Nome_Recebedor = null;
            _CEP = null;
            _Cidade = null;
            _Nome_PSP = null;
            _Tipo_Chave = null;
            _Ambiente = null;
            _Chave_PIX = null;
            _Acess_Token = null;
            _Timeout = 0;
            _Scopes = null;
            _UF = null;
            _Pesquisar = null;
            _QRDinamico = 0;
        }
    }
}
