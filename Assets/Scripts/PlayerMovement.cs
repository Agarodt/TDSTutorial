using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField]
    float speed = 6;
    public bool walk;
    PlayerHP HP;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HP = GetComponent<PlayerHP>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!HP.dead)
        {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        if (moveX != 0 || moveY != 0)
        {
            walk = true;
        }
         if (moveX == 0 && moveY == 0)
        {
            walk = false;
        }
        }
        if(HP.dead)
        {
            rb.velocity = new Vector2(0, 0);
        }

        anim.SetBool("walkAnim", walk);
    }
}
