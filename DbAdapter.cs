using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPracticeConsoleApp
{
    internal class DbAdapter
    {
        public void getDataFromAdapter(string connString)
        {

            string sqlQuery = "SELECT * FROM Student";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connString);

            DataSet student = new DataSet();
            adapter.Fill(student);

            foreach(DataRow r in student.Tables[0].Rows)
                Console.WriteLine("\n{0}\t{1}\t\t{2}", r[0], r[1], r[2]);
        }

        public void updateDataFromAdapter(List<DbModel> dbModels , string connString)
        {

            string sqlQuery = "SELECT * FROM Student";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connString);
            SqlConnection sqlConnection = new SqlConnection(connString);
            string insertQuery = "INSERT INTO Student(Id, Name, age) VALUES(@id, @name, @age)";
            adapter.InsertCommand = new SqlCommand(insertQuery, sqlConnection);

            DataSet SchoolDb = new DataSet();
            adapter.Fill(SchoolDb);

            foreach(DbModel model in dbModels)
            {
                
                adapter.InsertCommand.Parameters.AddWithValue("@id", model.Id);
                adapter.InsertCommand.Parameters.AddWithValue("@name", model.Name);
                adapter.InsertCommand.Parameters.AddWithValue("@age", model.Age);

                sqlConnection.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                adapter.InsertCommand.Parameters.Clear();
                sqlConnection.Close();
            }
        }
    }
}
