using dungeons_and_heroes.characters;

namespace dungeons_and_heroes.characters.archetypes
{
    public class Cleric : Character
    {
        List<CharacterAction> actions = new List<CharacterAction>();
        public override char CharacterSymbol => 'C';
        public override List<CharacterAction> Actions => this.actions;

        public override int MoveDistanceModifier => 3;

        public Cleric(string name, Race race, bool isPlayer, int level) : base(name, race, isPlayer)
        {
            IsPlayer = isPlayer;
            Health = 8 + race.HealthAdjustment;
            actions.AddRange(new List<CharacterAction> { 
                CharacterAction.Move
                , CharacterAction.Wait 
            });
        }

        public int Heal(bool isBigHeal){
            if(isBigHeal){
                return 10;
            }else{
                return 5;
            }
        }
        
        public override string IntroduceYourself(){
            return string.Format("Hi, I am a {0} {1} and my name is {2}. Nice to Meet You!", Race.Name, this.GetType().Name, Name);
        }
    }
}
