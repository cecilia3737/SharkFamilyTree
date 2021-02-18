using System;

namespace SharkFamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            string databasName = "FamilyTree";
            string tableName = "Sharkfamily";

            db.CreateDatabase(databasName);
            db.CreateTables(tableName);
            db.AddSharkData();



        }
    }
}
