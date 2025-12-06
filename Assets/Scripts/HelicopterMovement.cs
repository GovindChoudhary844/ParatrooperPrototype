using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    private float speed;      // default if you want
    private Vector2 direction;
    private float destroyX;

    public void Init(float spd, Vector2 dir, float endX)
    {
        speed = spd;
        direction = dir;
        destroyX = endX;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        bool reached = direction.x > 0
            ? transform.position.x >= destroyX
            : transform.position.x <= destroyX;

        if (reached)
        {
            // score: 30 plane, 20 heli
            int points = CompareTag("Plane") ? 30 : 20;
            ScoreManager.Instance.AddScore(points);

            Destroy(gameObject);
        }
    }
}