using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPracticeConsoleApp
{
    internal class DbUtilities
    {
        public  List<DbModel> getData(string connString)
        {
            List<DbModel> list = new List<DbModel>();
            SqlConnection sqlconnection = new SqlConnection(connString);
            string sqlQuery = "SELECT * From Student";

            try
            {
                using (sqlconnection)
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlconnection);

                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            list.Add(new DbModel(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo data Found");
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("\nSqlException - {0} - {1}", ex.Number, ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nException: {0}", ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
            return list;
        }

        public void insertData(List<DbModel> list , string connString)
        {
            
            SqlConnection sqlconnection = new SqlConnection(connString);

            try
            {
                using (sqlconnection)
                {
                    foreach(DbModel model in list)
                    {
                        string sqlQuery = "INSERT INTO Student(Id, Name, age) VALUES(@id, @name, @age)";
                        SqlCommand cmd = new SqlCommand(sqlQuery, sqlconnection);
                        cmd.Parameters.AddWithValue("@id", model.Id);
                        cmd.Parameters.AddWithValue("@name", model.Name);
                        cmd.Parameters.AddWithValue("@age", model.Age);


                    sqlconnection.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result < 0)
                        {
                            Console.WriteLine("\nNo data Found");
                        }
                       
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("\nSqlException - {0} - {1}", ex.Number, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException: {0}", ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
