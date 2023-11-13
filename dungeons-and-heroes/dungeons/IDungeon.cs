using dungeons_and_heroes.characters;

namespace dungeons_and_heroes.dungeons
{
    public interface IDungeon
    {
        public void DrawDungeon();
        public void Initialize(bool bigDungeon, List<Character> characters);
    }
}
