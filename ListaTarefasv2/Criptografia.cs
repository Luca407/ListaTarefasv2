using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms; 

namespace ListaTarefasv2
{
    public static class Criptografia
    {
        public static string GerarHashSha256(string texto)
        {
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                    
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2")); // "x2" formata o byte como dois dígitos hexadecimais
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível gerar o hash SHA256 para a senha: " + ex.Message, "Erro - Criptografia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}