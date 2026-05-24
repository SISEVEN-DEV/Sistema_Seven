using System;

namespace DAL
{
    public class Transportador : IDisposable
    {
        private int _Codigo;
        private string _Tipo_Transporte;
        private string _Tipo_Frete;
        private int _Cod_Fornecedor;
        private string _Nome_Fornecedor;
        private string _Veiculo;
        private string _Codigo_ANTT;
        private string _Placa;
        private string _UF;
        private string _Especie;
        private string _Marca;
        private int _Quantidade;
        private string _Numeracao;
        private decimal _Peso_Bruto;
        private decimal _Peso_Liquido;
        private int _Cod_DFe;
        private decimal _Valor_Frete;

        public int Cod_DFe
        {
            get { return _Cod_DFe; }
            set { _Cod_DFe = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Tipo_Transporte
        {
            get { return _Tipo_Transporte; }
            set { _Tipo_Transporte = value; }
        }

        public string Tipo_Frete
        {
            get { return _Tipo_Frete; }
            set { _Tipo_Frete = value; }
        }

        public int Cod_Fornecedor
        {
            get { return _Cod_Fornecedor; }
            set { _Cod_Fornecedor = value; }
        }

        public string Nome_Fornecedor
        {
            get { return _Nome_Fornecedor; }
            set { _Nome_Fornecedor = value; }
        }

        public string Veiculo
        {
            get { return _Veiculo; }
            set { _Veiculo = value; }
        }

        public string Codigo_ANTT
        {
            get { return _Codigo_ANTT; }
            set { _Codigo_ANTT = value; }
        }

        public string Placa
        {
            get { return _Placa; }
            set { _Placa = value; }
        }

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        public string Especie
        {
            get { return _Especie; }
            set { _Especie = value; }
        }

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public int Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public string Numeracao
        {
            get { return _Numeracao; }
            set { _Numeracao = value; }
        }

        public decimal Peso_Bruto
        {
            get { return _Peso_Bruto; }
            set { _Peso_Bruto = value; }
        }

        public decimal Peso_Liquido
        {
            get { return _Peso_Liquido; }
            set { _Peso_Liquido = value; }
        }


        public decimal Valor_Frete
        {
            get { return _Valor_Frete; }
            set { _Valor_Frete = value; }
        }


        public void Dispose()
        {
            _Cod_DFe = 0;
            _Codigo = 0;
            _Tipo_Transporte = null;
            _Tipo_Frete = null;
            _Cod_Fornecedor = 0;
            _Nome_Fornecedor = null;
            _Veiculo = null;
            _Codigo_ANTT = null;
            _Placa = null;
            _UF = null;
            _Especie = null;
            _Marca = null;
            _Quantidade = 0;
            _Numeracao = null;
            _Peso_Bruto = 0;
            _Peso_Liquido = 0;
            _Valor_Frete = 0;
        }
    }
}
