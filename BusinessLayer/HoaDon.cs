using DataLayer;
using System;
using System.Data;
namespace BusinessLayer
{
	public class HoaDon
	{
		private Data data = new Data();
		public DataTable Load_HoaDon(int sohd, string soban)
		{
			return this.data.Get_Table(string.Concat(new object[]
			{
				"select * from View_HoaDonCF where SoBan='",
				soban,
				"' and SoHD=",
				sohd,
				" and convert(varchar(10), NgayLap, 103)=convert(varchar(10), GETDATE(), 103)"
			}));
		}
		public DataTable Load_HoaDon(int sohd, string soban, DateTime ngay)
		{
			return this.data.Get_Table(string.Concat(new object[]
			{
				"select * from View_HoaDonCF where SoBan='",
				soban,
				"' and SoHD=",
				sohd,
				" and convert(varchar(10), NgayLap, 103)='",
				ngay.Date.ToString("dd/MM/yyyy"),
				"'"
			}));
		}
	}
}
