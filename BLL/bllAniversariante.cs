using DAL;
using System.Data;

namespace BLL
{
    public class bllAniversariante
    {
        public static bool _FrmRelAniversario_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Aniver_PesqFornClieFunc_Tabela;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static DataTable Sel_Fornecedor_Aniv()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Fornecedor_Aniv();
            }
        }

        public static DataTable Sel_Cliente_Aniv()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Aniv();
            }
        }

        public static DataTable Sel_Funcionario_Aniv()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Funcionario_Aniv();
            }
        }

        public static DataTable Sel_Aniversario_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Aniversario_Todos();
            }
        }

        public static DataTable Sel_Aniversario_Data(string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                SqlData = "WHERE data_nascimento BETWEEN '" + data.Replace('/', '.') + "' AND '" + data1.Replace('/', '.') + "'";
                //
                return con.Sel_Aniversario_Data(SqlData);
            }
        }

        public static DataTable Sel_Aniversariante_Aniv(string pesquisar, string tipo_aniversariante)
        {
            using (Con7BD con = new Con7BD())
            {
                if (tipo_aniversariante == "CLIENTES")
                {
                    using (ClieCons Clie = new ClieCons())
                    {
                        string[] items = pesquisar.Split('—');
                        Clie.Pesquisar = items[0];
                        return con.Sel_Aniversariante_Clie(Clie);
                    }
                }
                else if (tipo_aniversariante == "FORNECEDORES")
                {
                    using (Fornecedor Forn = new Fornecedor())
                    {
                        string[] items = pesquisar.Split('—');
                        Forn.Pesquisar = items[0];
                        return con.Sel_Aniversariante_Forn(Forn);
                    }
                }
                else if (tipo_aniversariante == "FUNCIONARIOS")
                {
                    using (Funcionario Func = new Funcionario())
                    {
                        string[] items = pesquisar.Split('—');
                        Func.Pesquisar = items[0];
                        return con.Sel_Aniversariante_Func(Func);
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public static DataTable Sel_Aniversariante_Tipo_Aniv(string tipo_aniversariante)
        {
            using (Con7BD con = new Con7BD())
            {
                if (tipo_aniversariante == "CLIENTES")
                {
                    using (ClieCons Clie = new ClieCons())
                    {
                        return con.Sel_Aniversariante_Tipo_Clie();
                    }
                }
                else if (tipo_aniversariante == "FORNECEDORES")
                {
                    using (Fornecedor Forn = new Fornecedor())
                    {
                        return con.Sel_Aniversariante_Tipo_Forn();
                    }
                }
                else if (tipo_aniversariante == "FUNCIONARIOS")
                {
                    using (Funcionario Func = new Funcionario())
                    {
                        return con.Sel_Aniversariante_Tipo_Func();
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
