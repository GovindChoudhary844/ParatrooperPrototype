using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Waypoints (GameObjects)")]
    public List<Transform> stairPoints;   // <- swap RectTransform -> Transform

    [Header("Enemy(s)")]
    [SerializeField] private List<Transform> enemyList;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int moveDirection = 1;   // 1 right, -1 left

    private bool isMoving;
    //private Animator animator;

    private void Move()
    {
        if (isMoving) return;
        isMoving = true;

        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        ReArrangeEnemies();

        Transform enemyTf = enemyList[0];

        var paraAnimation = enemyTf.GetComponent<ParatrooperAnimation>();
        paraAnimation.StartWalking(true);

        Vector3 currentPos = enemyTf.position;

        int targetIndex = 0;
        int currentWayPointIndex = 0;
        int currentMaxWayPointCount = 0;
        Vector3 targetPos = stairPoints[currentWayPointIndex].position;

        while (targetIndex < stairPoints.Count)
        {
            // Move towards target
            currentPos = Vector3.MoveTowards(currentPos, targetPos, moveSpeed * Time.deltaTime);
            enemyTf.position = currentPos;

            // Reached waypoint?
            if (Vector3.Distance(currentPos, targetPos) <= 0.01f)
            {
                if (currentMaxWayPointCount > currentWayPointIndex)
                {
                    currentWayPointIndex++;
                    if (currentMaxWayPointCount == currentWayPointIndex)
                    {
                        targetPos = stairPoints[targetIndex].position;
                    }
                    else
                    {
                        switch (currentWayPointIndex)
                        {
                            case 1: // vertical step
                                targetPos = new Vector3(currentPos.x, stairPoints[2].position.y, currentPos.z);
                                break;

                            case 2: // horizontal step
                                
                                Vector3 basePos = stairPoints[targetIndex - 1].position;
                                float offsetX = (targetIndex == 3) ? stairPoints[targetIndex].localScale.x : 0f;
                                targetPos = new Vector3(basePos.x - offsetX * moveDirection, currentPos.y, currentPos.z);
                                
                                break;

                            case 3: // vertical step
                                targetPos = new Vector3(currentPos.x, stairPoints[targetIndex].position.y, currentPos.z);
                                break;

                            default: // fallback
                                targetPos = stairPoints[targetIndex].position;
                                break;
                        }
                    }
                    continue;
                }
                else
                {
                    paraAnimation.StartWalking(false);

                    targetIndex++;
                    if (targetIndex >= stairPoints.Count) yield break;

                    currentWayPointIndex = 0;
                    targetPos = stairPoints[targetIndex].position;
                    enemyTf = enemyList[targetIndex];

                    paraAnimation = enemyTf.GetComponent<ParatrooperAnimation>();
                    paraAnimation.StartWalking(true);

                    currentPos = enemyTf.position;

                    if (targetIndex > 1)
                    {
                        currentMaxWayPointCount = (targetIndex % 2 == 0) ? targetIndex : targetIndex + 1;
                        targetPos = stairPoints[1].position - Vector3.right * stairPoints[1].localScale.x * moveDirection;
                    }
                }
            }
            yield return null;
        }
    }

    private void ReArrangeEnemies()
    {
        // Rearrange enemies in the list based on their current X position distance from stairPoints[0]
        enemyList.Sort((a, b) =>
        {
            float distA = Mathf.Abs(a.position.x - stairPoints[0].position.x);
            float distB = Mathf.Abs(b.position.x - stairPoints[0].position.x);
            return distA.CompareTo(distB);
        });
    }

    public void AddTroop(Transform enemy)
    {
        if (!enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);
            if (enemyList.Count >= 4)
            {
                Move();
            }
        }
    }

}