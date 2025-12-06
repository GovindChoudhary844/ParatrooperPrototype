using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ParachuteManager : MonoBehaviour
{
    [Header("Parachute")]
    [SerializeField] private GameObject parachute; // drag child here

    [Header("Death Prefab")]
    [SerializeField] private GameObject deathPrefab;

    [Header("Timing")]
    [SerializeField] private float openDelay = 0.2f;

    private bool onGround = false;
    private bool paraIsDestroyed = false;

    private Rigidbody2D rb;
    private float baseGravity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        baseGravity = rb.gravityScale;
    }

    void Start()
    {
        parachute.SetActive(false);
        Invoke(nameof(OpenParachute), openDelay);
    }

    void OpenParachute()
    {
        if (!onGround && !paraIsDestroyed)
        {
            parachute.SetActive(true);
            rb.gravityScale = baseGravity * 0.15f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    public void Landed()
    {
        onGround = true;
        if (parachute != null) parachute.SetActive(false);
        rb.gravityScale = baseGravity;

        if (paraIsDestroyed)
            DieWithPrefab();
    }

    private void DieWithPrefab()
    {
        // 1. spawn prefab
        GameObject dead = Instantiate(deathPrefab, transform.position, transform.rotation);

        // 2. destroy trooper
        Destroy(transform.root.gameObject);

        // 3. destroy prefab after 0.1 s (independent of trooper)
        Destroy(dead, 0.1f);
    }


    public void ParachuteDestroyed()
    {
        onGround = true;
        paraIsDestroyed = true;
        if (parachute != null)
        {
            parachute.SetActive(false);
            Destroy(parachute);
        }
        rb.gravityScale = baseGravity;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Paratrooper"))
            Landed();
    }
}