using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public static Player Main;
    public static Transform Transform;

    [SerializeField] private float speed = 1;
    [SerializeField] private SpriteRenderer pet;

    
    private Transform _model;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (!child.name.ToLower().Contains("model")) continue;
            
            _model = child.transform;
            break;
        }
    }
    
    private void OnEnable()
    {
        Main = this;
        Transform = transform;
    }


    public static void Move(Vector2 direction)
    {
        Transform.position += new Vector3(direction.x, direction.y) * (Main.speed * Time.deltaTime);
        
        Main._model.Flip(direction);
        Main.pet.flipX = direction.x < 0;
    }
}