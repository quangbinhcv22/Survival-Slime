using System;

namespace DataCore
{
    [Serializable]
    public class Resource
    {
        public string type;
        public string id;
        public int number;

        public string IconAddress => $"{type}_{id}";
    }
}