using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace SharkFamilyTree
{
    class Database
    {
        //Kopplar till databas, går att ändra:
        public string connectionString { get; set; } = @"Data Source=.\SQLEXPRESS;Integrated Security=true;database={0}";
        public string DatabaseName { get; set; } = "testdatabase";
        public string TableName { get; set; }

        public void CreateDatabase(string newdatabase)
        {
            var databas = new Database();
            var sql = "CREATE DATABASE " + newdatabase;

            try
            {
                ExecuteSQL(sql);
                Console.WriteLine($"Database {newdatabase} was created");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"Database {newdatabase} already exist");
            }

            DatabaseName = newdatabase;
        }

        public void CreateTables(string tableName)
        {
            TableName = tableName;

            string sql = $@"CREATE TABLE [dbo].{TableName}(
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
	                    [FName] [nvarchar](50) NULL,
	                    [LName] [nvarchar](50) NULL,
	                    [BYear] [int] NULL,
	                    [DYear] [int] NULL,
	                    [Parent1] [int] NULL,
	                    [Parent2] [int] NULL
                        ) ON [PRIMARY]";

            try
            {
                ExecuteSQL(sql);
                Console.WriteLine($"New table was created: {TableName}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{TableName} already exist");
            }
        }

        //SQL method without parameters
        private void ExecuteSQL(string sql)
        {
            var cnn = OpenConnection();
            var cmd = new SqlCommand(sql, cnn);
            Console.WriteLine($"{cmd.ExecuteNonQuery()} rows affected!");
            cnn.Close();
        }

        //SQL method with parameters
        private void ExecuteSQLWithPar(string sqlString, params (string, string)[] parameters)
        {
            SqlConnection cnn = OpenConnection();
            
            using (var cmd = new SqlCommand(sqlString, cnn))
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Item1, item.Item2);
                }
                Console.WriteLine($"{cmd.ExecuteNonQuery()} rows affected!");
            }

            cnn.Close();
        }

        private DataTable GetDataTable(string sqlString, params (string, string)[] parameters)
        {
            var dt = new DataTable();
            var cnn = OpenConnection();

            using (var cmd = new SqlCommand(sqlString, cnn))
            {
                foreach (var par in parameters)
                {
                    cmd.Parameters.AddWithValue(par.Item1, par.Item2);
                }
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            cnn.Close();
            return dt;
        }

        //Connect to database
        private SqlConnection OpenConnection()
        {
            var conString = string.Format(connectionString, DatabaseName);
            var cnn = new SqlConnection(conString);
            cnn.Open();
            Console.WriteLine($"Using database: {cnn.Database}");
            return cnn;
        }


    }
}
