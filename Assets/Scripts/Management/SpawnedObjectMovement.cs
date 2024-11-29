using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpawnedObjectMovement : MonoBehaviour
{

    SpriteRenderer sprite;


    private void Start()
    {
      StartCoroutine(DestroySelf());
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 targetPos = FindFirstObjectByType<DeadPosition>().transform.position;

        float currentY = this.transform.position.y;


        // freezes movement on Y
        Vector2 newPos =   Vector2.MoveTowards(this.transform.position, new Vector2(targetPos.x, currentY), 2 * Time.deltaTime);

       

        this.transform.position = newPos;

      
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(20);
        sprite.DOFade(0, 3);

        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
