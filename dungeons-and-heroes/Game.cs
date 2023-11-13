using dungeons_and_heroes.characters;
using dungeons_and_heroes.characters.archetypes;
using dungeons_and_heroes.dungeons;

namespace dungeons_and_heroes
{
    public class Game
    {
        public IDungeon Dungeon { get; set; }
        public List<Character> Characters { get; private set; }

        public Game()
        {
            Characters = new List<Character>();
        }

        public void StartGame()
        {
            this.Initialize();
            int turnNumber = 0;
            // Play as long as Characters are in the Dungeon
            // Gameloop
            while(this.Characters.Count >  0) {
                HandleTurn(turnNumber++);
            }
            Console.WriteLine("Dungeoncrawler says good bye!");
        }

        private void Initialize(){            
            Race humanRace = new Race("Human");
            Character myChar = new Cleric("Gondolino", humanRace, true, 1);
            this.Characters =  new List<Character>() {myChar};

            this.Dungeon = new CastleDungeon();
            this.Dungeon.Initialize(false, Characters);
        }

        private void HandleTurn(int turnNumber){
                Console.WriteLine("Turn {0}", turnNumber);
                foreach (Character character in Characters)
                {
                    Console.WriteLine($"It's {character.Name}'s turn.");
                    Console.WriteLine(character.IntroduceYourself());
                    this.Dungeon.DrawDungeon();
                    HandleCharacterTurn(character);
                }
        }
        
        private void HandleCharacterTurn(Character character)
        {
            Console.WriteLine("Choose an action: ");
            for (int i = 0; i < character.Actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {character.Actions[i]}");
            }

            int actionChoice = GetChoice(1, character.Actions.Count);
            CharacterAction chosenAction = character.Actions[actionChoice - 1];

            HandleAction(character, chosenAction);
        }

        private void HandleAction(Character character, CharacterAction chosenAction)
        {
            throw new NotImplementedException();
            switch (chosenAction)
            {
                case 0:
            }
        }

        private int GetChoice(int minValue, int maxValue)
        {
            int choice = -1;
            while (choice == -1)
            {
                int.TryParse(Console.ReadLine(), out choice);
                if(choice < minValue || choice > maxValue){                    
                    Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
                    choice = -1;
                }
            }
            return choice;
        }
    }
}
