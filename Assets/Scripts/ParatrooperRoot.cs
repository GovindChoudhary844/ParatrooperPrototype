using UnityEngine;

public class ParatrooperRoot : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject destroyParticlePrefab; // trooper death fx

    [Header("Parachute")]
    [SerializeField] private GameObject parachute; // drag the Parashoot child here

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!c.CompareTag("Bullet")) return;

        // 1. particle
        if (destroyParticlePrefab != null)
            Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);

        // 2. destroy parachute (if still there)
        if (parachute != null) Destroy(parachute);

        // 3. destroy bullet + trooper
        Destroy(c.gameObject);
        Destroy(gameObject);
    }
}