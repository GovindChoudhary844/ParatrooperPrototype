using UnityEngine;
using UnityEngine.Events;

public class DestroyOnBullet : MonoBehaviour
{
    [SerializeField] private GameObject destroyParticlePrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Bullet")) return;

        // particle
        if (destroyParticlePrefab != null)
            Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);

        Destroy(col.gameObject); // bullet
        Destroy(gameObject);     // myself
        ScoreManager.Instance.AddScore(10);
    }
}