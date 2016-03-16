using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
	public class Ban
	{
		private Data ban = new Data();
		public DataTable Load_Ban()
		{
			return this.ban.Get_Table("select SoBan as [ID],SoGhe as [Chair Number],GhiChu as [Note] from Ban");
		}
		public DataTable Load_DoiTuBan()
		{
			return this.ban.Get_Table("select SoBan as [ID] from Ban where TinhTrang='false'");
		}
		public DataTable Load_BanID()
		{
			return this.ban.Get_Table("select SoBan as [ID],TinhTrang as [Status] from Ban");
		}
		public void Them(string soban, int soghe, string ghichu)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban),
				new SqlParameter("@soghe", soghe),
				new SqlParameter("@ghichu", ghichu)
			};
			this.ban.Exec_Proc("Them_Ban", pas);
		}
		public void Sua(string soban, int soghe, string ghichu)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban),
				new SqlParameter("@soghe", soghe),
				new SqlParameter("@ghichu", ghichu)
			};
			this.ban.Exec_Proc("Sua_Ban", pas);
		}
		public void Xoa(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			this.ban.Exec_Proc("Xoa_Ban", pas);
		}
		public int KT_BanTonTai(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			return this.ban.Exec_Proc_Re("KT_BanTonTai", pas);
		}
		public int KT_BanDelivery(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			return this.ban.Exec_Proc_Re("KT_BanDelivery", pas);
		}
	}
}
