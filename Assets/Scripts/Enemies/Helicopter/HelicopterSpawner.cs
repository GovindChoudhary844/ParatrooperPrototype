using UnityEngine;

public class HelicopterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject helicopterPrefab;
    [SerializeField] private Transform spawnPoint;   // drag ONLY your spawn transform here
    [SerializeField] private Transform destroyPoint; // drag ONLY your destroy transform here
    [SerializeField] private float speed = 3f;       // always positive

    void Start() => Spawn();

    void Spawn()
    {
        // which way do we have to go?
        Vector2 dir = spawnPoint.position.x < destroyPoint.position.x
            ? Vector2.right : Vector2.left;

        // spawn helicopter
        GameObject heli = Instantiate(helicopterPrefab, spawnPoint.position, Quaternion.identity);

        // face the direction of travel (rotate root 180° on Y for left)
        if (dir == Vector2.left)
            heli.transform.rotation = Quaternion.Euler(0, 180, 0);

        // give movement data
        HelicopterMovement m = heli.GetComponent<HelicopterMovement>();
        m.Init(speed, dir, destroyPoint.position.x);

        // next helicopter
        Invoke(nameof(Spawn), Random.Range(3f, 5f));
    }
}