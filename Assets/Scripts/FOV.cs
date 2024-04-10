using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    [SerializeField]
    float radius;
    [SerializeField]
    LayerMask targetLayer;
    [SerializeField]
    LayerMask wallsLayer;
    Collider2D[] targetCol;
    [SerializeField]
    Transform targetTransform;
    Vector2 targetDir;
    float targetDistance;
    [SerializeField]
    float viewAngle = 45;
    [SerializeField]
    float chasingTime = 5f;
    [SerializeField]
    bool visible;
    public bool chase;



    void Update()
    {
        FoV();

        if(visible && !chase)
        {
            chase = true;
            StartCoroutine(Chasing());
        }
    }

    void OnDrawGizmos()
    {
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, radius);

        Vector2 DegToRad(float deg, float euler)
        {
            deg += euler;

            return new Vector2(Mathf.Sin(deg * Mathf.Deg2Rad),Mathf.Cos(deg * Mathf.Deg2Rad));
        }

        Vector3 posAngle = DegToRad(viewAngle, -transform.eulerAngles.z);
        Vector3 negAngle = DegToRad(-viewAngle, -transform.eulerAngles.z);

        Gizmos.DrawLine(transform.position, transform.position + posAngle * radius);
        Gizmos.DrawLine(transform.position, transform.position + negAngle * radius);
    }

    void FoV()
    {
        targetCol = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        if(targetCol.Length > 0)
        {
            targetTransform = targetCol[0].transform;
            targetDir = (targetTransform.position - transform.position).normalized;
            targetDistance = Vector2.Distance(transform.position, targetTransform.position);
            if(Vector2.Angle(transform.up, targetDir) < viewAngle)
            {
              if (!Physics2D.Raycast(transform.position, targetDir, targetDistance, wallsLayer))
              {
                visible = true;
              }
              else
              {
                visible = false;
              }
            }
             else
              {
                visible = false;
              }
        }
         else
              {
                visible = false;
              }
    }

    IEnumerator Chasing()
    {
        yield return new WaitForSeconds(chasingTime);
        if(!visible)
        {
            chase = false;
        }
        else
        {
            StartCoroutine(Chasing());
        }
    }
}
