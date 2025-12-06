using UnityEngine;

public class PlaneBombDropper : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float dropOffsetY = -0.5f;
    [SerializeField] private float dropTolerance = 0.3f;

    private Transform turret;
    private bool dropped = false;

    void Start()
    {
        // find live turret once
        GameObject t = GameObject.FindGameObjectWithTag("Turret");
        if (t != null) turret = t.transform;
    }

    void Update()
    {
        if (dropped || turret == null) return;

        // close enough on X-axis?
        if (Mathf.Abs(transform.position.x - turret.position.x) <= dropTolerance)
        {
            dropped = true;
            Vector3 spawnPos = transform.position + Vector3.up * dropOffsetY;
            Instantiate(bombPrefab, spawnPos, Quaternion.identity);
        }
    }
}