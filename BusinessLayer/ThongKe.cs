using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
	public class ThongKe
	{
		private Data data = new Data();
		public DataTable Load_TKNgay(string ngay, string thang, string nam)
		{
			string text = "select h.SoHD,h.SoBan,h.NgayLap,Sum(c.SoLuong*c.Gia) as Total,Sum(c.SoLuong*c.Gia) as [Amounti],h.Service,h.Disscount,h.Food, h.Drink,";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"(select Sum(t.MFood) from HoaDon t where datepart(day,t.NgayLap)=",
				ngay,
				" and datepart(month,t.NgayLap)=",
				thang,
				" and datepart(year,t.NgayLap)=",
				nam,
				") As MFood ,"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"(select Sum(u.MDrink) from HoaDon u where datepart(day,u.NgayLap)=",
				ngay,
				" and datepart(month,u.NgayLap)=",
				thang,
				" and datepart(year,u.NgayLap)=",
				nam,
				") As MDrink,"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"(select Sum(i.Delivery) from HoaDon i where datepart(day,i.NgayLap)=",
				ngay,
				" and datepart(month,i.NgayLap)=",
				thang,
				" and datepart(year,i.NgayLap)=",
				nam,
				" ) As Delivery "
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), c.NgayLap, 103) and datepart(day,h.NgayLap)=",
				ngay,
				" and datepart(month,h.NgayLap)=",
				thang,
				" and datepart(year,h.NgayLap)=",
				nam,
				" "
			});
			text += "group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Disscount,h.Food, h.Drink order by h.SoHD desc";
			return this.data.Get_Table(text);
		}
		public DataTable Load_TKThang(string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select h.SoHD,h.SoBan,h.NgayLap,Sum(c.SoLuong*c.Gia) as Total,Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100) as [Amounti],h.Service,h.Delivery,h.Disscount from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and datepart(month,NgayLap)=",
				thang,
				" and datepart(year,NgayLap)=",
				nam,
				" group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Delivery,h.Disscount order by h.SoHD desc"
			}));
		}
		public DataTable Load_TKNam(string nam)
		{
			return this.data.Get_Table("select h.SoHD,h.SoBan,h.NgayLap,Sum(c.SoLuong*c.Gia) as Total,Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100) as [Amounti],h.Service,h.Delivery,h.Disscount from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and datepart(year,NgayLap)=" + nam + " group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Delivery,h.Disscount order by h.SoHD desc");
		}
		public DataTable Load_TKMonNgay(string ngay, string thang, string nam)
		{
			string text = "select TenMon,c.Gia,SL=sum(SoLuong), ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"(select Sum(t.MFood) from HoaDon t where datepart(day,t.NgayLap)=",
				ngay,
				" and datepart(month,t.NgayLap)=",
				thang,
				" and datepart(year,t.NgayLap)=",
				nam,
				") As MFood ,"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"(select Sum(u.MDrink) from HoaDon u where datepart(day,u.NgayLap)=",
				ngay,
				" and datepart(month,u.NgayLap)=",
				thang,
				" and datepart(year,u.NgayLap)=",
				nam,
				") As MDrink,"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"(select Sum(i.Delivery) from HoaDon i where datepart(day,i.NgayLap)=",
				ngay,
				" and datepart(month,i.NgayLap)=",
				thang,
				" and datepart(year,i.NgayLap)=",
				nam,
				" ) As Delivery,0 As Service,convert(varchar(10), h.NgayLap, 103) As NgayLap "
			});
			text += "from ThucDon t, ChiTietHD c, HoaDon h ";
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"where t.MaMon=c.MaMon and c.SoHD=h.SoHD and convert(varchar(10), c.NgayLap, 103)=convert(varchar(10), h.NgayLap, 103)  and datepart(day,h.NgayLap)=",
				ngay,
				" and datepart(month,h.NgayLap)=",
				thang,
				" and datepart(year,h.NgayLap)=",
				nam
			});
			text += " group by TenMon,c.Gia,convert(varchar(10), h.NgayLap, 103) ";
			text += " order by sum(SoLuong) desc";
			return this.data.Get_Table(text);
		}
		public DataTable Load_TKMonNgay_Ser(string ngay, string thang, string nam)
		{
			string text = "select (Sum(c.SoLuong*c.Gia)-(h.MFood+h.Mdrink))*h.Service/100 as Service from HoaDon h, ChiTietHD c ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"where h.SoHD = c.SoHD and datepart(day,h.NgayLap)=",
				ngay,
				" and datepart(month,h.NgayLap)=",
				thang,
				" and datepart(year,h.NgayLap)=",
				nam,
				" and convert(varchar(10), c.NgayLap, 103)=convert(varchar(10), h.NgayLap, 103)"
			});
			text += "Group by h.SoHD,h.Service,h.MFood,h.MDrink";
			return this.data.Get_Table(text);
		}
		public DataTable Load_TKMonNgay(string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select TenMon,SL=sum(SoLuong),DonGia from ThucDon t, ChiTietHD c, HoaDon h where t.MaMon=c.MaMon and c.SoHD=h.SoHD and datepart(month,NgayLap)=",
				thang,
				" and datepart(year,NgayLap)=",
				nam,
				" group by TenMon,DonGia order by sum(SoLuong) desc"
			}));
		}
		public DataTable LoadHD_mahd(string maHD)
		{
			return this.data.Get_Table("select a.SoHD as[Bill ID],a.SoBan as [Table ID], convert(varchar(10), a.NgayLap, 103) as [Date] , Sum(b.SoLuong*b.Gia) as [Sub Total],a.Service as [Service Charge],a.Delivery as [Delivery Charge],a.Food as [Disscount Food],a.Drink as [Disscount Drink] from HoaDon a, ChiTietHD b, ThucDon t where a.SoHD = b.SoHD and b.MaMon=t.MaMon and a.SoHD='" + maHD + "' and convert(varchar(10), a.NgayLap, 103)=convert(varchar(10), GETDATE(), 103) and convert(varchar(10), a.NgayLap, 103)=convert(varchar(10), b.NgayLap, 103) group by a.SoHD,a.SoBan,a.NgayLap,a.Service,a.Delivery,a.Food,a.Drink,a.Disscount");
		}
		public DataTable Load_NgaychuaExport()
		{
			return this.data.Get_Table("select convert(varchar(10), h.NgayLap, 103) as [Ngay] from HoaDon h,ChiTietHD c where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103)=convert(varchar(10), c.NgayLap, 103) group by convert(varchar(10), h.NgayLap, 103)");
		}
		public DataTable LoadHD_ngaylap(string ngay, string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select a.SoHD as[Bill ID],a.SoBan as [Table ID], convert(varchar(10), a.NgayLap, 103) as [Date] , Sum(b.SoLuong*b.Gia) as [Sub Total],a.Service as [Service Charge],a.Delivery as [Delivery Charge],a.Food as [Disscount Food],a.Drink as [Disscount Drink] from HoaDon a, ChiTietHD b, ThucDon t where a.SoHD = b.SoHD and convert(varchar(10), a.NgayLap, 103)=convert(varchar(10), b.NgayLap, 103) and b.MaMon=t.MaMon and DAY(a.NgayLap) = ",
				ngay,
				" AND MONTH(a.NgayLap) =",
				thang,
				" AND YEAR(a.NgayLap) = ",
				nam,
				" group by a.SoHD,a.SoBan,a.NgayLap,a.Service,a.Delivery,a.Food,a.Drink,a.Disscount"
			}));
		}
		public void LamMoi()
		{
			this.data.Exec_Proc("LamMoi");
		}
		public void Reset_ID()
		{
			this.data.Exec_Proc("Reset_ID");
		}
		public void LamMoi(DateTime tungay, DateTime denngay)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@tungay", tungay.Date),
				new SqlParameter("@denngay", denngay.Date)
			};
			this.data.Exec_Proc("LamMoiDate", pas);
		}
		public void LamMoi(DateTime date)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@tungay", date.Date)
			};
			this.data.Exec_Proc("LamMoiDate2", pas);
		}
		public DataTable Load_EXNgay(string ngay, string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select h.SoHD,h.SoBan,convert(varchar(10), h.NgayLap, 103) as [Date]  ,Sum(c.SoLuong*c.Gia) as [Amounti],(Sum(c.SoLuong*c.Gia)-(h.MFood+h.MDrink))*(h.Service)/100 as[Service],h.Delivery,h.MFood,h.MDrink,((Sum(c.SoLuong*c.Gia)+(Sum(c.SoLuong*c.Gia)-(h.MFood+h.MDrink))*(h.Service)/100 +h.Delivery))-(h.MFood+h.MDrink) as Total from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and convert(varchar(10), c.NgayLap, 103)=convert(varchar(10), h.NgayLap, 103)  and datepart(day,h.NgayLap)=",
				ngay,
				" and datepart(month,h.NgayLap)=",
				thang,
				" and datepart(year,h.NgayLap)=",
				nam,
				" group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Delivery,h.MFood,h.MDrink order by h.SoHD desc"
			}));
		}
		public DataTable Load_EXNhieuNgay(string tungay, string denngay)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select h.SoHD,h.SoBan,convert(varchar(10), h.NgayLap, 103) as [Date]  ,Sum(c.SoLuong*c.Gia) as [Amounti],(Sum(c.SoLuong*c.Gia)-(h.MFood+h.MDrink))*(h.Service)/100 as[Service],h.Delivery,h.MFood,h.MDrink,((Sum(c.SoLuong*c.Gia)+(Sum(c.SoLuong*c.Gia)-(h.MFood+h.MDrink))*(h.Service)/100 +h.Delivery))-(h.MFood+h.MDrink) as Total from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and convert(varchar(10), h.NgayLap, 103) between '",
				tungay,
				"' and '",
				denngay,
				"' group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Delivery,h.MFood,h.MDrink order by h.SoHD desc"
			}));
		}
		public DataTable Load_EXThang(string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select h.SoHD,h.SoBan,convert(varchar(10), h.NgayLap, 103) as [Date] ,Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100) as [Amounti],h.Service,h.Delivery,(Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100))+((Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100))*(h.Service)/100 +h.Delivery)as Total from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and datepart(month,NgayLap)=",
				thang,
				" and datepart(year,NgayLap)=",
				nam,
				" group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Delivery order by h.SoHD desc"
			}));
		}
		public DataTable Load_EXNam(string nam)
		{
			return this.data.Get_Table("select h.SoHD,h.SoBan,convert(varchar(10), h.NgayLap, 103) as [Date] ,Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100) as [Amounti],h.Service,h.Delivery,(Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100))+((Sum(c.SoLuong*c.Gia)-Sum(c.SoLuong*c.Gia*c.Discount/100))*(h.Service)/100 +h.Delivery)as Total from ChiTietHD c,HoaDon h where h.SoHD=c.SoHD and datepart(year,NgayLap)=" + nam + " group by h.SoHD,h.SoBan,h.NgayLap,h.Service,h.Delivery order by h.SoHD desc");
		}
		public DataTable Load_chuathanhtoan()
		{
			return this.data.Get_Table("select SoBan from Ban where TinhTrang='False'");
		}
		public DataTable merge(DataTable dt1, DataTable dt2)
		{
			float num = 0f;
			for (int i = 0; i < dt2.Rows.Count; i++)
			{
				num += float.Parse((dt2.Rows[i]["Service"].ToString() == "") ? "0" : dt2.Rows[i]["Service"].ToString());
			}
			for (int j = 0; j < dt1.Rows.Count; j++)
			{
				dt1.Rows[j]["Service"] = num;
			}
			return dt1;
		}
	}
}
