namespace BLL
{
    public class bllEnviarSMS
    {
        public static bool _FrmUtilEnviarSMS_Ativo;
        public static string _Celular;

        public static void EnviaSms(string numero, string mensagem)
        {
            using (var port = new System.IO.Ports.SerialPort())
            {
                port.PortName = "COM5";
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
                port.Write("AT\r"); // iniciando a comunicação
                port.Write("AT+CMGF=1\r"); // setando a comunicação para o modo texto
                port.Write(string.Format("AT+CMGS=\"{0}\"\r", numero)); // setando o número do destinatário
                port.Write(mensagem + char.ConvertFromUtf32(26)); // enviando a mensagem
            }
        }
    }
}
