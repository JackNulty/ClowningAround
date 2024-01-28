using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ResourceManager resources;

    private void Awake()
    {
        instance ??= this;
    }


}
