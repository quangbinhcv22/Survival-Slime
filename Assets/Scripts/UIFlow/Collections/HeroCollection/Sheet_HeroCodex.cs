using Plugins.QB_UI.Core;
using UnityEngine;

namespace UIFlow.Collections.HeroCollection
{
    public class Sheet_HeroCodex : Panel
    {
        [Space] [SerializeField] private UI_EntityModel model;

        private HeroData _current;

        
        private void OnEnable()
        {
            GameSelection.CollectionHero.onSelect += OnSelect;
        }
        
        private void OnDisable()
        {
            GameSelection.CollectionHero.onSelect -= OnSelect;
        }

        public void OnSelect(string id)
        {
            _current = PlayerData_Query.HeroOf(id);
            model.Load(_current.Address_ModelUI);
        }
    }
}