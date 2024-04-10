using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    BoxCollider2D col;
    public bool attack;
    EnemyAnimation AnimScript;
    EnemyHP HP;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
        AnimScript = GetComponentInParent<EnemyAnimation>();
        HP = GetComponentInParent<EnemyHP>();
    }

    
    void Update()
    {
        
    }

    public void MelleeAttack()
    {
      if (!HP.dead)
      {
      if(!attack)
      {
        attack = true;
        StartCoroutine(AttackTimer());
      }
      }
      return;
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1f);
        col.enabled = true;
        AnimScript.attackAnim = true;
        StartCoroutine(FinishAttack());

    }
    IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(0.1f);
        col.enabled = false;
        AnimScript.attackAnim = false;
        attack = false;
        

    }
}
