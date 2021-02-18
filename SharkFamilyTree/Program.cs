using System;
using System.ComponentModel;

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

            Console.WriteLine($"_______________________________________________________" +
                $"\n" +
                $"\nGrandma and Grandpa Shark get a babyboy-shark." +
                $"\nThis is the Shark-family: ");
            //TODO: db.ListOfFamily(Shark);

            Console.WriteLine($"Daddy meet Mommy Von Sharkton." +
                $"\nDaddy get to meet Mommy Von Sharktons father: Grandpapy Von Sharkton." +
                $"\nSadly Granny Von Sharkton passed away a few years ago.");
            //TODO: db.AddParents(Mommy, Von Sharkton, Grandpapy, Von Sharkton, Granny, Von Sharkton);

            Console.WriteLine($"Daddy learns that Mommy have siblings." +
                $"\nMommy Von Sharktons siblings:");
            //TODO: db.ListSiblings(Mommy, Von Sharkton);

            Console.WriteLine($"Daddy and Mommy get married.");
            //TODO: db.UpdateName(Mommy, Von Sharkton, Mommy, Shark);

            Console.WriteLine($"SCANDAL!! In the Shark-family, Grandpapy Von Sharkton had an" +
                $"\naffair with unknown shark. Mama Shark got a half sibling, Uncle Von Sharkton.");

            string firstname = "Uncle";
            string lastname = "Von Sharkton";
            int birthYear = 1986;
            //int parentID = db.GetPersonID(Grandpapy, Von Sharkton);

            db.AddPerson(new PersonsOrSharks 
            { 
                firstname = firstname, 
                lastname = lastname, 
                birthYear = birthYear, 
                parent2Id = 0 
            });

            Console.WriteLine($"This is Mommy Sharks siblings:");
            //TODO: db.ListSiblings(Mommy, Shark);

            Console.WriteLine($"In 2016, Mommy and Daddy Shark got a baby, Baby-Yellow Shark.");
            
            firstname = "Baby-Yellow";
            lastname = "Shark";
            birthYear = 2016;
            //TODO: int parent1ID = db.GetPersonID(Mommy, Shark);
            //TODO: int parent1ID = db.GetPersonID(Daddy, Shark);

            db.AddPerson(new PersonsOrSharks
            {
                firstname = firstname,
                lastname = lastname,
                birthYear = birthYear,
                parent1Id = 0,
                parent2Id = 0
            });

            Console.WriteLine($"Two years later, Baby-Yellow got two sibling!" +
                $"\nThe twins was born, Baby-Blue and Baby-Pink");

            firstname = "Baby-Yellow";
            lastname = "Shark";
            birthYear = 2018;
            //TODO: int parent1ID = db.GetPersonID(Mommy, Shark);
            //TODO: int parent1ID = db.GetPersonID(Daddy, Shark);

            db.AddPerson(new PersonsOrSharks
            {
                firstname = firstname,
                lastname = lastname,
                birthYear = birthYear,
                parent1Id = 0,
                parent2Id = 0
            });

            firstname = "Baby-Yellow";

            db.AddPerson(new PersonsOrSharks
            {
                firstname = firstname,
                lastname = lastname,
                birthYear = birthYear,
                parent1Id = 0,
                parent2Id = 0
            });

            // TODO: Add in database-class
            //db.BabySharkDooDooDoo();
            //UpdateName(Baby-Yellow, Shark, Baby, Shark);
            //UpdateName(Baby-Blue, Shark, Baby, Shark);
            //UpdateName(Baby-Pink, Shark, Baby, Shark);

            //TODO: AddColumn(Song)
            //TODO: AddToSong(Sharkfamily, doo, doo, doo, doo, doo, doo)
            //Console.WriteLine($"Let's go hunt, doo, doo, doo, doo, doo, doo" +
            //$"\nLet's go hunt, doo, doo,…");

        }
    }
}
