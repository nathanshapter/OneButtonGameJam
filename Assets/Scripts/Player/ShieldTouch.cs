using UnityEngine;

public class ShieldTouch : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hello");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hello");
    }

}
