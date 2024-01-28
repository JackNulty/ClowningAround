
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HahaSpawner : MonoBehaviour
{
    public Animator laughTrigger;
    public static List<HahaSpawner> all = new List<HahaSpawner>();
    public float upwardForce = 5f;

    public void TriggerSpawn(Vector2 initialVelocity)
    {
        GameObject haha = GameManager.instance.resources.GetPrefab("hahatest");
        GameObject instance = Instantiate(haha, transform.position, Quaternion.identity);

        initialVelocity.y += upwardForce;

        instance.GetComponent<Rigidbody2D>().AddForce(initialVelocity, ForceMode2D.Impulse);

        if (laughTrigger == null)
            return;

        laughTrigger.SetTrigger("Laugh");
    }

    private void Awake()
    {
        all.Add(this);
    }

    private void OnDestroy()
    {
        all.Remove(this);
    }
}
