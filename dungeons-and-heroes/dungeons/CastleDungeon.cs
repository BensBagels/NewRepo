using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dungeons_and_heroes.dungeons
{
    public class CastleDungeon : Dungeon
    {
        public CastleDungeon() 
        {            
        }

        public override char ImpenetrableSymbol => '#'; // WALL
    }
}
