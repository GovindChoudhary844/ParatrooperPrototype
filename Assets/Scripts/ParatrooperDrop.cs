using UnityEngine;

public class ParatrooperDrop : MonoBehaviour
{
    [SerializeField] private GameObject paratrooperPrefab;
    [SerializeField][Range(0f, 1f)] private float dropChance = 0.6f; // 60 %
    [SerializeField] private Vector2 dropDelayRange = new Vector2(1f, 3f);

    void Start()
    {
        // roll the dice once per helicopter
        if (Random.value <= dropChance)
        {
            float delay = Random.Range(dropDelayRange.x, dropDelayRange.y);
            Invoke(nameof(DropOne), delay);
        }
    }

    void DropOne()
    {
        Vector3 dropPos = transform.position + Vector3.down * 0.5f; // below heli
        Instantiate(paratrooperPrefab, dropPos, Quaternion.identity);
    }
}