using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dungeons_and_heroes.characters;

namespace dungeons_and_heroes.dungeons
{
    public class Field
    {
        public bool IsImpenetrable { get; }
        public bool IsPlayerStartPosition { get; }
        public Character OccupyingCharacter { get; set; }

        public Field(bool isImpenetrable, bool isPlayerStartPosition)
        {
            IsImpenetrable = isImpenetrable;
            IsPlayerStartPosition = isPlayerStartPosition;
        }
    }   
}
