using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] CircularPlatform cp, cp2;
    [SerializeField] SpriteRenderer shieldSprite, shieldSprite2;

    public float angularSpeed = 1.5f;
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
            cp.angularSpeed = angularSpeed *2;
            shieldSprite.color = Color.yellow;

           

        }
        else 
        { 
            cp.angularSpeed = angularSpeed; 
            shieldSprite.color = Color.white;

            
        }
    }
}
