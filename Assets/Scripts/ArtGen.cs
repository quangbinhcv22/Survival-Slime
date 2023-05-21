using System.Collections.Generic;
using UnityEngine;

public class ArtGen : MonoBehaviour
{
    public GameObject prefab;
    public List<Sprite> sprites;

    private void Start()
    {
        foreach (var sprite in sprites)
        {
            var rd = Instantiate(prefab, transform, true);
            rd.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;

            rd.name = sprite.name;
        }
    }
}