using System;
using System.Collections.Generic;
using System.Text;

namespace SharkFamilyTree
{
    class PersonsOrSharks
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int birthYear { get; set; }
        public int deathYear { get; set; }
        public int parent1Id { get; set; }
        public int parent2Id { get; set; }
    }
}
