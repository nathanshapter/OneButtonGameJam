using UnityEngine;

public class NaturalMovement : MonoBehaviour
{
    [SerializeField] float amplitude = 0.1f;  // The maximum amount of movement in each direction
    [SerializeField] float speed = 1f;        // The speed of the natural motion
    [SerializeField] float forwardSpeed = 2f; // The speed of the forward movement
    private Vector3 startPosition;

    private void Start()
    {
        // Record the initial position of the object
        startPosition = transform.position;
    }

    private void Update()
    {
        ApplyWaterMotionWithForwardMovement();
    }

    private void ApplyWaterMotionWithForwardMovement()
    {
        // Calculate the new offset using sine waves
        float offsetX = Mathf.Sin(Time.time * speed) * amplitude;
        float offsetY = Mathf.Cos(Time.time * speed * 0.8f) * amplitude; // Different frequency for more natural motion

        // Move the object forward on the X-axis
        startPosition += Vector3.right * forwardSpeed * Time.deltaTime;

        // Apply the combined forward and natural motion
        transform.position = startPosition + new Vector3(offsetX, offsetY, 0);
    }
}
