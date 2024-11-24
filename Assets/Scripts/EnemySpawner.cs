using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerInput player;
    public GameObject deadPosition;
    [SerializeField] GameObject spawnAreaFront, spawnAreaBack;

    [SerializeField] GameObject[] spawnPoints;

    [SerializeField] int fishToSpawn = 10;
 

  [SerializeField]  Enemy[] enemies;

  public List <Enemy> enemiesList;

    [SerializeField] float timeInBetweenSpawn = 1.5f;

    

    private void Start()
    {
     
        player = FindFirstObjectByType<PlayerInput>();
        StartCoroutine(SpawnFish());
    }

  IEnumerator SpawnFish()
    {
        

        if(fishToSpawn == 0)
        {
            // next level
            yield break;
        }


        for (int i = 0; i < fishToSpawn; i++)
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
        yield return new WaitForSeconds(3);
     
        if (enemiesList.Count == 0)
        {
            print("level has ended");
           // gameManager.EnablePostLevel(true);
        }
        else
        {
            StartCoroutine(checkForEndOfLevel());
            print("level has not yet ended, enemies are alive");
        }
    }

    int ChooseSpawnPoint()
    {
        int poop = Random.Range(0, spawnPoints.Length);
        return poop;
    }
    int ChooseEnemyToSpawn()
    {
        int pee = Random.Range(0, enemies.Length );
        return pee;
    }

}
