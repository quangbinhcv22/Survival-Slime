using Plugins.QB_UI.Core;
using UIFlow.Collections.PetCollection;
using UnityEngine;

namespace UIFlow.Collections
{
    public class Sheet_PetCodex : Panel
    {
        [Space] [SerializeField] private UI_EntityModel model;
        
        private PetData _current;
        
        
        private void OnEnable()
        {
            GameSelection.CollectionPet.onSelect += OnSelect;
        }
        
        private void OnDisable()
        {
            GameSelection.CollectionPet.onSelect -= OnSelect;
        }
        
        
        public void OnSelect(string id)
        {
            _current = PlayerData_Query.PetOf(id);
            
            model.Load(_current.Address_UI);
        }
    }
}