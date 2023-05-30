using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace UIFlow.Collections.HeroCollection
{
    public class CleanAddressable
    {
        [MenuItem("Tool/Clean Addressable")]
        public static void Clean()
        {
            var groups = AddressableAssetSettingsDefaultObject.GetSettings(false).groups;
            
            foreach (var group in groups)
            {
                foreach (var entry in group.entries)
                {
                    if(entry.MainAsset == null) continue;
                    
                    var oldName = entry.address;
                    var newName = entry.MainAsset.name;
                    
                    if(oldName == newName) continue;

                    Debug.Log($"{oldName} -> {newName}");
                    
                    entry.address = entry.MainAsset.name;
                }
            }
        }
    }
}