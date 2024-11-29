
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    // this script is not finished for the vertical slice
    //just uses coralspawn to spawn everything
    // ideally every array should be using their own spawn 
  [SerializeField]  GameObject[] boxes;
    [SerializeField] GameObject[] seaWeed;
    [SerializeField] GameObject[] corals;
    [SerializeField] GameObject[] decor;
    [SerializeField] GameObject[] shadows;
    [SerializeField] GameObject coralSpawn;  



    private void Start()
    {      
      StartCoroutine(SpawnItems());       
    }


    private IEnumerator SpawnItems()
    {
        // spawns a random weed, or coral, and then %20 chance of spawning a large item
        // starts itself again

        yield return new WaitForSeconds(Random.Range(0, 5));
       

        GameObject newWeed = Instantiate(seaWeed[Random.Range(0,seaWeed.Length)], coralSpawn.transform);
        newWeed.AddComponent<SpawnedObjectMovement>();
    

        yield return new WaitForSeconds(Random.Range(0, 3.5f));

        GameObject newCoral = Instantiate(corals[Random.Range(0, corals.Length)], coralSpawn.transform);
        newCoral.AddComponent<SpawnedObjectMovement>();

        yield return new WaitForSeconds(Random.Range(0, 3.5f));

        if (Random.Range(0,100) > 79)
        {
            GameObject newShip = Instantiate(decor[Random.Range(0, decor.Length)], coralSpawn.transform);
            newShip.AddComponent<SpawnedObjectMovement>();
           
        }
        StartCoroutine(SpawnItems());
    }

 

}
