using UnityEngine;

public class HelicopterFanSpin : MonoBehaviour
{
    [SerializeField] private Transform topFan;
    [SerializeField] private Transform leftFan;

    [SerializeField] private float topFanSpeed = 1000f;
    [SerializeField] private float leftFanSpeed = 1000f;

    void Update()
    {
        // Top fan spins around Y-axis
        topFan.Rotate(0, topFanSpeed * Time.deltaTime, 0);

        // Left fan spins around X-axis
        leftFan.Rotate(leftFanSpeed * Time.deltaTime, 0, 0);
    }
}