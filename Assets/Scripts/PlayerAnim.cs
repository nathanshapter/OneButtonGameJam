using System.Collections;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public IEnumerator AnimDamage()
    {
        anim.SetBool("tookDamage", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("tookDamage", false);
    }
   
}
