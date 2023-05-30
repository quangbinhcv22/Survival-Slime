using UIFlow.Collections.HeroCollection;
using UIFlow.Collections.PetCollection;

namespace UIFlow.Collections
{
    public static class PlayerData_Query
    {
        public static HeroData HeroOf(string id)
        {
            return new()
            {
                id = id,
                level = 1,
                star = 1,
            };
        }
        
        public static PetData PetOf(string id)
        {
            return new()
            {
                id = id,
                level = 1,
                star = 1,
            };
        }
    }
}