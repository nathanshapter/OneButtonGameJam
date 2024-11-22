using UnityEngine;

public class Enemy : MonoBehaviour
{
    
   [SerializeField] PlayerInput player;
    EnemySpawner spawner;
    [SerializeField] float movementSpeed = 20;

    private void Start()
    {
        spawner = GetComponentInParent<EnemySpawner>();
        player = spawner.player;
    }


    private void Update()
    {
        MoveEnemyTowardsPlayer();
    }

    private void MoveEnemyTowardsPlayer()
    {
        // calculate new position to go to
        Vector2 newPosition = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
