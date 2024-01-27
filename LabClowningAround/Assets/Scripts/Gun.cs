using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float range = 5f;
    public float angle = 10f;

    private ParticleSystem vfx;

    private void Awake()
    {
        vfx = GetComponentInChildren<ParticleSystem>();
        if (vfx == null)
        {
            Debug.LogError("[Gun] No particle system found in children");
        }
    }

    public void OnFire()
    {
        /*
         * Cast cone in direction of player mouse
         */
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float pointedAngle = (mousePos - transform.position).ToAngle();
        vfx.transform.rotation = Quaternion.Euler(0, 0, pointedAngle);
        vfx.Play();

        foreach (HahaMover instance in HahaMover.all)
        {
            Vector3 heading = (instance.transform.position - transform.position);
            if (heading.sqrMagnitude < range * range && Mathf.Abs(pointedAngle - heading.ToAngle()) < angle)
            {
                instance.TriggerSpawn();
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red * new Color(1,1,1,0.1f);
        Gizmos.DrawWireSphere(transform.position, range);



        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }
}