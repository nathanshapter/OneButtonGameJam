using UnityEngine;

public class PlayerOptionSelector : MonoBehaviour
{

   public int currentUpgradeID;


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.GetComponent<WaypointCollider>() != null) 
        {
            int i = collision.gameObject.GetComponent<WaypointCollider>().ID;
            currentUpgradeID = i;
           
        }
        
        

       
    }
}
