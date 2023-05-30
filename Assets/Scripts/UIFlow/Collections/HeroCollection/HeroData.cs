namespace UIFlow.Collections.HeroCollection
{
    public class HeroData
    {
        public string id;
        public int level;
        public int star;

        public string Address_ModelUI => $"ui_hero_{id}";
        public string Address_Sprite => $"sprite_hero_{id}";
        public string Address_Gameplay => $"hero_{id}";
    }
}