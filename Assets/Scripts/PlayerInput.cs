using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] CircularPlatform cp;
    [SerializeField] SpriteRenderer shieldSprite;

    private void Start()
    {
        shieldSprite = cp.GetComponent<SpriteRenderer>();
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
            shieldSprite.color = Color.yellow;
            
        }
        else 
        { 
            cp.angularSpeed = 1.5f; 
            shieldSprite.color = Color.white;
        }
    }
}
