using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 5f;
    public float angle = 10f;


    public void OnFire()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 1; i <= 10; i++)
        {
            float step = i / 10.0f;
            Gizmos.color = Gizmos.color.WithAlpha(step);
            Vector3 stepOffset = range * step * Vector3.right;
            Gizmos.DrawWireSphere(transform.position + stepOffset, angle * step * 0.5f);
        }
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
