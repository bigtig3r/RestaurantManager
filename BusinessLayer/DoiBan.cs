using DataLayer;
using System;
using System.Data.SqlClient;
namespace BusinessLayer
{
	public class DoiBan
	{
		private Data data = new Data();
		public void DoiBan1(int sohd, string soban2)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd", sohd),
				new SqlParameter("@soban2", soban2)
			};
			this.data.Exec_Proc("DoiBan1", pas);
		}
		public void DoiBan2(int sohd1, int sohd2, string soban1, string soban2)
		{
			SqlParameter[] pas = new SqlParameter[]
			{
				new SqlParameter("@sohd1", sohd1),
				new SqlParameter("@soban1", soban1),
				new SqlParameter("@sohd2", sohd2),
				new SqlParameter("@soban2", soban2)
			};
			this.data.Exec_Proc("DoiBan2", pas);
		}
	}
}
