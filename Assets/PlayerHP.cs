using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHP : MonoBehaviour
{
    public bool dead;
    Animator anim;
    SpriteRenderer Rend;
    void Start()
    {
        anim = GetComponent<Animator>();
        Rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isDead", dead);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyBullet")
        {
            if (!dead)
            {
            dead = true;
            Rend.sortingOrder = -1;
            StartCoroutine(RestartGame());

            }
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
