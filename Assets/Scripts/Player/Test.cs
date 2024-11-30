using UnityEngine;

public class Test : MonoBehaviour
{
    PlayerWallet wallet;

    [SerializeField] float knockBackForce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        wallet = FindFirstObjectByType<PlayerWallet>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  print("hello");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            enemy.hitByShield = true;

            enemyHealth.TakeDamage();

            wallet.cash += enemy.coinGiven;

            KnockBack(collision);

            enemy.Die();

            
        }




    }

    private void KnockBack(Collision2D collision)
    {
        Rigidbody2D getRB = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
       getRB.AddForce(knockbackDirection, ForceMode2D.Impulse);
        print("called");
    }

    


}
