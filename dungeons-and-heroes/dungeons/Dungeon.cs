using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dungeons_and_heroes.characters;

namespace dungeons_and_heroes.dungeons
{
    public abstract class Dungeon : IDungeon
    {
        public abstract char ImpenetrableSymbol { get; }
        public Field[,] Board { get; set; }
        public char PlayerStartSymbol { get; } = 'S';
        public char WallSymbol { get; } = '#';
        public char EmptySymbol { get; } = ' ';

        public static int smallMapWidth = 22;
        public static int bigMapWidth = 60;

        public void DrawDungeon()
        {
            for (int y = 0; y < Board.GetLength(1); y++)
            {
                string line = string.Empty;
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    char symbol = Board[x, y].IsImpenetrable ? WallSymbol : (Board[x, y].OccupyingCharacter != null ? Board[x, y].OccupyingCharacter.CharacterSymbol : EmptySymbol);
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
        
        public void Initialize(bool bigDungeon, List<Character> characters)
        {
            int columns = 0;
            int rows = 0;
            List<char> mapValues = new List<char>();
            if(!bigDungeon){
                columns = smallMapWidth;
                mapValues = DungeonMap.mapSmallValues;
            }else{
                columns = bigMapWidth;
                mapValues = DungeonMap.mapBigValues;
            }
            rows = mapValues.Count / columns;

            // Load Small Dungeon
            Board = new Field[columns, rows];   
            int row = 0;
            int column = 0;  
            bool isImpenetrable = true;
            bool isPlayerStartPosition = false;
            foreach (var mapValue in  DungeonMap.mapSmallValues)
            {
                isImpenetrable = (mapValue == WallSymbol);
                isPlayerStartPosition = (mapValue == PlayerStartSymbol);
                Board[column, row] = new Field(isImpenetrable, isPlayerStartPosition);
                column++;
                if(column == columns) {
                    row++;
                    column = 0;
                }
            }

            foreach(Character character in characters){
                Field newField = FindNewPlayerStartPosition();
                newField.OccupyingCharacter = character;
                
            }
        }
        private Field FindNewPlayerStartPosition(){
            foreach(Field field in Board){                
                if(field.IsPlayerStartPosition && (field.OccupyingCharacter==null)){
                    return field;
                }
            }
            throw new ArgumentException("No Player Position available!");
        }
    }
}