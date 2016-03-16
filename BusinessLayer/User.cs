using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;

namespace BusinessLayer
{
    public class User
    {
        DataLayer.Data data = new DataLayer.Data();

        public string ToEmail = "";
        public string YourEmail = "";
        public string Pass = "";

        public User()
        {
            ToEmail = data.ToEmail;
            YourEmail = data.YourEmail;
            Pass = data.Pass;
        }

        public DataTable Login(string user, string pass)
        {
            return data.Get_Table("Select * From [User] Where Name='" + user + "' and Password='" + pass + "'");
        }

        public DataTable LoadView()
        {
            return data.Get_Table("select * from View_HoaDonCF");
        }

        public DataTable LoadViewTK()
        {
            return data.Get_Table("select * from View_TKCF");
        }

        public DataTable LoadUser()
        {
            return data.Get_Table("select ID,Ten as [Username],MatKhau as [Password],Nguoidung as [Fullname],Quyen as [Role] from [TAIKHOAN]");
        }
        public DataTable LoadUser_Hide()
        {
            return data.Get_Table("select ID,Ten as [Username],'' as [Password],Nguoidung as [Fullname],Quyen as [Role] from [TAIKHOAN]");
        }
        public void Add(string ten, string mk, string quyen,string hoten)
        {
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("@user", ten);
            pa[1] = new SqlParameter("@pass", mk);
            pa[2] = new SqlParameter("@quyen", quyen);
            pa[3] = new SqlParameter("@hoten", hoten);
            data.Exec_Proc("Them_User", pa);
        }
        public void Edit(string id,string ten, string mk, string quyen, string hoten)
        {
            SqlParameter[] pa = new SqlParameter[5];
            pa[0] = new SqlParameter("@id", id);
            pa[1] = new SqlParameter("@user", ten);
            pa[2] = new SqlParameter("@pass", mk);
            pa[3] = new SqlParameter("@quyen", quyen);
            pa[4] = new SqlParameter("@hoten", hoten);
            data.Exec_Proc("Update_User", pa);
        }
        public void Delete(string id)
        {
            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("@id", id);
            data.Exec_Proc("Xoa_User", pa);
        }

        #region MD5
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        #endregion

    }
}
