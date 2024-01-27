
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HahaMover : MonoBehaviour
{
    public static List<HahaMover> all = new List<HahaMover>();

    public void TriggerSpawn()
    {
        Debug.Log("Hit " + gameObject.name);
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
