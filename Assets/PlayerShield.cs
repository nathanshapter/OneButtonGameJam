using UnityEngine;

public class CircularMotion2D : MonoBehaviour
{
    public GameObject centerObject;  // The object that will act as the center
    public float radius = 5f;        // The radius of the circle
    public float speed = 1f;         // Speed of the rotation (how fast it moves in the circle)
    public float rotationSpeed = 360f; // Rotation speed per orbit (degrees)

    private float angle = 0f;        // The starting angle (in radians)

    void Update()
    {
        // Make sure the center object is assigned
        if (centerObject != null)
        {
            // Update the angle based on the speed (this controls how fast the object moves around the circle)
            angle += speed * Time.deltaTime;

            // Calculate the position on the circle using sine and cosine (for 2D)
            float x = centerObject.transform.position.x + Mathf.Cos(angle) * radius;
            float y = centerObject.transform.position.y + Mathf.Sin(angle) * radius;

            // Update the object's position
            transform.position = new Vector3(x, y, transform.position.z); // Keep the Z position the same

            // Rotate the shield as it moves around the circle
            // We rotate by the same amount as the object moves around the circle, so the rotation matches the orbit
            float rotationAmount = rotationSpeed * (angle / (2 * Mathf.PI)); // 1 full rotation (360 degrees) for 1 full orbit (2π radians)
            transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
        }
    }
}
