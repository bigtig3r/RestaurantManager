using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace BusinessLayer
{
	public class QuanTri
	{
		private Data data = new Data();
		public string ToEmail = "";
		public string YourEmail = "";
		public string Pass = "";
		private static readonly string PasswordHash = "P@@Sw0rd";
		private static readonly string SaltKey = "S@LT&KEY";
		private static readonly string VIKey = "@1B2c3D4e5F6g7H8";
		public QuanTri()
		{
			this.ToEmail = this.data.ToEmail;
			this.YourEmail = this.data.YourEmail;
			this.Pass = this.data.Pass;
		}
		public DataTable Login(string user, string pass)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"Select * From TAIKHOAN Where Ten='",
				user,
				"' and MatKhau='",
				pass,
				"'"
			}));
		}
		public DataTable LoadView()
		{
			return this.data.Get_Table("select * from View_HoaDonCF");
		}
		public DataTable LoadViewTK()
		{
			return this.data.Get_Table("select * from View_TKCF");
		}
		public DataTable LoadTaiKhoan()
		{
			return this.data.Get_Table("select ID,Ten as [Username],MatKhau as [Password],NguoiDung as [Fullname],Quyen as [Role] from TAIKHOAN");
		}
		public DataTable LoadTaiKhoan_Hide()
		{
			return this.data.Get_Table("select ID,Ten as [Username],'' as [Password],NguoiDung as [Fullname],Quyen as [Role] from TAIKHOAN");
		}
		public void Them(string ten, string mk, string quyen, string hoten)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@user", ten),
				new SqlParameter("@pass", mk),
				new SqlParameter("@quyen", quyen),
				new SqlParameter("@hoten", hoten)
			};
			this.data.Exec_Proc("Them_User", pas);
		}
		public void Sua(string id, string ten, string mk, string quyen, string hoten)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@id", id),
				new SqlParameter("@user", ten),
				new SqlParameter("@pass", mk),
				new SqlParameter("@quyen", quyen),
				new SqlParameter("@hoten", hoten)
			};
			this.data.Exec_Proc("Update_User", pas);
		}
		public void Xoa(string id)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
			this.data.Exec_Proc("Xoa_User", pas);
		}
		public string Encrypt(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			byte[] bytes2 = new Rfc2898DeriveBytes(QuanTri.PasswordHash, Encoding.ASCII.GetBytes(QuanTri.SaltKey)).GetBytes(32);
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.Zeros
			};
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, Encoding.ASCII.GetBytes(QuanTri.VIKey));
			byte[] inArray;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					inArray = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(inArray);
		}
		public string Decrypt(string encryptedText)
		{
			byte[] array = Convert.FromBase64String(encryptedText);
			byte[] bytes = new Rfc2898DeriveBytes(QuanTri.PasswordHash, Encoding.ASCII.GetBytes(QuanTri.SaltKey)).GetBytes(32);
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.None
			};
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes, Encoding.ASCII.GetBytes(QuanTri.VIKey));
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array2 = new byte[array.Length];
			int count = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array2, 0, count).TrimEnd("\0".ToCharArray());
		}
	}
}
