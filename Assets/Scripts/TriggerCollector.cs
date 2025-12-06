using System.Linq;
using UnityEngine;

public class TriggerCollector : MonoBehaviour
{
    public EnemyMovement enemyMovement; // drag the SAME EnemyMovement here

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!c.CompareTag("Paratrooper")) return;

        Transform t = c.transform;
        if (!enemyMovement.EnemyList.Contains(t))
        {
            enemyMovement.EnemyList.Add(t);
            if (enemyMovement.EnemyList.Count >= 4)
                enemyMovement.Move();
        }
    }
}