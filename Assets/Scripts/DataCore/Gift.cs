using System;

namespace DataCore
{
    [Serializable]
    public class Gift : Resource
    {
        public GiftState state;
    }

    public enum GiftState
    {
        Locking = 0,
        CanClaim = 1,
        Claimed = 2,
    }
}