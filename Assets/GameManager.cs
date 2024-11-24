using UnityEngine;

public class GameManager : MonoBehaviour
{
  public  GameObject[] duringLevel;
   public GameObject[] postLevel;

   [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] GameObject circuitSystem;
    [SerializeField] SpriteRenderer upgraderSprite;

    bool firstSpawn = false;

   public bool isPostGame;

    private void Start()
    {
        DisableGameObjects(postLevel, false);
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        upgraderSprite.enabled = false;
        isPostGame = false;
    }

    public void DisableGameObjects(GameObject[] objects, bool enabled)
    {
        for (int i = 0; i < objects.Length; i++) 
        {
            objects[i].gameObject.SetActive(enabled);
        }
        isPostGame = enabled;
        upgraderSprite.enabled=enabled;
        if (firstSpawn && !enabled) { StartCoroutine(enemySpawner.SpawnFish(CalculateSpawnAmount())); }
        else { firstSpawn = true; }
        
    }

    int CalculateSpawnAmount()
    {
       int enemyAmount =  enemySpawner.currentLevel *5;
       

        return enemyAmount;
    }
}
