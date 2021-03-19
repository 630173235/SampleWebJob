using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleWebJob
{
	class Program
	{
		static void Main(string[] args)
		{
			var connectionString = "Data Source=192.168.10.163,60258;Initial Catalog=SampleDB;User ID=sa;Pwd=zx883408";
			//var connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
			SqlConnection myConnection = new SqlConnection(connectionString);
				string commandTxt = "select * from TestTable";
				SqlCommand sqlCmd = new SqlCommand(commandTxt , myConnection);
				myConnection.Open();
				using (SqlDataReader dataReader = sqlCmd.ExecuteReader())
				{
					while (dataReader.Read() )
					{
						Console.WriteLine( dataReader["id"].ToString() + " " + dataReader["data"].ToString());
					}
					myConnection.Close();
				}

			Console.WriteLine( "end...");

		}
	}
}
