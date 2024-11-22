using UnityEngine;

public class Test : MonoBehaviour
{
    PlayerWallet wallet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        wallet = FindFirstObjectByType<PlayerWallet>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hello");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            wallet.cash += enemy.coinGiven;
            
            enemy.Die();

            
        }
    }


}
