using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    public static WeaponManagement instance;
    public int type;
    public int id;

    [SerializeField]
    GameObject BatonPlayer;
    [SerializeField]
    GameObject PistolPlayer;

    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void TakeWeapon()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        switch(type)
        {
            case 1:
            Instantiate(BatonPlayer,Player.transform.position,Player.transform.rotation);
            Destroy(Player);
            break;
            case 2:
            Instantiate(PistolPlayer,Player.transform.position,Player.transform.rotation);
            Destroy(Player);
            break;

        }
    }

    void Update()
    {
        
    }
}
