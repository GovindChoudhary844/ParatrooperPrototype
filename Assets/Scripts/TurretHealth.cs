using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] private GameObject TurrentdestroyParticlePrefab;

    void OnTriggerEnter2D(Collider2D c)
    {
        // particle
        if (TurrentdestroyParticlePrefab != null)
            Instantiate(TurrentdestroyParticlePrefab, transform.position, Quaternion.identity);

        if (c.CompareTag("Paratrooper"))
            Destroy(gameObject);
    }
}