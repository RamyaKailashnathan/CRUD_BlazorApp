using System.Data.SqlClient;

namespace CRUD_BlazorApp.Data
{
    public class SQL
    {
        private SqlConnection conn = new SqlConnection("Data Source=.;" +
            "Initial Catalog=STATIONARYDB;" +
            "User ID=sa;Password=Passw0rd;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False");
        public List<Stationary> ReadStationary()
        {
            conn.Open();
            List<Stationary> slist = new List<Stationary>();
            SqlCommand command = new SqlCommand("Select * from [Stationary]", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Stationary s = new ()
                    { Id = int.Parse (reader["id"].ToString()),
                      Stationaryname = reader["sname"].ToString(),
                      Studentname = reader["studentname"].ToString()
                     
                    };
                    slist.Add(s);
                    Console.WriteLine(String.Format("{0}", reader["id"]));
                }
                conn.Close();   
                return slist;
            }
        }

        
    }
}