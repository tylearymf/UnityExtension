using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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
    static public void InvokeDelegate(this MonoBehaviour mono,float seconds,Action method)
    {
        if(method != null)
        {
            mono.StartCoroutine(DelayCall(seconds, method));
        }
    }

    static private IEnumerator DelayCall(float seconds,Action method)
    {
        yield return new WaitForSeconds(seconds);
        method();
    }
}

