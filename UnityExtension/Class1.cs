using System;
using System.Collections;
using UnityEngine;


static public class UnityExtension
{
    static public void ResetTransformation(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = new Vector3(1, 1, 1);
    }

    static public void ChangeGameObjectName(this GameObject go,string name)
    {
        go.name = name;
    }
}

