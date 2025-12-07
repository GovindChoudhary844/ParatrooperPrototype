using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFanSpin : MonoBehaviour
{
    [SerializeField] private Transform backFan;

    [SerializeField] private float leftFanSpeed = 1000f;

    void Update()
    {

        // Left fan spins around X-axis
        backFan.Rotate(0, 0, leftFanSpeed * Time.deltaTime);
    }
}
