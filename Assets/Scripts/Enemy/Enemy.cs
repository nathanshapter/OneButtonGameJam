using DG.Tweening;
using System.Collections;
using Unity.Cinemachine;
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
   [SerializeField] bool damagedPlayer = false;
    public int coinGiven;
    public int damage;
   [SerializeField] SpriteRenderer spriteRenderer;


    public bool hitByShield = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawner = GetComponentInParent<EnemySpawner>();
        player = spawner.player;
        anim = GetComponentInChildren<Animator>();
        deadPosition = spawner.deadPosition;
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
       
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
        // controls direction of x
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
        if (isDead) // go to the end position bottom left of screen
        {

            Vector2 goToDeadPosition = Vector2.MoveTowards(this.transform.position, deadPosition.transform.position, movementSpeed / 2 * Time.deltaTime);
            transform.position = goToDeadPosition;

            

            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            circleCollider.enabled = false;
            return; 
        }
        // calculate new position to go to

        if (!damagedPlayer) // go to player
        {
            Vector2 newPosition = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
        else
        {
            if (hitByShield)
            {
                return;
            }

            Vector2 goToDeadPosition = Vector2.MoveTowards(this.transform.position, deadPosition.transform.position, movementSpeed  * Time.deltaTime);
            transform.position = goToDeadPosition;
            spawner.enemiesList.Remove(this);
            // rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(DestroySelf());
        }
       
    }


    public void Die()
    {
        anim.SetBool("isDead", true);
        isDead = true;
        spawner.enemiesList.Remove(this);
        StartCoroutine(DestroySelf());
        spriteRenderer.DOFade(0, 3);
       
        
    }

   IEnumerator DestroySelf() // need this in case takes too long for enemy to get to dead position
    {
        yield return new WaitForSeconds(7);
        Destroy(this.gameObject);
    }

    private void DisplayDistanceToTarget()
    {
        // method has no use at the moment, may for future
        // Calculate the distance between the enemy and the player
        float distanceToTarget = Vector2.Distance(transform.position, player.transform.position);
        

        if (distanceToTarget <= distanceToDMG && !isDead)
        {
           // print("player damaged");
            damagedPlayer = true;

        }
    }


}
