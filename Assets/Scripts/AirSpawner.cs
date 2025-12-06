using System.Collections;
using UnityEngine;

public class AirSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject helicopterPrefab;
    [SerializeField] private GameObject planePrefab;

    [Header("Spawning")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform destroyPoint;
    [SerializeField] private float normalSpeed = 3f;
    [SerializeField] private float planeSpeed = 4f;

    [Header("Timing")]
    [SerializeField] private float helicopterDuration = 15f;
    [SerializeField] private int planeCount = 2; // 2-3 planes
    [SerializeField] private float planeSpawnDelay = 1f;

    void Start() => StartCoroutine(SwitchLoop());

    private IEnumerator SwitchLoop()
    {
        while (true)
        {
            // 1. helicopters for 15 s
            yield return HelicopterPhase();

            // 2. planes for 15 s (spawn 2-3 quickly)
            yield return PlanePhase();

            // repeat
        }
    }

    private IEnumerator HelicopterPhase()
    {
        float endTime = Time.time + helicopterDuration;
        while (Time.time < endTime)
        {
            SpawnHelicopter();
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    private IEnumerator PlanePhase()
    {
        int count = Random.Range(planeCount, planeCount + 2); // 2-3
        for (int i = 0; i < count; i++)
        {
            SpawnPlane();
            yield return new WaitForSeconds(planeSpawnDelay);
        }
    }

    private void SpawnHelicopter()
    {
        GameObject heli = Instantiate(helicopterPrefab, spawnPoint.position, Quaternion.identity);
        heli.GetComponent<HelicopterMovement>().Init(normalSpeed, Vector2.right, destroyPoint.position.x);
    }

    private void SpawnPlane()
    {
        GameObject plane = Instantiate(planePrefab, spawnPoint.position, Quaternion.identity);
        plane.GetComponent<HelicopterMovement>().Init(planeSpeed, Vector2.right, destroyPoint.position.x);
        plane.transform.rotation = Quaternion.Euler(0, 0, 0); // face left if you want
    }
}