using UnityEngine;

public class ParachuteHit : MonoBehaviour
{
    [SerializeField] private GameObject parachuteDestroyParticle; // drag particle prefab

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!c.CompareTag("Bullet")) return;

        // particle
        if (parachuteDestroyParticle != null)
            Instantiate(parachuteDestroyParticle, transform.position, Quaternion.identity);

        // tell parent the chute is gone
        ParachuteManager pm = transform.GetComponentInParent<ParachuteManager>();
        if (pm) pm.ParachuteDestroyed();

        Destroy(gameObject);   // destroy only the parachute child
        GameManager.Instance.AddScore(5);
        Destroy(c.gameObject); // bullet
    }
}