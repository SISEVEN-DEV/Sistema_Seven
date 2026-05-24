using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OS : IDisposable
    {
        private int _Codigo;
        private int _Cod_Consumidor;
        private string _Nome_Consumidor;
        private string _CPF_CNPJ_Consumidor;
        private string _Data;
        private string _Horario;
        private string _Data_Conclusao;
        private string _Horario_Conclusao;
        private string _Descricao;
        private string _Descricao_Item;
        private string _Marca;
        private string _Modelo;
        private string _N_Serie;
        private string _Observacao;
        private byte [] _Imagem_OS;
        private string _Data_Conc_Prev;
        private string _Horario_Conc_Prev;
        private string _Situacao;
        private string _Pesquisar;
        private string _Data_Baixa;
        private string _Horario_Baixa;
        private decimal _Troco;
        private decimal _Valor_Desconto;
        private decimal _Desconto_Porc;
        private decimal _Valor_Acrescimo;
        private decimal _Acrescimo_Porc;
        private decimal _Valor_Real;
        private short _Cod_Usuario_Baixa;
        private string _Nome_Usuario_Baixa;
        private short _Cod_PDV_Computador_Baixa;
        private decimal _Valor_Desconto_Prod;
        private decimal _Desconto_Porc_Prod;
        private decimal _Valor_Acrescimo_Prod;
        private decimal _Acrescimo_Porc_Prod;
        private decimal _Valor_Servicos;
        private decimal _Valor_Produtos;
        private decimal _Valor_Total;
        private byte _Pagamento_Parcial;
        private short _Cod_Usuario;
        private string _Nome_Usuario;

        private decimal _Valor_Desconto_Item;
        private decimal _Valor_Acrescimo_Item;

        public decimal Valor_Desconto_Item
        {
            get { return _Valor_Desconto_Item; }
            set { _Valor_Desconto_Item = value; }
        }
        public decimal Valor_Acrescimo_Item
        {
            get { return _Valor_Acrescimo_Item; }
            set { _Valor_Acrescimo_Item = value; }
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

        public byte Pagamento_Parcial 
        {
            get { return _Pagamento_Parcial; }
            set { _Pagamento_Parcial = value; }
        }

        public decimal Valor_Total
        {
            get { return _Valor_Total; }
            set { _Valor_Total = value; }
        }

        public decimal Valor_Servicos
        {
            get { return _Valor_Servicos; }
            set { _Valor_Servicos = value; }
        }

        public decimal Valor_Produtos
        {
            get { return _Valor_Produtos; }
            set { _Valor_Produtos = value; }
        }

        public decimal Valor_Desconto_Prod
        {
            get { return _Valor_Desconto_Prod; }
            set { _Valor_Desconto_Prod = value; }
        }

        public decimal Desconto_Porc_Prod
        {
            get { return _Desconto_Porc_Prod; }
            set { _Desconto_Porc_Prod = value; }
        }

        public decimal Valor_Acrescimo_Prod
        {
            get { return _Valor_Acrescimo_Prod; }
            set { _Valor_Acrescimo_Prod = value; }
        }

        public decimal Acrescimo_Porc_Prod
        {
            get { return _Acrescimo_Porc_Prod; }
            set { _Acrescimo_Porc_Prod = value; }
        }

        public decimal Valor_Real
        {
            get { return _Valor_Real; }
            set { _Valor_Real = value; }
        }

        public string Data_Baixa
        {
            get { return _Data_Baixa; }
            set { _Data_Baixa = value; }
        }

        public string Horario_Baixa
        {
            get { return _Horario_Baixa; }
            set { _Horario_Baixa = value; }
        }

        public decimal Troco
        {
            get { return _Troco; }
            set { _Troco = value; }
        }

        public decimal Valor_Desconto
        {
            get { return _Valor_Desconto; }
            set { _Valor_Desconto = value; }
        }

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
        }

        public decimal Valor_Acrescimo
        {
            get { return _Valor_Acrescimo; }
            set { _Valor_Acrescimo = value; }
        }

        public decimal Acrescimo_Porc
        {
            get { return _Acrescimo_Porc; }
            set { _Acrescimo_Porc = value; }
        }

        public string Data_Conc_Prev 
        {
            get { return _Data_Conc_Prev; }
            set { _Data_Conc_Prev = value; }
        }

        public string Horario_Conc_Prev
        {
            get { return _Horario_Conc_Prev; }
            set { _Horario_Conc_Prev = value; }
        }

        public int Codigo 
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Consumidor 
        {
            get { return _Cod_Consumidor; }
            set { _Cod_Consumidor = value; }
        }

        public string Nome_Consumidor 
        {
            get { return _Nome_Consumidor; }
            set { _Nome_Consumidor = value; }
        }

        public string CPF_CNPJ_Consumidor
        {
            get { return _CPF_CNPJ_Consumidor; }
            set { _CPF_CNPJ_Consumidor = value; }
        }

        public string Data 
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public string Horario 
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        public string Data_Conclusao 
        {
            get { return _Data_Conclusao; }
            set { _Data_Conclusao = value; }
        }

        public string Horario_Conclusao 
        {
            get { return _Horario_Conclusao; }
            set { _Horario_Conclusao = value; }
        }

        public string Descricao 
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Descricao_Item 
        {
            get { return _Descricao_Item; }
            set { _Descricao_Item = value; }
        }

        public string Marca 
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public string Modelo 
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string N_Serie 
        {
            get { return _N_Serie; }
            set { _N_Serie = value; }
        
        }

        public string Observacao 
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public byte [] Imagem_OS
        {
            get { return _Imagem_OS; }
            set { _Imagem_OS = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public short Cod_Usuario_Baixa
        {
            get { return _Cod_Usuario_Baixa; }
            set { _Cod_Usuario_Baixa = value; }
        }

        public string Nome_Usuario_Baixa
        {
            get { return _Nome_Usuario_Baixa; }
            set { _Nome_Usuario_Baixa = value; }
        }

        public short Cod_PDV_Computador_Baixa
        {
            get { return _Cod_PDV_Computador_Baixa; }
            set { _Cod_PDV_Computador_Baixa = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Consumidor = 0;
            _Nome_Consumidor = null;
            _CPF_CNPJ_Consumidor = null;
            _Data = null;
            _Horario = null;
            _Data_Conclusao = null;
            _Horario_Conclusao = null;
            _Descricao = null;
            _Descricao_Item = null;
            _Marca = null;
            _Modelo = null;
            _N_Serie = null;
            _Observacao = null;
            _Imagem_OS = null;
            _Data_Conc_Prev = null;
            _Horario_Conc_Prev = null;
            _Situacao = null;
            _Pesquisar = null;
            _Data_Baixa = null;
            _Horario_Baixa = null;
            _Troco = 0;
            _Valor_Desconto = 0;
            _Desconto_Porc = 0;
            _Valor_Acrescimo = 0;
            _Acrescimo_Porc = 0;
            _Valor_Real = 0;
            _Cod_Usuario_Baixa = 0;
            _Nome_Usuario_Baixa = null;
            _Cod_PDV_Computador_Baixa = 0;
            _Valor_Desconto_Prod = 0;
            _Desconto_Porc_Prod = 0;
            _Valor_Acrescimo_Prod = 0;
            _Acrescimo_Porc_Prod = 0;
            _Valor_Servicos = 0;
            _Valor_Produtos = 0;
            _Valor_Total = 0;
            _Pagamento_Parcial = 0;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Valor_Desconto_Item = 0;
            _Valor_Acrescimo_Item = 0;
        }
    }
}
