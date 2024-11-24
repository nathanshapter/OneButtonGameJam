using UnityEngine;

public class SpawnedObjectMovement : MonoBehaviour
{
  



    private void Start()
    {
  
    }
    void Update()
    {
        Vector2 targetPos = FindFirstObjectByType<DeadPosition>().transform.position;

        float currentY = this.transform.position.y;


        // freezes movement on Y
        Vector2 newPos =   Vector2.MoveTowards(this.transform.position, new Vector2(targetPos.x, currentY), 2 * Time.deltaTime);

       

        this.transform.position = newPos;
    }
}
