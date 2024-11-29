using UnityEngine;

public class GameManager : MonoBehaviour
{
  public  GameObject[] duringLevel;
   public GameObject[] postLevel;

   [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] GameObject circuitSystem;
    [SerializeField] SpriteRenderer upgraderSprite, playerSprite, shieldSprite, shield2Sprite;

    bool firstSpawn = false;

   public bool isPostGame;
  [SerializeField]  WaypointCollider waypointCollider;

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
        playerSprite.enabled=!enabled;
        shieldSprite.enabled=!enabled;
        if(waypointCollider.purchasedShield)
            shield2Sprite.enabled = !enabled;

        if (firstSpawn && !enabled) { StartCoroutine(enemySpawner.SpawnFish(CalculateSpawnAmount())); }
        else { firstSpawn = true; }
        
    }

    int CalculateSpawnAmount()
    {
       int enemyAmount =  enemySpawner.currentLevel *5;
       

        return enemyAmount;
    }
}
