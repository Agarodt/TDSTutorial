using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public int type;
    public int id;
    [SerializeField]
    bool inZone;
    
    void Start()
    {
        id = Random.Range(0,10000);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inZone = true;
            WeaponManagement.instance.type = type;
            WeaponManagement.instance.id = id;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inZone = false;
        }
    }

    void Update()
    {
        if(inZone && WeaponManagement.instance.id == id && Input.GetMouseButtonDown(1))
        {
            WeaponManagement.instance.TakeWeapon();
            Destroy(gameObject);
        }
    }
}
