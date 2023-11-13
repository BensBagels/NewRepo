namespace dungeons_and_heroes.characters
{
    public abstract class Character  {
        public abstract int MoveDistanceModifier { get; }
        public abstract char CharacterSymbol { get; }
        public abstract List<CharacterAction> Actions { get; }
        public string Name { get; set; } = string.Empty;        
        public Race Race { get; set; }
        protected bool IsPlayer { get; set; }
        public int Health { get; set; } = 10;
        public int MoveDistance { get; set; } = 5;
        public Character(string name, Race race, bool isPlayer) {
            Name = name;    
            Race = race;         
            IsPlayer = isPlayer;
        }

        public virtual string IntroduceYourself(){
            return string.Format("Hi,i am a {0} and my name is {1}.",  Race.Name, Name);
        }
    }
}
