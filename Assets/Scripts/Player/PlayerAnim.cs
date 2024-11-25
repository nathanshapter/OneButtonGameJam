using System.Collections;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;

    CircuitPlatform circuitPlatform;

   [SerializeField] SpriteRenderer spriteRenderer;

  [SerializeField]  bool isSlider = false;
    private void Start()
    {
        circuitPlatform = GetComponentInParent<CircuitPlatform>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (!isSlider)
            return;

       if(circuitPlatform.CalculateWaypointTransformX() >= transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX=false;
        }
    }

    public IEnumerator AnimDamage()
    {
        anim.SetBool("tookDamage", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("tookDamage", false);
    }
   
}
