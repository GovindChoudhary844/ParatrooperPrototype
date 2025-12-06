using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] private GameObject turretDestroyParticlePrefab;

    // event any script can listen to
    public static System.Action OnTurretDestroyed;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!c.CompareTag("Paratrooper") && !c.CompareTag("Bomb")) return;

        // particle
        if (turretDestroyParticlePrefab != null)
            Instantiate(turretDestroyParticlePrefab, transform.position, Quaternion.identity);

        // notify listeners before suicide
        OnTurretDestroyed?.Invoke();

        Destroy(gameObject);
    }
}