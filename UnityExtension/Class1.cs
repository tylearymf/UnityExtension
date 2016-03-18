using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

static public class UnityExtension
{
    static public void SetLocalX(this Transform tr,float x)
    {
        Vector3 pos = tr.localPosition;
        pos.x = x;
        tr.localPosition = pos;
    }

}

