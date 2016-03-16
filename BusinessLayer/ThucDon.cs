using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
	public class ThucDon
	{
		private Data thucdon = new Data();
		private DataTable dt1;
		public DataTable Load_ThucDon()
		{
			return this.thucdon.Get_Table("select t.MaMon as [ID],t.TenMon as [Name],t.DonGia as [Price],p.Name as [Type],p.ID as [IDType] from ThucDon t,Type p where t.IDType=p.ID and t.IDType <>9999 and t.IDType <>8888 ");
		}
		public DataTable Load_ThucDonFilter(string id)
		{
			return this.thucdon.Get_Table("select MaMon as [ID],TenMon as [Name],DonGia as [Price],p.Name as [Type],p.ID as [IDType] from ThucDon t,Type p where t.IDType=p.ID and IDType='" + id + "'");
		}
		public DataTable Load_ThucDonTK(string text)
		{
			return this.thucdon.Get_Table("select TenMon from ThucDon where TenMon like '%" + text + "%'");
		}
		public bool checkid(string text)
		{
			bool result = true;
			this.dt1 = this.thucdon.Get_Table("select MaMon from ThucDon where MaMon = '" + text + "'");
			if (this.dt1.Rows.Count >= 1)
			{
				result = false;
			}
			return result;
		}
		public void Them(string mamon, string tenmon, int dongia, int an)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@mamon", mamon),
				new SqlParameter("@tenmon", tenmon),
				new SqlParameter("@dongia", dongia),
				new SqlParameter("@an", an)
			};
			this.thucdon.Exec_Proc("Them_Mon", pas);
		}
		public void Sua(string mamon, string tenmon, int dongia, int an)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@mamon", mamon),
				new SqlParameter("@tenmon", tenmon),
				new SqlParameter("@dongia", dongia),
				new SqlParameter("@an", an)
			};
			this.thucdon.Exec_Proc("Sua_Mon", pas);
		}
		public void Xoa(string mamon)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@mamon", mamon)
			};
			this.thucdon.Exec_Proc("Xoa_Mon", pas);
		}
		public DataTable Load_LoaiThucDon()
		{
			return this.thucdon.Get_Table("select ID as [ID], Name as [Name],(case Type when '1' then 'Food' else 'Drink' end) as [Type]  from Type where ID<>9999 and ID<>8888");
		}
		public DataTable Load_LoaiThucDonbyID(string id)
		{
			return this.thucdon.Get_Table("select ID as [ID], Name as [Name] from Type where ID='" + id + "' ");
		}
		public DataTable Load_LoaiThucDonbyType(string id)
		{
			return this.thucdon.Get_Table("select ID as [ID], Name as [Name] from Type where Type='" + id + "' and ID<>9999 and ID<>8888");
		}
		public void Them_Loai(string ma, string ten, int ty)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@ma", ma),
				new SqlParameter("@ten", ten),
				new SqlParameter("@type", ty)
			};
			this.thucdon.Exec_Proc("Them_Type", pas);
		}
		public void Sua_Type(string ma, string ten, int ty)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@id", ma),
				new SqlParameter("@ten", ten),
				new SqlParameter("@type", ty)
			};
			this.thucdon.Exec_Proc("Sua_Type", pas);
		}
		public void Xoa_type(string ma)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@id", ma)
			};
			this.thucdon.Exec_Proc("Xoa_Type", pas);
		}
		public DataTable Load_MenubyBill(int billid, int type)
		{
			return this.thucdon.Get_Table(string.Concat(new object[]
			{
				"select t.MaMon from HoaDon h, ChiTietHD c,ThucDon t,Type p where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), c.NgayLap, 103) and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), GETDATE(), 103) and c.MaMon = t.MaMon and t.IDtype=p.ID and h.SoHD='",
				billid,
				"' and p.Type='",
				type,
				"'"
			}));
		}
		public DataTable Load_Discountbytype(int billid, int type, string dis)
		{
			return this.thucdon.Get_Table(string.Concat(new object[]
			{
				"select (sum(c.SoLuong*c.Gia)*",
				dis,
				"/100) as Discount from HoaDon h, ChiTietHD c,ThucDon t,Type p where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), c.NgayLap, 103) and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), GETDATE(), 103) and c.MaMon = t.MaMon and t.IDtype=p.ID and h.SoHD='",
				billid,
				"' and p.Type='",
				type,
				"'"
			}));
		}
		public void Update_Discount(string mamon, int giam)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@mamon", mamon),
				new SqlParameter("@dis", giam)
			};
			this.thucdon.Exec_Proc("Update_Discount", pas);
		}
	}
}
