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
        public string connectionString { get; set; } = @"Data Source=.\SQLEXPRESS;Integrated Security=true;database={0}";
        public string DatabaseName { get; set; } = "testdatabase";
        public string TableName { get; set; }

        public void CreateDatabase(string newdatabase)
        {
            var databas = new Database();
            var sql = $@"CREATE DATABASE {newdatabase}";

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
	                    [Firstname] [nvarchar](50) NULL,
	                    [Lastname] [nvarchar](50) NULL,
	                    [Birthyear] [int] NULL,
	                    [Deathyear] [int] NULL,
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

        //Add person/shark to database
        public void AddPerson(PersonsOrSharks Shark)
        {
            string sql = $"INSERT INTO {TableName} (Firstname, Lastname, Birthyear, Deathyear, Parent1, Parent2) VALUES (@FName, @LName, @BYear, @DYear, @Mother, @Father)";

            var parameters = new (string, string)[]
            {
                ("@FName", Shark.firstname),
                ("@LName", Shark.lastname),
                ("@BYear", Shark.birthYear.ToString()),
                ("@DYear", Shark.deathYear.ToString()),
                ("@Mother", Shark.parent1Id.ToString()),
                ("@Father", Shark.parent2Id.ToString()),
            };
            ExecuteSQLWithPar(sql, parameters);
        }

        //Add sharks to database
        public void AddSharkData()
        {
            AddPerson(new PersonsOrSharks { firstname = "Grandma", lastname = "Shark", birthYear = 1961 });
            AddPerson(new PersonsOrSharks { firstname = "Grandpa", lastname = "Shark", birthYear = 1959 });
            AddPerson(new PersonsOrSharks { firstname = "Daddy", lastname = "Shark", birthYear = 1986, parent1Id = 1, parent2Id = 2 });
            AddPerson(new PersonsOrSharks { firstname = "Mommy", lastname = "Von Sharkton", birthYear = 1989, parent1Id = 6, parent2Id = 5 });
            AddPerson(new PersonsOrSharks { firstname = "Granpapy", lastname = "Von Sharkton", birthYear = 1954 });
            AddPerson(new PersonsOrSharks { firstname = "Granny", lastname = "Von Sharkton", birthYear = 1964, deathYear = 2012 });
            AddPerson(new PersonsOrSharks { firstname = "Aunty", lastname = "Von Sharkton", birthYear = 1985, parent1Id = 6, parent2Id = 5 });
        }

        public void GetSharkId()
        {

        }

        public void AddParents()
        {

        }

        public void UpdateNames()
        {

        }

        public void ListSiblings()
        {

        }

        public void ListFamily()
        {

        }

        public void BabySharkDooDooDoo()
        {
            //UpdateName(Baby-Yellow, Shark, Baby, Shark);
            //UpdateName(Baby-Blue, Shark, Baby, Shark);
            //UpdateName(Baby-Pink, Shark, Baby, Shark);

            string songColumn = "Song";

            AddColumn(songColumn);
            //TODO: AddToSong(Sharkfamily, doo, doo, doo, doo, doo, doo)
            Console.WriteLine($"Let's go hunt, doo, doo, doo, doo, doo, doo" +
            $"\nLet's go hunt, doo, doo,…");
        }

        private void AddColumn(string columnName)
        {
            string sql = $"ALTER TABLE {TableName} ADD {columnName} varchar(255)";
            ExecuteSQL(sql);
        }

        private void AddToSong()
        {
            

        }

        //SQL method without parameters
        private void ExecuteSQL(string sql)
        {
            var cnn = OpenConnection();
            var cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
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
                cmd.ExecuteNonQuery();
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
            return cnn;
        }


    }
}
