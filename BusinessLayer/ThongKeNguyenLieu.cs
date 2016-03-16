using DataLayer;
using System;
using System.Data;
namespace BussinessLayer
{
	public class ThongKeNguyenLieu
	{
		private Data data = new Data();
		public DataTable Load_TKNgay(string ngay, string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select TenNL,SoLuongGoi=sum(SoLuong),DonGia,DVT,NgayNhap from NguyenLieu where datepart(day,NgayNhap)=",
				ngay,
				" and datepart(month,NgayNhap)=",
				thang,
				" and datepart(year,NgayNhap)=",
				nam,
				" group by TenNL,DonGia,DVT,NgayNhap order by sum(SoLuong) desc"
			}));
		}
		public DataTable Load_TKThang(string thang, string nam)
		{
			return this.data.Get_Table(string.Concat(new string[]
			{
				"select TenNL,SoLuongGoi=sum(SoLuong),DonGia,DVT,NgayNhap from NguyenLieu where datepart(month,NgayNhap)=",
				thang,
				" and datepart(year,NgayNhap)=",
				nam,
				" group by TenNL,DonGia,DVT,NgayNhap order by sum(SoLuong) desc"
			}));
		}
		public DataTable Load_TKNam(string nam)
		{
			return this.data.Get_Table("select TenNL, SoLuongGoi=sum(SoLuong),DonGia,DVT,NgayNhap from NguyenLieu where datepart(year,NgayNhap)=" + nam + " group by TenNL,DonGia,DVT,NgayNhap order by sum(SoLuong) desc");
		}
		public DataTable Load_TKMon()
		{
			return this.data.Get_Table("select TenNL,SoLuongGoi=sum(SoLuong),DonGia,DVT,NgayNhap from NguyenLieu group by TenNL,DonGia,DVT,NgayNhap ");
		}
		public void LamMoi()
		{
			this.data.Exec_Proc("LamMoiNL");
		}
	}
}
