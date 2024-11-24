using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
  [SerializeField]  GameObject[] boxes;
    [SerializeField] GameObject[] seaWeed;
    [SerializeField] GameObject[] corals;
    [SerializeField] GameObject[] decor;
    [SerializeField] GameObject[] shadows;

    [SerializeField] GameObject coralSpawn;

    private void Start()
    {
       GameObject newObject =  Instantiate(corals[7], coralSpawn.transform);

        newObject.AddComponent<SpawnedObjectMovement>();
       
    }
}
