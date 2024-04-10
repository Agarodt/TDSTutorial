using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;
    bool walk;
    Vector3 pos;
    public bool deadAnim;
    public bool attackAnim;

   
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(pos != transform.position)
        {
            walk = true;
            pos = transform.position;
        }
        else
        {
            walk = false;
        }

        Animate();
    }

    void Animate()
    {
        anim.SetBool("isWalking", walk);
        anim.SetBool("isDead", deadAnim);
        anim.SetBool("isAttacking", attackAnim);
    }


}
