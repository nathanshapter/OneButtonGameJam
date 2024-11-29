using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelSettings", menuName = "Level Settings", order = 1)]
public class LevelSettings : ScriptableObject
{
    [Header("Spawn Settings")]
    [SerializeField] private int swordFishToSpawn;
    [SerializeField] private int turtlesToSpawn;
    [SerializeField] private int jellyFishToSpawn;
    [SerializeField] private int octopusToSpawn;
    [SerializeField] private int eelToSpawn;
    [SerializeField] private int sharkToSpawn;

    // Public properties to access the fields if needed
    public int SwordFishToSpawn => swordFishToSpawn;
    public int TurtlesToSpawn => turtlesToSpawn;
    public int JellyFishToSpawn => jellyFishToSpawn;
    public int OctopusToSpawn => octopusToSpawn;
    public int EelToSpawn => eelToSpawn;
    public int SharkToSpawn => sharkToSpawn;

    // not being used in vertical slice
}
