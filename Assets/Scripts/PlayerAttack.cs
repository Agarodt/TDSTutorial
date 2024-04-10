using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject CurrentWeapon;
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    Transform FirePoint;
    [SerializeField]
    float throwSpeed = 200;
    [SerializeField]
    float bulletForce = 30;
    [SerializeField]
    GameObject NoWeaponPlayer;

    void Start()
    {
       FirePoint = transform.GetChild(0).transform; 
      
    }

    
    void Update()
    {
       
        if (Input.GetMouseButtonDown(1))
        {
        GameObject weapon = Instantiate(CurrentWeapon,FirePoint.position,FirePoint.rotation);
        weapon.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * throwSpeed, ForceMode2D.Impulse);
        Instantiate(NoWeaponPlayer,transform.position,transform.rotation);
        Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(Bullet,FirePoint.position,FirePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * bulletForce, ForceMode2D.Impulse);
        }
     
    }
}

