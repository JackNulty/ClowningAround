using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Crumble : MonoBehaviour
{
    public float fallSpeed = 0.1f;

    public static bool canFall = false;

    private void Update()
    {
        if (canFall)
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {

        yield return new WaitForSeconds(3f);

        Vector3 startPosition = transform.position;

        float bottomY = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

        while (transform.position.y > bottomY)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = new Vector3(startPosition.x, bottomY, startPosition.z);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Balloon")
        {
            canFall = false;
        }
        else
        {
            canFall = true;
        }
    }
}
