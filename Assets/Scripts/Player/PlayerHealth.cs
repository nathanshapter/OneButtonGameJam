using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 30;
    public float domeHealth = 100;
    PlayerAnim PlayerAnim;

    CanvasScript canvasScript;


    private void Start()
    {
        PlayerAnim = GetComponent<PlayerAnim>();
        canvasScript = FindFirstObjectByType<CanvasScript>();
        canvasScript.UpdateText(health, domeHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     //   print("henlooooooo");

        Enemy enemyCollision = collision.gameObject.GetComponent<Enemy>();

        TakeDamage(enemyCollision.damage);
    }

   public void TakeDamage(int damage)
    {
        health -= damage;

        if (damage < 0) 
        {
            StartCoroutine(PlayerAnim.AnimDamage());
            


            
        }
        if (health < 0) { Die(); }
        canvasScript.UpdateText(health, domeHealth);
    }


  

    void Die()
    {
        print("die check");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
