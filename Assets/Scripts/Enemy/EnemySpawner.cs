using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerInput player;
    public GameObject deadPosition;

    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] int fishToSpawn = 10; 
  [SerializeField]  Enemy[] enemies;
  public List <Enemy> enemiesList;
    [SerializeField] float timeInBetweenSpawn = 1.5f;
   [SerializeField] GameManager gameManager;
    public int currentLevel = 0;
    [SerializeField]    LevelSettings[] levelSettings;
    [SerializeField] private int swordFishToSpawn;
    [SerializeField] private int turtlesToSpawn;
    [SerializeField] private int jellyFishToSpawn;
    [SerializeField] private int octopusToSpawn;
    [SerializeField] private int eelToSpawn;
    [SerializeField] private int sharkToSpawn;
    [SerializeField] Enemy swordFishGO, jellyFishGo, turtleGo;
    private void Start()
    {     
        player = FindFirstObjectByType<PlayerInput>();
        StartCoroutine(SpawnFish(fishToSpawn));
    }

    void SetValuesOfSpawn()
    {
        // -1 to get position of array
        // not being used in vertical slice
        swordFishToSpawn = levelSettings[currentLevel -1].SwordFishToSpawn;
        turtlesToSpawn = levelSettings[currentLevel -1].TurtlesToSpawn;
        jellyFishToSpawn = levelSettings[currentLevel - 1].JellyFishToSpawn;

        
    }

 public IEnumerator SpawnFish(int o)
    {
        // increases the level
        //
        currentLevel++;

        print($"current leve{currentLevel}");

        SetValuesOfSpawn();



       /* for (int i = 0; i < swordFishToSpawn; i++)
        {
            print($"swordfish remaining {swordFishToSpawn}");
            Enemy newSwordFish = Instantiate(swordFishGO, spawnPoints[ChooseSpawnPoint()].transform);

            enemiesList.Add(newSwordFish);

            print("spawned a swordFISH");

            yield return new WaitForSeconds(timeInBetweenSpawn);
        }*/


        if(o == 0)
        {
            currentLevel++;
            yield break;
        }

        // spawns the enemies randomly
        for (int i = 0; i < o; i++)
        {
           Enemy newEnemy =  Instantiate(enemies[ChooseEnemyToSpawn()], spawnPoints[ChooseSpawnPoint()].transform);

            enemiesList.Add(newEnemy);

            yield return new WaitForSeconds(timeInBetweenSpawn);
        }


        yield return new WaitForSeconds(3);

        StartCoroutine(checkForEndOfLevel());

       
        

        
    }

    

    IEnumerator checkForEndOfLevel()
    {
        // if there are no enemies left end the level, if there are, wait and try again
        yield return new WaitForSeconds(3);
     
        if (enemiesList.Count == 0)
        {
            print("The Level has ended.");
            gameManager.DisableGameObjects(gameManager.postLevel, true);
        }
        else
        {
            StartCoroutine(checkForEndOfLevel());
            Debug.Log("Level has not yet ended because enemies are still alive.");
        }
    }

    int ChooseSpawnPoint()
    {
        // there are 10 or so spawn points, choose a random one
        int poop = Random.Range(0, spawnPoints.Length);
        return poop;
    }
    int ChooseEnemyToSpawn()
    {
        // there are  or so enemies, choose a random one

        int pee = Random.Range(0, enemies.Length );
        return pee;
    }

}
