using System;

namespace UIFlow.Collections
{
    public static class GameSelection
    {
        public class Selection
        {
            private string _selected;

            public string Selected
            {
                get => _selected;
                set
                {
                    if (_selected == value) return;

                    _selected = value;
                    onSelect?.Invoke(_selected);
                }
            }

            public Action<string> onSelect;
        }

        public static Selection CollectionHero = new();
        public static Selection CollectionPet = new();
    }
}