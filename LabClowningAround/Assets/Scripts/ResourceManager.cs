using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Serializable]
    public class PrefabEntry
    {
        public string id;
        public GameObject prefab;
    }

    public List<PrefabEntry> prefabs;

    public GameObject GetPrefab(string id)
    {
        foreach (PrefabEntry entry in prefabs)
        {
            if (entry.id == id)
                return entry.prefab;
        }

        Debug.LogError("[Resources] No prefab with ID (" + id + ") found");
        return null;
    }

}
