using System;

namespace DAL
{
    public class ConfiguracaoSistema : IDisposable
    {
        private short _Codigo;
        private byte _Abert_Fech_Caixa;
        private short _Margem_Esq;
        private short _Margem_Topo;
        private byte _Usar_Axacropdf;
        private short _Cod_Conexao_Configuracoes;
        private string _Resolucao;
        private string _Imagem_Fundo_7_ADM;
        private string _Ajuste_Imagem_7_ADM;
        private byte _Ver_Data_Hora_Internet;
        private byte _Ativar_Letreiro;
        private byte _Usar_Axacropdf_PDV;
        private string _Nome_Imp_Orcamento;
        private string _Nome_Imp_Devolucao;
        private string _Nome_Imp_Conta_Receber;
        private string _Tipo_Impressao_Devolucao;
        private string _Tipo_Impressao_Conta_Receber;
        private string _Tipo_Impressao_Orcamento;
        private string _Tipo_Impressao_Nota_Prom;
        private string _Tipo_Impressao_NNF;
        private string _Nome_Imp_Nota_Prom;
        private string _Nome_Imp_NNF;
        private string _Mensagem;
        private short _Margem_Esq_pdv;
        private short _Margem_Topo_pdv;
        private short _Margem_Esq_80_pdv;
        private short _Margem_Topo_80_pdv;
        private short _Margem_Esq_A4_pdv;
        private short _Margem_Topo_A4_pdv;
        private byte _Alertar_Estoque;
        private byte _Dest_Est_Baixo;
        private byte _Alertar_Observacao;
        private byte _Mostrar_Desc_Acresc;
        private byte _Mostrar_Ass_Cons;
        private byte _Cont_Usuario_Vendas;
        private byte _Mostrar_Inf_Usuario;
        private string _Versao_ADM;
        private string _Versao_PDV;
        private string _Porta_Email;
        private string _Tipo;
        private short _Margem_Esq_NFCe;
        private short _Margem_Dir_NFCe;
        private byte _Contingencia_NFCe;
        private string _Data_Ult_Backup;
        private byte _Buscar_Atualizacao;

        public byte Buscar_Atualizacao
        {
            get { return _Buscar_Atualizacao; }
            set { _Buscar_Atualizacao = value; }
        }

        public string Data_Ult_Backup
        {
            get { return _Data_Ult_Backup; }
            set { _Data_Ult_Backup = value; }
        }

        public byte Contingencia_NFCe 
        {
            get { return _Contingencia_NFCe; }
            set { _Contingencia_NFCe = value; }
        }

        public short Margem_Esq_NFCe
        {
            get { return _Margem_Esq_NFCe; }
            set { _Margem_Esq_NFCe = value; }
        }

        public short Margem_Dir_NFCe
        {
            get { return _Margem_Dir_NFCe; }
            set { _Margem_Dir_NFCe = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public string Porta_Email
        {
            get { return _Porta_Email; }
            set { _Porta_Email = value; }
        }

        public string Versao_ADM
        {
            get { return _Versao_ADM; }
            set { _Versao_ADM = value; }
        }


        public string Versao_PDV
        {
            get { return _Versao_PDV; }
            set { _Versao_PDV = value; }
        }

        public byte Mostrar_Inf_Usuario
        {
            get { return _Mostrar_Inf_Usuario; }
            set { _Mostrar_Inf_Usuario = value; }
        }

        public byte Cont_Usuario_Vendas
        {
            get { return _Cont_Usuario_Vendas; }
            set { _Cont_Usuario_Vendas = value; }
        }

        public byte Mostrar_Ass_Cons
        {
            get { return _Mostrar_Ass_Cons; }
            set { _Mostrar_Ass_Cons = value; }
        }

        public byte Mostrar_Desc_Acresc
        {
            get { return _Mostrar_Desc_Acresc; }
            set { _Mostrar_Desc_Acresc = value; }
        }

        public byte Alertar_Observacao
        {
            get { return _Alertar_Observacao; }
            set { _Alertar_Observacao = value; }
        }

        public byte Alertar_Estoque
        {
            get { return _Alertar_Estoque; }
            set { _Alertar_Estoque = value; }
        }

        public byte Dest_Est_Baixo
        {
            get { return _Dest_Est_Baixo; }
            set { _Dest_Est_Baixo = value; }
        }

        public short Margem_Esq_pdv
        {
            get { return _Margem_Esq_pdv; }
            set { _Margem_Esq_pdv = value; }
        }

        public short Margem_Topo_pdv
        {
            get { return _Margem_Topo_pdv; }
            set { _Margem_Topo_pdv = value; }
        }

        public short Margem_Esq_80_pdv
        {
            get { return _Margem_Esq_80_pdv; }
            set { _Margem_Esq_80_pdv = value; }
        }

        public short Margem_Topo_80_pdv
        {
            get { return _Margem_Topo_80_pdv; }
            set { _Margem_Topo_80_pdv = value; }
        }

        public short Margem_Esq_A4_pdv
        {
            get { return _Margem_Esq_A4_pdv; }
            set { _Margem_Esq_A4_pdv = value; }
        }

        public short Margem_Topo_A4_pdv
        {
            get { return _Margem_Topo_A4_pdv; }
            set { _Margem_Topo_A4_pdv = value; }
        }

        public byte Usar_Axacropdf_PDV
        {
            get { return _Usar_Axacropdf_PDV; }
            set { _Usar_Axacropdf_PDV = value; }
        }

        public string Nome_Imp_Orcamento
        {
            get { return _Nome_Imp_Orcamento; }
            set { _Nome_Imp_Orcamento = value; }
        }

        public string Nome_Imp_Devolucao
        {
            get { return _Nome_Imp_Devolucao; }
            set { _Nome_Imp_Devolucao = value; }
        }

        public string Tipo_Impressao_NNF
        {
            get { return _Tipo_Impressao_NNF; }
            set { _Tipo_Impressao_NNF = value; }
        }

        public string Nome_Imp_Conta_Receber
        {
            get { return _Nome_Imp_Conta_Receber; }
            set { _Nome_Imp_Conta_Receber = value; }
        }

        public string Tipo_Impressao_Devolucao
        {
            get { return _Tipo_Impressao_Devolucao; }
            set { _Tipo_Impressao_Devolucao = value; }
        }

        public string Tipo_Impressao_Conta_Receber
        {
            get { return _Tipo_Impressao_Conta_Receber; }
            set { _Tipo_Impressao_Conta_Receber = value; }
        }

        public string Tipo_Impressao_Orcamento
        {
            get { return _Tipo_Impressao_Orcamento; }
            set { _Tipo_Impressao_Orcamento = value; }
        }

        public string Tipo_Impressao_Nota_Prom
        {
            get { return _Tipo_Impressao_Nota_Prom; }
            set { _Tipo_Impressao_Nota_Prom = value; }
        }

        public string Nome_Imp_Nota_Prom
        {
            get { return _Nome_Imp_Nota_Prom; }
            set { _Nome_Imp_Nota_Prom = value; }
        }

        public string Nome_Imp_NNF
        {
            get { return _Nome_Imp_NNF; }
            set { _Nome_Imp_NNF = value; }
        }

        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; }
        }

