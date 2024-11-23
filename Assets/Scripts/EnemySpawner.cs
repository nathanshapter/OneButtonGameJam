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

   List <Enemy> enemiesList;

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
            Instantiate(enemies[ChooseEnemyToSpawn()], spawnPoints[ChooseSpawnPoint()].transform);

            yield return new WaitForSeconds(timeInBetweenSpawn);
        }


        yield return new WaitForSeconds(3);

        

        print("next level?");
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
