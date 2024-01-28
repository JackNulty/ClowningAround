using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Balloon : MonoBehaviour
{
    public UnityEvent onDestroy;
    public GameObject particles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Haha")) 
            return;

        Instantiate(particles, transform.position, Quaternion.identity);

        onDestroy.Invoke();
        gameObject.SetActive(false);
    }
}
