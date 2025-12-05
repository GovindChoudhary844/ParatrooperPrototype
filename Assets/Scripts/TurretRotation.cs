using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    [SerializeField]private float rotationSpeed = 200f; // degrees per second

    private float currentRotation = 0f;

    void Update()
    {
        float input = 0f;

        // A/D or Left/Right Arrow Keys
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            input = 1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            input = -1f;

        currentRotation += input * rotationSpeed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, -90f, 90f);

        transform.localEulerAngles = new Vector3(0, 0, currentRotation);
    }
}