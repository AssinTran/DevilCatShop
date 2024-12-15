using System.Security.Cryptography;
using System.Text;

namespace DataAccess
{
    public class GenerateID
    {
        public string Value { get; set; }

        public GenerateID(string inputValue)
        {
            Value = GenerateId(inputValue);
        }

        private string GenerateId(string temp)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                //chuyen chuoi thanh mang byte
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(temp));
                //chuyen mang byte thanh dang hex
                StringBuilder rs = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    rs.Append(bytes[i].ToString("x2"));
                }
                // Tra ve chuoi 32 ky tu dau tien
                return rs.ToString().Substring(0, 32);
            }
        }

    }
}
