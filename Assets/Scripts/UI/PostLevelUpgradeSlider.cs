using UnityEngine;
using UnityEngine.UIElements;

public class PostLevelUpgradeSlider : MonoBehaviour
{
    [SerializeField] Transform startingPosition, endPosition;

    [SerializeField] GameObject movingSlider;
    [SerializeField] float sliderMovingSpeed = 1;

    
    private void Start()
    {
        
    }
    private void Update()
    {
        MoveSlider();
    }
    void MoveSlider()
    {      
           Vector2 newPosition = Vector2.MoveTowards(movingSlider.transform.position, startingPosition.position, sliderMovingSpeed * Time.deltaTime);
            movingSlider.transform.position = newPosition;   

    }

}