        public byte Ver_Data_Hora_Internet
        {
            get { return _Ver_Data_Hora_Internet; }
            set { _Ver_Data_Hora_Internet = value; }
        }

        public byte Ativar_Letreiro
        {
            get { return _Ativar_Letreiro; }
            set { _Ativar_Letreiro = value; }
        }

        public string Imagem_Fundo_7_ADM
        {
            get { return _Imagem_Fundo_7_ADM; }
            set { _Imagem_Fundo_7_ADM = value; }
        }

        public string Ajuste_Imagem_7_ADM
        {
            get { return _Ajuste_Imagem_7_ADM; }
            set { _Ajuste_Imagem_7_ADM = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public byte Abert_Fech_Caixa
        {
            get { return _Abert_Fech_Caixa; }
            set { _Abert_Fech_Caixa = value; }
        }

        public short Margem_Esq
        {
            get { return _Margem_Esq; }
            set { _Margem_Esq = value; }
        }

        public short Margem_Topo
        {
            get { return _Margem_Topo; }
            set { _Margem_Topo = value; }
        }

        public byte Usar_Axacropdf
        {
            get { return _Usar_Axacropdf; }
            set { _Usar_Axacropdf = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public string Resolucao
        {
            get { return _Resolucao; }
            set { _Resolucao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Abert_Fech_Caixa = 0;
            _Margem_Esq = 0;
            _Margem_Topo = 0;
            _Usar_Axacropdf = 0;
            _Cod_Conexao_Configuracoes = 0;
            _Resolucao = null;
            _Imagem_Fundo_7_ADM = null;
            _Ajuste_Imagem_7_ADM = null;
            _Ver_Data_Hora_Internet = 0;
            _Ativar_Letreiro = 0;
            _Usar_Axacropdf_PDV = 0;
            _Nome_Imp_Orcamento = null;
            _Nome_Imp_Devolucao = null;
            _Nome_Imp_Conta_Receber = null;
            _Tipo_Impressao_Devolucao = null;
            _Tipo_Impressao_Conta_Receber = null;
            _Tipo_Impressao_Orcamento = null;
            _Tipo_Impressao_Nota_Prom = null;
            _Nome_Imp_Nota_Prom = null;
            _Nome_Imp_NNF = null;
            _Mensagem = null;
            _Tipo_Impressao_NNF = null;
            _Margem_Esq_pdv = 0;
            _Margem_Topo_pdv = 0;
            _Margem_Esq_80_pdv = 0;
            _Margem_Topo_80_pdv = 0;
            _Margem_Esq_A4_pdv = 0;
            _Margem_Topo_A4_pdv = 0;
            _Alertar_Estoque = 0;
            _Dest_Est_Baixo = 0;
            _Alertar_Observacao = 0;
            _Mostrar_Desc_Acresc = 0;
            _Mostrar_Ass_Cons = 0;
            _Cont_Usuario_Vendas = 0;
            _Mostrar_Inf_Usuario = 0;
            _Versao_ADM = null;
            _Versao_PDV = null;
            _Porta_Email = null;
            _Tipo = null;
            _Margem_Esq_NFCe = 0;
            _Margem_Dir_NFCe = 0;
            _Data_Ult_Backup = null;
            _Buscar_Atualizacao = 0;
        }
    }
}
