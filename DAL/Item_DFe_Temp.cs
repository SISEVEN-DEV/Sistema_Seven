using System;

namespace DAL
{
    public class Item_DFe_Temp : IDisposable
    {
        private int _Codigo;
        private short _Cod_Item;
        private int _Cod_Produto;
        private string _Descricao;
        private string _NCM;
        private string _CEST;
        private string _CST;
        private decimal _Aliquota;
        private string _CSOSN;
        private decimal _Quantidade;
        private decimal _Quantidade_Embalagem;
        private decimal _Valor_Unitario;
        private decimal _Total;
        private decimal _Valor_Desconto;
        private decimal _Valor_Acrescimo;
        private decimal _Valor_Total;
        private string _CFOP;
        private decimal _Valor_Icms;
        private decimal _Valor_Icms_St;
        private decimal _Valor_Base_Calculo;
        private decimal _Valor_Base_Calculo_St;
        private decimal _Aliquota_ST;
        private decimal _MVA;
        private decimal _Reducao_BC;
        private short _Cod_Conexao_Configuracoes;
        private string _UM;
        private decimal _Total_Aprox_Trib;
        private decimal _Valor_IPI;
        private decimal _Aliquota_IPI;
        private decimal _Reducao_BC_ST;
        private string _CST_IBS_CBS;
        private string _CClass_Trib;
        private decimal _Aliq_IBS_Mun;
        private decimal _Aliq_IBS_Est;
        private decimal _Aliq_CBS;
        private decimal _Valor_Frete;

        public decimal Valor_Frete
        {
            get { return _Valor_Frete; }
            set { _Valor_Frete = value; }
        }

        public string CST_IBS_CBS
        {
            get { return _CST_IBS_CBS; }
            set { _CST_IBS_CBS = value; }
        }

        public string CClass_Trib
        {
            get { return _CClass_Trib; }
            set { _CClass_Trib = value; }
        }

        public decimal Aliq_IBS_Mun
        {
            get { return _Aliq_IBS_Mun; }
            set { _Aliq_IBS_Mun = value; }
        }

        public decimal Aliq_IBS_Est
        {
            get { return _Aliq_IBS_Est; }
            set { _Aliq_IBS_Est = value; }
        }

        public decimal Aliq_CBS
        {
            get { return _Aliq_CBS; }
            set { _Aliq_CBS = value; }
        }


        public decimal Reducao_BC_ST
        {
            get { return _Reducao_BC_ST; }
            set { _Reducao_BC_ST = value; }
        }

        public decimal Valor_IPI
        {
            get { return _Valor_IPI; }
            set { _Valor_IPI = value; }
        }

        public decimal Aliquota_IPI
        {
            get { return _Aliquota_IPI; }
            set { _Aliquota_IPI = value; }
        }

        public decimal Total_Aprox_Trib
        {
            get { return _Total_Aprox_Trib; }
            set { _Total_Aprox_Trib = value; }
        }

        public string UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        public decimal Valor_Base_Calculo_St
        {
            get { return _Valor_Base_Calculo_St; }
            set { _Valor_Base_Calculo_St = value; }
        }

        public decimal Aliquota_ST
        {
            get { return _Aliquota_ST; }
            set { _Aliquota_ST = value; }
        }

        public decimal MVA
        {
            get { return _MVA; }
            set { _MVA = value; }
        }

        public decimal Reducao_BC
        {
            get { return _Reducao_BC; }
            set { _Reducao_BC = value; }
        }

        public decimal Valor_Icms_St
        {
            get { return _Valor_Icms_St; }
            set { _Valor_Icms_St = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public decimal Valor_Icms
        {
            get { return _Valor_Icms; }
            set { _Valor_Icms = value; }
        }

        public decimal Valor_Base_Calculo
        {
            get { return _Valor_Base_Calculo; }
            set { _Valor_Base_Calculo = value; }
        }

        public string CFOP
        {
            get { return _CFOP; }
            set { _CFOP = value; }
        }

        public short Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
        }

        public int Cod_Produto
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string NCM
        {
            get { return _NCM; }
            set { _NCM = value; }
        }

        public string CEST
        {
            get { return _CEST; }
            set { _CEST = value; }
        }

        public string CST
        {
            get { return _CST; }
            set { _CST = value; }
        }

        public decimal Aliquota
        {
            get { return _Aliquota; }
            set { _Aliquota = value; }
        }

        public string CSOSN
        {
            get { return _CSOSN; }
            set { _CSOSN = value; }
        }

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public decimal Quantidade_Embalagem
        {
            get { return _Quantidade_Embalagem; }
            set { _Quantidade_Embalagem = value; }
        }

        public decimal Valor_Unitario
        {
            get { return _Valor_Unitario; }
            set { _Valor_Unitario = value; }
        }

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public decimal Valor_Desconto
        {
            get { return _Valor_Desconto; }
            set { _Valor_Desconto = value; }
        }

        public decimal Valor_Acrescimo
        {
            get { return _Valor_Acrescimo; }
            set { _Valor_Acrescimo = value; }
        }

        public decimal Valor_Total
        {
            get { return _Valor_Total; }
            set { _Valor_Total = value; }
        }

        public void Dispose()
        {
            _CFOP = null;
            _Codigo = 0;
            _Cod_Item = 0;
            _Cod_Produto = 0;
            _Descricao = null;
            _NCM = null;
            _CEST = null;
            _CST = null;
            _Aliquota = 0;
            _CSOSN = null;
            _Quantidade = 0;
            _Quantidade_Embalagem = 0;
            _Valor_Unitario = 0;
            _Total = 0;
            _Valor_Desconto = 0;
            _Valor_Acrescimo = 0;
            _Valor_Total = 0;
            _Valor_Icms = 0;
            _Valor_Base_Calculo = 0;
            _Cod_Conexao_Configuracoes = 0;
            _Valor_Icms_St = 0;
            _Aliquota_ST = 0;
            _MVA = 0;
            _Reducao_BC = 0;
            _Valor_Base_Calculo_St = 0;
            _UM = null;
            _Total_Aprox_Trib = 0;
            _Aliquota_IPI = 0;
            _Valor_IPI = 0;
            _Reducao_BC_ST = 0;
            _CST_IBS_CBS = null;
            _CClass_Trib = null;
            _Aliq_IBS_Mun = 0;
            _Aliq_IBS_Est = 0;
            _Aliq_CBS = 0;
            _Valor_Frete = 0;
        }
    }
}
