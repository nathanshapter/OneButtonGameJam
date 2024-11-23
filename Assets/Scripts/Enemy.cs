using UnityEngine;

public class Enemy : MonoBehaviour
{
    
   [SerializeField] PlayerInput player;
    EnemySpawner spawner;
    [SerializeField] float movementSpeed = 20;
    Animator anim;

    GameObject deadPosition;

   [SerializeField] bool isDead = false;

    Rigidbody2D rb;

    CircleCollider2D circleCollider;

    [SerializeField] float distanceToDMG = 1.39f;

    bool damagedPlayer = false;

    public int coinGiven;

    public int damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawner = GetComponentInParent<EnemySpawner>();
        player = spawner.player;
        anim = GetComponentInChildren<Animator>();
        deadPosition = spawner.deadPosition;
        circleCollider = GetComponent<CircleCollider2D>();
    }


    private void Update()
    {
        MoveEnemyTowardsPlayer();
        DisplayDistanceToTarget();
        if(!isDead)
            FlipOnX();

    }


    private void FlipOnX()
    {
        Vector2 direction = player.transform.position - transform.position;

        if (((direction.x > 0) && transform.localScale.x < 0) || (direction.x < 0 && transform.localScale.x > 0))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
    private void MoveEnemyTowardsPlayer()
    {
        if (isDead)
        {
            Vector2 goToDeadPosition = Vector2.MoveTowards(this.transform.position, deadPosition.transform.position, movementSpeed / 2 * Time.deltaTime);
            transform.position = goToDeadPosition;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            circleCollider.enabled = false;
            return; 
        }
        // calculate new position to go to

        if (!damagedPlayer) 
        {
            Vector2 newPosition = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
        else
        {
            Vector2 goToDeadPosition = Vector2.MoveTowards(this.transform.position, deadPosition.transform.position, movementSpeed  * Time.deltaTime);
            transform.position = goToDeadPosition;
           // rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            
        }
       
    }


    public void Die()
    {
        anim.SetBool("isDead", true);
        isDead = true;
    }

    private void DisplayDistanceToTarget()
    {
        // Calculate the distance between the enemy and the player
        float distanceToTarget = Vector2.Distance(transform.position, player.transform.position);
        

        if (distanceToTarget <= distanceToDMG && !isDead)
        {
           // print("player damaged");
            damagedPlayer = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            print("hello shield ");

           
        }
    }
}
