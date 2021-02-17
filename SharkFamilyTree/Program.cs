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

            db.AddPerson(new PersonsOrSharks { firstname = "Grandma", lastname = "Shark", birthYear = 1961 });
            db.AddPerson(new PersonsOrSharks { firstname = "Grandpa", lastname = "Shark", birthYear = 1959 });
            db.AddPerson(new PersonsOrSharks { firstname = "Daddy", lastname = "Shark", birthYear = 1986, parent1Id = 1, parent2Id = 2 });
            db.AddPerson(new PersonsOrSharks { firstname = "Mommy", lastname = "Von Sharkton", birthYear = 1989, parent1Id = 6, parent2Id = 5 });
            db.AddPerson(new PersonsOrSharks { firstname = "Granpapy", lastname = "Von Sharkton", birthYear = 1954 });
            db.AddPerson(new PersonsOrSharks { firstname = "Granny", lastname = "Von Sharkton", birthYear = 1964, deathYear = 2012 });
            db.AddPerson(new PersonsOrSharks { firstname = "Aunty", lastname = "Von Sharkton", birthYear = 1985, parent1Id = 6, parent2Id = 5 });



        }
    }
}
