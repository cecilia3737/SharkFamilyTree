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
                $"\n Grandma and Grandpa Shark get a babyboy-shark." +
                $"\n This is the Shark-family: ");
            //TODO: db.ListOfFamily(Shark);
            Console.ReadKey();

            Console.WriteLine($"" +
                $"\n Daddy Shark meet Mommy Von Sharkton." +
                $"\n Daddy get to meet Mommy Von Sharktons father: Granpapy Von Sharkton." +
                $"\n Sadly Granny Von Sharkton passed away a few years ago.");
            //TODO: db.AddParents(Mommy, Von Sharkton, Grandpapy, Von Sharkton, Granny, Von Sharkton);
            Console.ReadKey();

            Console.WriteLine($"" +
                $"\n Daddy learns that Mommy have siblings." +
                $"\n Mommy Von Sharktons siblings:");
            //TODO: db.ListSiblings(Mommy, Von Sharkton);
            Console.ReadKey();

            Console.WriteLine($"" +
                $"\n Daddy Shark and Mommy Von Sharkton get married.");
            //TODO: db.UpdateName(Mommy, Von Sharkton, Mommy, Shark);
            Console.ReadKey();

            Console.WriteLine($"" +
                $"\n SCANDAL!! In the Shark-family, Granpapy Von Sharkton had an" +
                $"\n affair with unknown shark. Mama Shark got a half sibling, Uncle Von Sharkton.");

            string firstname = "Uncle";
            string lastname = "Von Sharkton";
            int birthYear = 1986;
            int parentID = db.GetSharkId("Granpapy", "Von Sharkton");

            db.AddPerson(new PersonsOrSharks 
            { 
                firstname = firstname, 
                lastname = lastname, 
                birthYear = birthYear, 
                parent2Id = parentID 
            });

            Console.WriteLine($"" +
                $"\n This is Mommy Sharks siblings:");
            //TODO: db.ListSiblings(Mommy, Shark);
            Console.ReadKey();

            Console.WriteLine($"" +
                $"\n In 2016, Mommy and Daddy Shark got a baby, Baby-Yellow Shark.");
            
            firstname = "Baby-Yellow";
            lastname = "Shark";
            birthYear = 2016;
            int parent1ID = db.GetSharkId("Mommy", "Shark");
            int parent2ID = db.GetSharkId("Daddy", "Shark");

            db.AddPerson(new PersonsOrSharks
            {
                firstname = firstname,
                lastname = lastname,
                birthYear = birthYear,
                parent1Id = parent1ID,
                parent2Id = parent2ID
            });
            Console.ReadKey();

            Console.WriteLine($"" +
                $"\n Two years later, Baby-Yellow got two sibling!" +
                $"\n The twins was born, Baby-Blue and Baby-Pink");

            firstname = "Baby-Blue";
            lastname = "Shark";
            birthYear = 2018;

            db.AddPerson(new PersonsOrSharks
            {
                firstname = firstname,
                lastname = lastname,
                birthYear = birthYear,
                parent1Id = parent1ID,
                parent2Id = parent2ID
            });

            firstname = "Baby-Pink";

            db.AddPerson(new PersonsOrSharks
            {
                firstname = firstname,
                lastname = lastname,
                birthYear = birthYear,
                parent1Id = parent1ID,
                parent2Id = parent2ID
            });
            Console.ReadKey();
            Console.WriteLine("");
            db.BabySharkDooDooDoo();

        }
    }
}
