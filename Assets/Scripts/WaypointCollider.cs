using UnityEngine;

public class WaypointCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

       
            print("my battleship!");
            print(collision.name);
        
    
    }
}
