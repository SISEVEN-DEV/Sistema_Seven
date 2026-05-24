using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RespostaUploadDFe : IDisposable
    {
        public bool sucesso { get; set; }
        public string mensagem { get; set; }
        public string url { get; set; }

        public void Dispose()
        {
            sucesso = false;
            mensagem = null;
            url = null;
        }
    }
}
