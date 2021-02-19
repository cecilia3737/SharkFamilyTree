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
            db.ListFamily("Shark");

            Console.ReadKey();
            Console.WriteLine($"" +
                $"\n Daddy Shark meet Mommy Von Sharkton." +
                $"\n Daddy go to family dinner at the Von Sharktons." +
                $"\n This is Mommy Von Sharktons parents:");
            db.AddParents("Mommy", "Von Sharkton", "Granny", "Von Sharkton", "Granpapy", "Von Sharkton");
            db.ListParents("Mommy", "Von Sharkton");
            Console.WriteLine("" +
                $"\n Sadly Mrs Von Sharkton passed away a few years ago.");
            db.ListDeadSharks();
            
            Console.ReadKey();
            Console.WriteLine($"" +
                $"\n Daddy learns that Mommy have siblings." +
                $"\n The Von Sharkton siblings:");            
            db.ListSiblings("Mommy", "Von Sharkton");
            
            Console.ReadKey();
            Console.WriteLine($"" +
                $"\n Daddy Shark and Mommy Von Sharkton get married.");            
            db.UpdateNames("Mommy", "Von Sharkton", "Mommy", "Shark");
            
            Console.ReadKey();
            Console.WriteLine($"" +
                $"\n SCANDAL!! In the Shark-family, Granpapy Von Sharkton had an" +
                $"\n affair with unknown shark. Mama Shark got a half-sibling, Uncle Von Sharkton.");

            int parentID = db.GetSharkId("Granpapy", "Von Sharkton");
            int unknownParent = 0;

            db.AddChild("Uncle", "Von Sharkton", 1986, unknownParent, parentID);

            Console.WriteLine($"" +
                $"\n This is the new list of siblings:");
            db.ListSiblings("Mommy", "Shark");
            
            Console.ReadKey();
            Console.WriteLine("" +
                $"\n This is the sharks who was born 1986:");
            db.ListByBirthyear(1986);

            Console.ReadKey();
            Console.WriteLine($"" +
                $"\n In 2016, Mommy and Daddy Shark got a baby, Baby-Yellow Shark.");
            
            int parent1ID = db.GetSharkId("Mommy", "Shark");
            int parent2ID = db.GetSharkId("Daddy", "Shark");

            db.AddChild("Baby-Yellow", "Shark", 2016, parent1ID, parent2ID);
            
            Console.ReadKey();
            Console.WriteLine($"" +
                $"\n Two years later, Baby-Yellow got two sibling!" +
                $"\n The twins was born, Baby-Blue and Baby-Pink");
            db.AddChild("Baby-Blue", "Shark", 2018, parent1ID, parent2ID);
            db.AddChild("Baby-Pink", "Shark", 2018, parent1ID, parent2ID);

            Console.ReadKey();
            Console.WriteLine("" +
                $"\n Oh, some confusion. There was only one baby! Not two.");
            db.DeleteShark("Baby-Pink", "Shark");
            Console.WriteLine(" This is the baby sharks:");
            db.ListSiblings("Baby-Yellow", "Shark");

            Console.ReadKey();           
            db.BabySharkDooDooDoo();

        }
    }
}
