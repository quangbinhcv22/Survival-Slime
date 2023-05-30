using System;

namespace UIFlow.Collections.PetCollection
{
    [Serializable]
    public class PetData
    {
        public string id;
        public int level;
        public int star;

        public string Address_UI => $"ui_pet_{id}";
        public string Address_Sprite => $"sprite_pet_{id}";
        public string Address_Gameplay => $"pet_{id}";
    }
}