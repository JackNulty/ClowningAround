using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float range = 5f;
    public float angle = 10f;


    public void OnFire()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float pointedAngle = (mousePos - transform.position).ToAngle();

        foreach (HahaMover instance in HahaMover.all)
        {
            Vector3 heading = (instance.transform.position - transform.position);
            if (heading.sqrMagnitude < range * range && Mathf.Abs(pointedAngle - heading.ToAngle()) < angle)
            {
                instance.TriggerSpawn();
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);



        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }
}
