using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
static public class UnityExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="x"></param>
    static public void SetLocalX(this Transform tr, float x)
    {
        Vector3 pos = tr.localPosition;
        pos.x = x;
        tr.localPosition = pos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="y"></param>
    static public void SetLocalY(this Transform tr, float y)
    {
        Vector3 pos = tr.localPosition;
        pos.y = y;
        tr.localPosition = pos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="z"></param>
    static public void SetLocalZ(this Transform tr, float z)
    {
        Vector3 pos = tr.localPosition;
        pos.z = z;
        tr.localPosition = pos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="x"></param>
    static public void SetX(this Transform tr, float x)
    {
        Vector3 pos = tr.position;
        pos.x = x;
        tr.position = pos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="y"></param>
    static public void SetY(this Transform tr, float y)
    {
        Vector3 pos = tr.position;
        pos.y = y;
        tr.position = pos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="z"></param>
    static public void SetZ(this Transform tr, float z)
    {
        Vector3 pos = tr.position;
        pos.z = z;
        tr.position = pos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="x"></param>
    static public void SetScaleX(this Transform tr, float x)
    {
        Vector3 scale = tr.localScale;
        scale.x = x;
        tr.localScale = scale;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="y"></param>
    static public void SetScaleY(this Transform tr, float y)
    {
        Vector3 scale = tr.localScale;
        scale.y = y;
        tr.localScale = scale;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="z"></param>
    static public void SetScaleZ(this Transform tr, float z)
    {
        Vector3 scale = tr.localScale;
        scale.z = z;
        tr.localScale = scale;
    }

    /// <summary>
    /// 2D对象跟随3D对象（仅限UGUI）
    /// </summary>
    /// <param name="mainCamera">3D世界主相机</param>
    /// <param name="ui">2D对象</param>
    /// <param name="target">3D对象</param>
    /// <param name="deltaVec">偏移量</param>
    static public void UiFollowTransform(this Camera mainCamera, RectTransform ui, Transform target, Vector3 deltaVec)
    {
        if (ui == null || target == null) return;
        ui.position = mainCamera.WorldToScreenPoint(target.position) + deltaVec;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="seconds"></param>
    /// <param name="method"></param>
    static public void StartCoroutine(this MonoBehaviour mono, float seconds, Action method)
    {
        if (method != null)
        {
            mono.StartCoroutine(DelayCall(seconds, method));
        }
    }

    static private IEnumerator DelayCall(float seconds, Action method)
    {
        yield return new WaitForSeconds(seconds);
        method();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    static public GameObject instantiate(this MonoBehaviour mono, GameObject target,Transform parent)
    {
        GameObject go = UnityEngine.Object.Instantiate(target) as GameObject;
        if (parent != null)
            go.transform.parent = parent;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.transform.localEulerAngles = Vector3.zero;
        return go;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="thePoint"></param>
    /// <param name="polygon"></param>
    /// <returns></returns>
    static public bool IsPointInPolygon(this Vector2 thePoint, Vector2[] polygon)
    {
        polygon = polygon.OrderBy(p => p.x).ToArray();
        float minX = polygon[0].x;
        float maxX = polygon[polygon.Length - 1].x;
        polygon = polygon.OrderBy(p => p.y).ToArray();
        float minY = polygon[0].y;
        float maxY = polygon[polygon.Length - 1].y;

        if (thePoint.x < minX || thePoint.x > maxX || thePoint.y < minY || thePoint.y > maxY)
            return false;
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="x"></param>
    static public void SetX(this Vector3 vec, float x)
    {
        vec.x = x;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="y"></param>
    static public void SetY(this Vector3 vec, float y)
    {
        vec.y = y;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="z"></param>
    static public void SetZ(this Vector3 vec, float z)
    {
        vec.z = z;
    }

    /// <summary>
    /// 清空并删除Object
    /// </summary>
    /// <param name="list"></param>
    static public void ClearAllObject(this List<GameObject> list)
    {
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                UnityEngine.Object.Destroy(list[i]);
            }
            list.Clear();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    static public GameObject ToGameObject(this UnityEngine.Object obj)
    {
        
        return (obj as GameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    static public T instantiate<T>(this UnityEngine.Object obj,UnityEngine.Object target) where T : Component
    {
        return ((UnityEngine.Object.Instantiate(target) as GameObject).GetComponent(typeof(T)) as T);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    static public List<string> RemoveNullOrEmpty(this List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (string.IsNullOrEmpty(list[i]))
            {
                list.RemoveAt(i);
            }
        }
        return list;
    }

    /// <summary>
    /// 获取子对象集合
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    static public List<Transform> GetChilds(this Transform transform)
    {
        if (transform == null)
        {
            throw new NullReferenceException("传入的Transform为空！！！");
        }

        int childCount = transform.childCount;

        if (childCount == 0)
            throw new NullReferenceException("该Transform没有子对象！！！");

        var trans = new List<Transform>();
        for (int i = 0; i < childCount; i++)
        {
            trans.Add(transform.GetChild(i));
        }

        return trans;
    }
}

