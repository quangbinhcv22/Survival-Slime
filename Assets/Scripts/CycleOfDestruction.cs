using UnityEngine;

public class CycleOfDestruction : MonoBehaviour
{
    public CycleOfDestruction_Cell cellPrefab;
    public int numberOfObjects = 3;
    public float radius = 2f;

    [Space] [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;


    private void Start()
    {
        SpawnObjects();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObjects();
        }
    }

    public void OnHit(GameObject other)
    {
        if (other.GetComponent<OldEnemy>())
        {
            Destroy(other);
            audioSource.PlayOneShot(clip);
        }
    }

    private void SpawnObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        var angleStep = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            var cell = Instantiate(cellPrefab, transform, true);
            cell.root = this;

            var angle = i * angleStep;
            var x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

            cell.transform.localPosition = new Vector3(x, y, 0);
        }
    }
}