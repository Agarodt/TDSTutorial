using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        transform.position = new Vector3(target.position.x, target.position.y, -1);
    }
}
