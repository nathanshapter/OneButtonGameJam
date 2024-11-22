using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] CircularPlatform cp;

    private void Start()
    {
        
    }

    void Update()
    {
        SpaceIncreaseSpeed();
    }

    void SpaceIncreaseSpeed() // this handles speeding up the shield
    {
        if (Input.GetKey(KeyCode.H))
        {
            cp.angularSpeed = 3;
        }
        else { cp.angularSpeed = 1.5f; }
    }
}
