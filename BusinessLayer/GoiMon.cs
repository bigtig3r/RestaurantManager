using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
	public class GoiMon
	{
		private Data data = new Data();
		public DataTable Load_GoiMon(int sohd)
		{
			return this.data.Get_Table("select TenMon as [Name],SoLuong as [Quantity],c.MaMon as [ID],t.DonGia as [Price],c.Discount as [Discount] from HoaDon h,ChiTietHD c,ThucDon t where h.SoHD=c.SoHD and t.MaMon=c.MaMon and h.SoHD=" + sohd);
		}
		public DataTable Load_GoiMon(int sohd, string ngaylap)
		{
			return this.data.Get_Table(string.Concat(new object[]
			{
				"select TenMon as [Name],SoLuong as [Quantity],c.MaMon as [ID],t.DonGia as [Price],c.Discount as [Discount] from HoaDon h,ChiTietHD c,ThucDon t where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)= convert(varchar(10), c.NgayLap, 103) and t.MaMon=c.MaMon and h.SoHD=",
				sohd,
				" and convert(varchar(10), h.NgayLap, 103) = '",
				ngaylap,
				"'"
			}));
		}
		public DataTable Tong_HD(int sohd)
		{
			return this.data.Get_Table("select h.SoHD,(Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100)) as [ToTal] from HoaDon h,ChiTietHD c where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), c.NgayLap, 103) and h.SoHD=" + sohd + " and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), GETDATE(), 103) group by h.SoHD");
		}
		public DataTable Tong_HD(int sohd, int soban)
		{
			return this.data.Get_Table(string.Concat(new object[]
			{
				"select h.SoHD,(Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100)) as [ToTal] from HoaDon h,ChiTietHD c where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), c.NgayLap, 103) and h.SoHD=",
				sohd,
				" and h.SoBan=",
				soban,
				" and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), GETDATE(), 103) group by h.SoHD"
			}));
		}
		public int getHD(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			return this.data.Exec_Proc_Re("GetHD", pas);
		}
		public bool TinhTrangBan(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			return this.data.TinhTrangBan("TinhTrangBan", pas);
		}
		public void Update_Ban(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			this.data.Exec_Proc("Update_Ban", pas);
		}
		public void Update_DaThanhToan(string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban)
			};
			this.data.Exec_Proc("Update_DaThanhToan", pas);
		}
		public DataTable SelectSoHD()
		{
			return this.data.Get_Table("select SoHD from HoaDon where convert(varchar(10), NgayLap, 103)=convert(varchar(10), GETDATE(), 103)");
		}
		public DataTable Show_Ban()
		{
			return this.data.Get_Table("select  SoBan as [Table ID],(case TinhTrang when '1' then 'Empty' else 'Full' end) as [Status] from Ban");
		}
		public DataTable GiabyID(string mamon)
		{
			return this.data.Get_Table("select DonGia from ThucDon where MaMon='" + mamon + "'");
		}
		public void ThemHD(string soban, DateTime ngaylap)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban),
				new SqlParameter("@ngaylap", ngaylap)
			};
			this.data.Exec_Proc("ThemHD", pas);
		}
		public void ThemHD(string sohd, string soban, DateTime ngaylap)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@soban", soban),
				new SqlParameter("@ngaylap", ngaylap)
			};
			this.data.Exec_Proc("ThemHD_Ins", pas);
		}
		public void Them_GoiMon(int sohd, string mamon, int soluong, int gia, int giam)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@mamon", mamon),
				new SqlParameter("@soluong", soluong),
				new SqlParameter("@gia", gia),
				new SqlParameter("@giam", giam)
			};
			this.data.Exec_Proc("Them_GoiMon", pas);
		}
		public void Update_price(int sohd, string soban, string ser, string del)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban),
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@ser", ser),
				new SqlParameter("@del", del)
			};
			this.data.Exec_Proc("Update_price", pas);
		}
		public void Update_GiamGia(int sohd, string soban, string food, string drink, string mfood, string mdrink)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@soban", soban),
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@food", food),
				new SqlParameter("@drink", drink),
				new SqlParameter("@mfood", mfood),
				new SqlParameter("@mdrink", mdrink)
			};
			this.data.Exec_Proc("Update_GiamGia", pas);
		}
		public int KiemTraMon(int sohd, string mamon)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@mamon", mamon)
			};
			return this.data.Exec_Proc_Re("KiemTraMon", pas);
		}
		public void Update_SLGoiMon(int sohd, string mamon, int soluong)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@mamon", mamon),
				new SqlParameter("@soluong", soluong)
			};
			this.data.Exec_Proc("Update_SLGoiMon", pas);
		}
		public void Sua_GoiMon(int sohd, string mamon, int soluong, int dis)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@mamon", mamon),
				new SqlParameter("@soluong", soluong),
				new SqlParameter("@dis", dis)
			};
			this.data.Exec_Proc("Sua_GoiMon", pas);
		}
		public void Xoa_GoiMon(int sohd, string mamon)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@mamon", mamon)
			};
			this.data.Exec_Proc("Xoa_GoiMon", pas);
		}
		public int KiemTraCTHD_Rong(int sohd)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd)
			};
			return this.data.Exec_Proc_Re("KiemTraCTHD_Rong", pas);
		}
		public int KT_BillDaIn(int sohd, string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@soban", soban)
			};
			return this.data.Exec_Proc_Re("KT_BillDaIn", pas);
		}
		public int Update_BillDaIn(int sohd, string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@soban", soban)
			};
			return this.data.Exec_Proc_Re("Update_BillDaIn", pas);
		}
		public int Get_DiscountFood(int sohd, string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@soban", soban)
			};
			return this.data.Exec_Proc_Re("GetFood", pas);
		}
		public int Get_DiscountDrink(int sohd, string soban)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@soban", soban)
			};
			return this.data.Exec_Proc_Re("GetDrink", pas);
		}
		public DataTable Getrownum(string id)
		{
			return this.data.Get_Table("select MaMon from ThucDon where MaMon like'%" + id + "%'");
		}
		public DataTable Getmenubybillid(int id)
		{
			return this.data.Get_Table("select MaMon from ChiTietHD  where convert(varchar(10), NgayLap, 103)=convert(varchar(10), GETDATE(), 103) and SoHD ='" + id + "'");
		}
		public void GhepBan(int sohdcu, int sohdmoi)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohdcu", sohdcu),
				new SqlParameter("@sohdmoi", sohdmoi)
			};
			this.data.Exec_Proc("Update_GhepBan", pas);
		}
		public void Del_HoaDon(int id)
		{
			this.data.Exec_Proc("Delete from HoaDon where  convert(varchar(10), NgayLap, 103)=convert(varchar(10), GETDATE(), 103) and SoHD ='" + id + "'");
		}
	}
}
