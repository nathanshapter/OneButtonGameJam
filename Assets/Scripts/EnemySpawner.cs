using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerInput player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerInput>();
    }
}
