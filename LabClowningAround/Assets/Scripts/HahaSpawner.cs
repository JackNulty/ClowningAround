
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HahaSpawner : MonoBehaviour
{
    public static List<HahaSpawner> all = new List<HahaSpawner>();

    public void TriggerSpawn(Vector2 initialVelocity)
    {
        GameObject haha = GameManager.instance.resources.GetPrefab("hahatest");
        GameObject instance = Instantiate(haha, transform.position, Quaternion.identity);

        instance.GetComponent<Rigidbody2D>().AddForce(initialVelocity, ForceMode2D.Impulse);
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
