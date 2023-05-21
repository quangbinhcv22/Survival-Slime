using UnityEngine;

public class Active_StarGun : MonoBehaviour
{
    public Active_StarBullet cellPrefab;
    public int numberOfObjects = 3;
    public float radius = 5f;
    public float speed = 5f;

    [Space] [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;


    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0f, 1.5f);
    }

    public void OnHit(GameObject bullet, GameObject other)
    {
        if (other.GetComponent<OldEnemy>())
        {
            Destroy(other);
            Destroy(bullet);

            audioSource.PlayOneShot(clip);
        }
    }

    private void Shoot()
    {
        var angleStep = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            var cell = Instantiate(cellPrefab, transform, true);
            cell.root = this;

            cell.transform.localPosition = Vector3.zero;


            var angle = i * angleStep;
            var x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

            cell.Shoot(new Vector3(x, y, 0).normalized);
        }
    }
}