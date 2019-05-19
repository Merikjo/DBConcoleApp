using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DbConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.esimerkki
            {
                string connStr = "Server=DESKTOP-G0R5GEC\\SQLEXJOHANNAME;Database=Northwind;Trusted_Connection=True;";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string sql = "SELECT * FROM Customers WHERE Country = 'Finland'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())

                {
                    string companyName = reader.GetString(1);
                    string contactName = reader.GetString(2);
                    Console.WriteLine("Löytyi rivi: " + companyName + " " + contactName);
                }

                Console.ReadLine();

                // resurssien vapautus 
                reader.Close();
                cmd.Dispose();
                conn.Dispose();
            }



            //2.esimerkki
            {
                int j = 0, i = 0, k = 0;
                string sarakeNimi = "", sarakeArvo = "";

                string connStr2 = "Server=DESKTOP-G0R5GEC\\SQLEXJOHANNAME;Database=Northwind;Trusted_Connection=True;";
                SqlConnection conn2 = new SqlConnection(connStr2);
                conn2.Open();
                string sql2 = "SELECT * FROM Shippers";
                SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                SqlDataReader reader = cmd2.ExecuteReader();

                //osikointi:
                //Console.WriteLine("id".PadRight(10) + "companyName".PadRight(20) + "Phone".PadRight(15));


                //
                DataTable schemaTable = reader.GetSchemaTable();

                foreach (DataRow rivi in schemaTable.Rows)
                {
                    foreach (DataColumn column in schemaTable.Columns)
                    {
                        if (column.ColumnName == "ColumnName")
                        {
                            j++;
                            sarakeNimi = rivi[column].ToString();
                            sarakeNimi = (sarakeNimi.PadRight(15).Substring(0, 15) + " ");
                            Console.Write(sarakeNimi);
                        }
                    }
                }

                Console.WriteLine();

                while (reader.Read())

                {
                    //int id = reader.GetInt32(0);
                    //string companyName = reader.GetString(1);
                    //string Phone = reader.GetString(2);
                    //Console.WriteLine("Löytyi rivi: " + id.ToString() + " " + companyName + " " + Phone);

                    //Console.WriteLine(id.ToString().PadRight(10).Substring(0, 10) + companyName.PadRight(20).Substring(0,20) + Phone.PadRight(15).Substring(0, 15));

                    i++;
                    for (k = 0; k < j; k++)
                    {
                        sarakeArvo = reader.GetValue(k).ToString();
                        sarakeArvo = (sarakeArvo.PadRight(15).Substring(0, 15) + " ");
                        if (k < j - 1)
                        {
                            Console.Write(sarakeArvo);
                        }
                        else
                            Console.WriteLine(sarakeArvo);
                    }

                }

                Console.ReadLine();

                // resurssien vapautus 
                reader.Close();
                cmd2.Dispose();
                conn2.Dispose();
            }


            //3.esimerkki
            {
                int j = 0, i = 0, k = 0;
                string sarakeNimi = "", sarakeArvo = "";

                string connStr2 = "Server=DESKTOP-G0R5GEC\\SQLEXJOHANNAME;Database=Northwind;Trusted_Connection=True;";
                SqlConnection conn2 = new SqlConnection(connStr2);
                conn2.Open();
                string sql2 = "123";


                while (sql2.ToUpper() != "X")
                {
                    Console.Write("SQL > ");
                    sql2 = Console.ReadLine();
                    if (sql2 == "") continue;
                    SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    DataTable schemaTable = reader.GetSchemaTable();

                    StringBuilder csv = new StringBuilder();

                    foreach (DataRow rivi in schemaTable.Rows)
                    {
                        foreach (DataColumn column in schemaTable.Columns)
                        {
                            if (column.ColumnName == "ColumnName")
                            {
                                j++;
                                sarakeNimi = rivi[column].ToString();
                                sarakeNimi = (sarakeNimi.PadRight(15).Substring(0, 15) + " ");
                                Console.Write(sarakeNimi);
                            }
                        }
                    }

                    Console.WriteLine();

                    while (reader.Read())
                    {
                        i++;
                        for (k = 0; k < j; k++)
                        {
                            sarakeArvo = reader.GetValue(k).ToString();
                            sarakeArvo = (sarakeArvo.PadRight(15).Substring(0, 15) + " | ");
                            if (k < j - 1)
                            {
                                Console.Write(sarakeArvo);
                            }
                            else
                                Console.WriteLine(sarakeArvo);
                        }
                    }
                    Console.ReadLine();

                    // resurssien vapautus 
                    reader.Close();
                    cmd2.Dispose();
                    conn2.Dispose();
                }
            }
        }
    }
}

