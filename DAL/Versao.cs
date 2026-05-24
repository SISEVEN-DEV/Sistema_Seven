using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Versao : IDisposable
    {
        private byte _Codigo;
        private string _IBPT;
        private string _SQL_Seven;
        private string _Seven_ADM;
        private string _Seven_PDV;
        private string _Seven_Config;
        private string _BLL;
        private string _DAL;
        private string _SQL_Operation;
        private string _SQL_CPF_CNPJ;
        private string _ACBR_LIB;
        private string _Config;
        private string _Sistema_Seven;

        public string SQL_CPF_CNPJ
        {
            get { return _SQL_CPF_CNPJ; }
            set { _SQL_CPF_CNPJ = value; }
        }

        public byte Codigo 
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string SQL_Operation
        {
            get { return _SQL_Operation; }
            set { _SQL_Operation = value; }
        }

        public string IBPT 
        {
            get { return _IBPT; }
            set { _IBPT = value; }
        }

        public string SQL_Seven
        {
            get { return _SQL_Seven; }
            set { _SQL_Seven = value; }
        }

        public string Seven_ADM
        {
            get { return _Seven_ADM; }
            set { _Seven_ADM = value; }
        }

        public string Seven_PDV
        {
            get { return _Seven_PDV; }
            set { _Seven_PDV = value; }
        }

        public string Seven_Config
        {
            get { return _Seven_Config; }
            set { _Seven_Config = value; }
        }

        public string BLL
        {
            get { return _BLL; }
            set { _BLL = value; }
        }

        public string DAL
        {
            get { return _DAL; }
            set { _DAL = value; }
        }

        public string ACBR_LIB
        {
            get { return _ACBR_LIB; }
            set { _ACBR_LIB = value; }
        }

        public string Config
        {
            get { return _Config; }
            set { _Config = value; }
        }

        public string Sistema_Seven
        {
            get { return _Sistema_Seven; }
            set { _Sistema_Seven = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _IBPT = null;
            _SQL_Seven = null;
            _Seven_ADM = null;
            _Seven_PDV = null;
            _Seven_Config = null;
            _BLL = null;
            _DAL = null;
            _SQL_Operation = null;
            _SQL_CPF_CNPJ = null;
            _ACBR_LIB = null;
            _Config = null;
            _Sistema_Seven = null;
        }
    }
}
