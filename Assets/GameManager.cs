using UnityEngine;

public class GameManager : MonoBehaviour
{
  public  GameObject[] duringLevel;
   public GameObject[] postLevel;

   [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] GameObject circuitSystem;

    bool firstSpawn = false;

    private void Start()
    {
        DisableGameObjects(postLevel, false);
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }

    public void DisableGameObjects(GameObject[] objects, bool enabled)
    {
        for (int i = 0; i < objects.Length; i++) 
        {
            objects[i].gameObject.SetActive(enabled);
        }
        if (firstSpawn && !enabled) { StartCoroutine(enemySpawner.SpawnFish(25)); }
        else { firstSpawn = true; }
        
    }
}
