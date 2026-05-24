using System;

namespace DAL
{
    public class Pagamento_Devolucao : IDisposable
    {
        private int _Codigo;
        private short _Cod_Pagamento;
        private short _Cod_Item_Devolucao;
        private string _Tipo;
        private decimal _Valor_Devolucao;
        private string _Data_Devolucao;
        private string _Hora_Devolucao;
        private int _Cod_Devolucao;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Item_Devolucao
        {
            get { return _Cod_Item_Devolucao; }
            set { _Cod_Item_Devolucao = value; }
        }

        public short Cod_Pagamento
        {
            get { return _Cod_Pagamento; }
            set { _Cod_Pagamento = value; }
        }

        public short Cod_Usuario
        {
            get { return _Cod_Usuario; }
            set { _Cod_Usuario = value; }
        }

        public string Nome_Usuario
        {
            get { return _Nome_Usuario; }
            set { _Nome_Usuario = value; }
        }

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public decimal Valor_Devolucao
        {
            get { return _Valor_Devolucao; }
            set { _Valor_Devolucao = value; }
        }

        public string Data_Devolucao
        {
            get { return _Data_Devolucao; }
            set { _Data_Devolucao = value; }
        }

        public string Hora_Devolucao
        {
            get { return _Hora_Devolucao; }
            set { _Hora_Devolucao = value; }
        }

        public int Cod_Devolucao
        {
            get { return _Cod_Devolucao; }
            set { _Cod_Devolucao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Cod_Item_Devolucao = 0;
            _Tipo = null;
            _Valor_Devolucao = 0;
            _Data_Devolucao = null;
            _Hora_Devolucao = null;
            _Cod_Devolucao = 0;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Cod_PDV_Computador = 0;
        }
    }
}
