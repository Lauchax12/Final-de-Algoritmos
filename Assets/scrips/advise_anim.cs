using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advise_anim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetBool("attack", true);
    }

    public void NoAttack()
    {
        anim.SetBool("attack", false);
    }
}
