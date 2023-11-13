using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dungeons_and_heroes.characters
{
    public class Race
    {
        public string Name { get; set; }
        public int HealthAdjustment { get; set; }
        public int AttackAdjustment { get; set; }
        // ... other adjustments based on your requirements
        public Race(string name)
        {
            Name = name;
        }
    }
}
