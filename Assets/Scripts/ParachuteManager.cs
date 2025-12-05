using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ParachuteManager : MonoBehaviour
{
    [Header("Child GameObject that IS the parachute visuals")]
    [SerializeField] private GameObject parachute; // drag the child here

    [Header("Timing")]
    [SerializeField] private float openDelay = 0.1f; // seconds after spawn

    private bool onGround = false;

    void Start()
    {
        parachute.SetActive(false);                       // start closed
        Invoke(nameof(OpenParachute), openDelay);       // open shortly after drop
    }

    void OpenParachute()
    {
        if (!onGround) parachute.SetActive(true);
    }

    /* call this from your ground-check script (or use OnCollisionEnter2D here) */
    public void Landed()
    {
        onGround = true;
        parachute.SetActive(false);
    }

    /* ---------- optional self-contained ground check ---------- */
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Paratrooper"))
        {
            Landed();
        }
    }
}