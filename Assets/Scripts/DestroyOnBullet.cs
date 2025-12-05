using UnityEngine;

public class DestroyOnBullet : MonoBehaviour
{
    [SerializeField] private GameObject destroyParticlePrefab; // drag particle here

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Bullet")) return;

        // spawn one-shot particle (auto-destroy when finished)
        if (destroyParticlePrefab != null)
            Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);

        // remove bullet and this object
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}