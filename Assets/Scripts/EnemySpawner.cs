using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerInput player;
    public GameObject deadPosition;


  [SerializeField]  Enemy[] enemies;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerInput>();
    }
}
