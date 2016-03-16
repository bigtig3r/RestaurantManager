using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace DataLayer
{
	public class Data
	{
		private DataSet ds;
		private string sConn = "";
		private SqlConnection cnn;
		public string ToEmail = "";
		public string YourEmail = "";
		public string Pass = "";
		public Data()
		{
			if (this.Maincode("Con") != "")
			{
				this.sConn = this.Maincode("Con");
			}
			try
			{
				if (this.Maincode("ToEmail") != "")
				{
					this.ToEmail = this.Maincode("ToEmail");
				}
				if (this.Maincode("YourEmail") != "")
				{
					this.YourEmail = this.Maincode("YourEmail");
				}
				if (this.Maincode("Password") != "")
				{
					this.Pass = this.Maincode("Password");
				}
			}
			catch
			{
			}
			this.cnn = new SqlConnection(this.sConn);
		}
		public void OpenConnection()
		{
			try
			{
				this.cnn = new SqlConnection(this.sConn);
				if (this.cnn.State != ConnectionState.Open)
				{
					this.cnn.Open();
				}
			}
			catch
			{
				try
				{
					this.CloseConnection();
					this.cnn = new SqlConnection(this.sConn);
					if (this.cnn.State != ConnectionState.Open)
					{
						this.cnn.Open();
					}
				}
				catch
				{
				}
			}
		}
		public void CloseConnection()
		{
			try
			{
				if (this.cnn.State != ConnectionState.Closed)
				{
					this.cnn.Close();
					this.cnn.Dispose();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable Get_Table(string sql)
		{
			DataTable result;
			try
			{
				this.OpenConnection();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, this.cnn);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				this.CloseConnection();
				sqlDataAdapter.Dispose();
				GC.Collect();
				result = dataTable;
			}
			catch
			{
				result = new DataTable();
			}
			return result;
		}
		public DataTable getDataTable(string query)
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, this.cnn);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			return dataTable;
		}
		public void Exec_Proc(string sql, SqlParameter[] pas)
		{
			this.OpenConnection();
			SqlCommand sqlCommand = new SqlCommand(sql, this.cnn);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < pas.Length; i++)
			{
				SqlParameter value = pas[i];
				sqlCommand.Parameters.Add(value);
			}
			sqlCommand.ExecuteNonQuery();
			this.CloseConnection();
			sqlCommand.Dispose();
			GC.Collect();
		}
		public int Exec_Proc_Re(string sql, SqlParameter[] pas)
		{
			int result = -1;
			try
			{
				this.OpenConnection();
				SqlCommand sqlCommand = new SqlCommand(sql, this.cnn);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				for (int i = 0; i < pas.Length; i++)
				{
					SqlParameter value = pas[i];
					sqlCommand.Parameters.Add(value);
				}
				result = (int)sqlCommand.ExecuteScalar();
			}
			catch
			{
			}
			finally
			{
				this.CloseConnection();
			}
			return result;
		}
		public void Exec_Proc(string sql)
		{
			this.OpenConnection();
			SqlCommand sqlCommand = new SqlCommand(sql, this.cnn);
			sqlCommand.ExecuteNonQuery();
			this.CloseConnection();
			sqlCommand.Dispose();
			GC.Collect();
		}
		public bool TinhTrangBan(string sql, SqlParameter[] pas)
		{
			this.OpenConnection();
			SqlCommand sqlCommand = new SqlCommand(sql, this.cnn);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < pas.Length; i++)
			{
				SqlParameter value = pas[i];
				sqlCommand.Parameters.Add(value);
			}
			bool result = (bool)sqlCommand.ExecuteScalar();
			this.CloseConnection();
			sqlCommand.Dispose();
			GC.Collect();
			return result;
		}
		public string Maincode(string sql)
		{
			string innerText;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load("maincode.xml");
				innerText = xmlDocument.GetElementsByTagName(sql).Item(0).InnerText;
			}
			catch (Exception var_1_29)
			{
				string directoryName = Path.GetDirectoryName(Application.ExecutablePath);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(directoryName + "/maincode.xml");
				innerText = xmlDocument.GetElementsByTagName(sql).Item(0).InnerText;
			}
			return innerText;
		}
	}
}
