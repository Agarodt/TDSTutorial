using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public bool dead;
    EnemyAnimation AnimScript;
    SpriteRenderer Rend;

    void Start()
    {
        AnimScript = GetComponent<EnemyAnimation>();
        Rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet")
        {
            dead = true;
            AnimScript.deadAnim = dead;
            
        }
    }
}
