using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllWhatsapp
    {






        /*
            //EnviarMensagem("5575982716595", "Enviada pelo Sistema SEVEN");
            //
            await UploadMediaAsync(@"C:\DFe.pdf", "application/pdf");
            //
            MessageBox.Show(id);
            //
            EnviarDocumentoComMediaId("5575982716595", id, "DFe.pdf");
            */



        public async Task<string> UploadMediaAsync(string caminhoDoArquivo, string tipoMime)
        {
            var token = "EAASEhb1Dxb4BPGdJ8qzJwIW1egDAoXyMiFnr0U7iKgc9zy5Lw4h25YgOkDP0wO5VSDw9pkmJJOZCqBH9ORpSq0xm1OirIlv0MKXPZAF5TCC09YuHhTP2IZCetXeK2ROeR5XXZCh1GRErA3uh40ZAznbJCKMkaVSP8W0Y12XQdkGZAddXQ5MGDmuudHLaIEkqZCixZBkZAJnNxVCZCIPkzyTFTnF83VamUdwPMcHuRSsJssviHMYQZDZD";
            var numeroId = "780239865162570"; // Ex: 123456789

            var url = $"https://graph.facebook.com/v19.0/{numeroId}/media";

            var httpClient = new HttpClient();
            var form = new MultipartFormDataContent();
            var fileStream = File.OpenRead(caminhoDoArquivo);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(tipoMime); // Ex: "application/pdf"

            form.Add(fileContent, "file", Path.GetFileName(caminhoDoArquivo));
            form.Add(new StringContent("whatsapp"), "messaging_product");

            var response = await httpClient.PostAsync(url, form);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Erro no upload: {response.StatusCode} - {result}");
            }

            /*
            var json = System.Text.Json.JsonDocument.Parse(result);
            //id = json.RootElement.GetProperty("id").GetString();
            return json.RootElement.GetProperty("id").GetString(); // media_id
            */
            return null;
        }

        /*
        public async Task EnviarDocumentoComMediaId(string numeroDestino, string mediaId, string nomeArquivo)
        {
            //var token = "EAASEhb1Dxb4BPGdJ8qzJwIW1egDAoXyMiFnr0U7iKgc9zy5Lw4h25YgOkDP0wO5VSDw9pkmJJOZCqBH9ORpSq0xm1OirIlv0MKXPZAF5TCC09YuHhTP2IZCetXeK2ROeR5XXZCh1GRErA3uh40ZAznbJCKMkaVSP8W0Y12XQdkGZAddXQ5MGDmuudHLaIEkqZCixZBkZAJnNxVCZCIPkzyTFTnF83VamUdwPMcHuRSsJssviHMYQZDZD";
            var numeroId = "780239865162570"; // Ex: 123456789

            var url = $"https://graph.facebook.com/v19.0/{numeroId}/messages";

            var payload = new
            {
                messaging_product = "whatsapp",
                to = numeroDestino, // Ex: "5511999998888"
                type = "document",
                document = new
                {
                    id = mediaId,
                    filename = nomeArquivo
                }
            };

            /*
            var json = System.Text.Json.JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await cliente.PostAsync(url, content);
            var resultado = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Erro: {response.StatusCode} - {resultado} ");
            }
            
            Console.WriteLine("Documento enviado com sucesso!");
        }
        */

        /*
        public async Task EnviarMensagem(string numero, string mensagem)
        {
            var token = "EAASEhb1Dxb4BPGdJ8qzJwIW1egDAoXyMiFnr0U7iKgc9zy5Lw4h25YgOkDP0wO5VSDw9pkmJJOZCqBH9ORpSq0xm1OirIlv0MKXPZAF5TCC09YuHhTP2IZCetXeK2ROeR5XXZCh1GRErA3uh40ZAznbJCKMkaVSP8W0Y12XQdkGZAddXQ5MGDmuudHLaIEkqZCixZBkZAJnNxVCZCIPkzyTFTnF83VamUdwPMcHuRSsJssviHMYQZDZD";

            var numeroDoTelefone = "780239865162570";

            var url = $"https://graph.facebook.com/v19.0/{numeroDoTelefone}/messages";

            var cliente = new HttpClient();

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var payload = new
            {
                messaging_product = "whatsapp",
                to = numero,
                type = "text",
                text = new { body = mensagem }
            };

            /*
            var json = System.Text.Json.JsonSerializer.Serialize(payload);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(url, content);

            string resultado = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Erro: {response.StatusCode} - {resultado} ");
            }
           
            MessageBox.Show("Mensagem enviada", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
         */
    }
}
