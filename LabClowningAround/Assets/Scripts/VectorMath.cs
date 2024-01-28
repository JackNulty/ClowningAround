using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static class VectorMath
{
    public static float ToAngle(this Vector3 current)
    {
        current.Normalize();

        float angleRad = Mathf.Atan2(current.y, current.x);
        return angleRad * (180 / Mathf.PI);
    }
}
