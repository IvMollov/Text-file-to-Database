using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace OnlineBookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(File.Open(@"D:\Projects\OnlineBookStore\OnlineBookStore\bin\OnlineBook.txt", FileMode.Open)))
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Server=.\\SQLEXPRESS;Database=OnlineBookStore;Trusted_Connection=True;";
                    conn.Open();
                    string line = "";
                    while((line = reader.ReadLine()) != "")
                    {
                        string[] parts = line.Split(new string[] { "|" }, StringSplitOptions.None);
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO BookStoreCatalogue ([Authors], [Book Title], [ISBN], [Price], [Amount], [WebSite]) VALUES (@0, @1, @2, @3, @4, @5)", conn);
                        insertCommand.Parameters.Add(new SqlParameter( "@0", parts[1]));
                        insertCommand.Parameters.Add(new SqlParameter("@1", parts[0]));
                        insertCommand.Parameters.Add(new SqlParameter("@2", parts[2]));
                        insertCommand.Parameters.Add(new SqlParameter("@3", parts[3]));
                        insertCommand.Parameters.Add(new SqlParameter("@4", parts[4]));
                        insertCommand.Parameters.Add(new SqlParameter("@5", parts[5]));

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
                    
        }
    }
}
