﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class _MonoBehaviour : MonoBehaviour
{

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected string GetMethodName()
    {
        MethodBase method = (new StackTrace()).GetFrame(1).GetMethod();
        string name = this.GetType().Name + "::" + (new StackTrace()).GetFrame(1).GetMethod().Name;
        //name = MethodBase.GetCurrentMethod().Name;
        ParameterInfo[] _params = GetMethodParams(method);
        if (_params != null && _params.Length > 0)
        {
            name += "(...)";
            foreach (var param in _params)
            {
                name += param/* + "=" + param.value(?)*/;
            }
        }
        else
        {
            name += "()";
        }
        return DateTime.Now.ToString(/*"yyyy/MM/dd" + "-" + */"HH:mm:ss.fff") + "-" + Time.deltaTime + ":" + name;
    }

    private ParameterInfo[] GetMethodParams(MethodBase method)
    {
        ParameterInfo[] pars = method.GetParameters();
        //foreach (ParameterInfo p in pars)
        //{
        //    Console.WriteLine(p.ParameterType);
        //}
        return pars;
    }

    protected Bounds GetTotalBoundsAll(Transform objectTransform)
    {
        var meshFilter = objectTransform.GetComponent<MeshFilter>();
        var result = meshFilter != null ? meshFilter.mesh.bounds : new Bounds();
        //UnityEngine.Debug.LogWarning(this.GetMethodName() + ":" + objectTransform + ":" + result);
        Vector3 min = Vector3.zero;
        Vector3 max = Vector3.zero;
        foreach (Transform transform in objectTransform)
        {
            var bounds = GetTotalBoundsAll(transform);
            min += bounds.min;
            max += bounds.max;
            //UnityEngine.Debug.Log(this.GetMethodName() + ":" + transform + ":" + bounds + ":" + min + ":" + max);
        }
        result.Encapsulate(min);
        result.Encapsulate(max);
        var scaledMin = result.min;
        scaledMin.Scale(objectTransform.localScale);
        result.min = scaledMin;
        var scaledMax = result.max;
        scaledMax.Scale(objectTransform.localScale);
        result.max = scaledMax;
        //UnityEngine.Debug.LogWarning(this.GetMethodName() + ":" + objectTransform + ":" + result);
        return result;
    }

    protected Bounds GetTotalBounds(Transform objectTransform)
    {
        var meshFilter = objectTransform.GetComponent<MeshFilter>();
        var result = meshFilter != null ? meshFilter.mesh.bounds : new Bounds();
        foreach (Transform transform in objectTransform)
        {
            var bounds = GetTotalBounds(transform);
            result.Encapsulate(bounds.min);
            result.Encapsulate(bounds.max);
        }
        var scaledMin = result.min;
        scaledMin.Scale(objectTransform.localScale);
        result.min = scaledMin;
        var scaledMax = result.max;
        scaledMax.Scale(objectTransform.localScale);
        result.max = scaledMax;
        return result;
    }

    protected GameObject GetChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    protected GameObject[] GetChildsGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        List<GameObject> ret = new List<GameObject>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) ret.Add(t.gameObject);
        return ret.ToArray();
    }

    //// Use this for initialization
    //protected virtual void Awake()
    //{
    //}

    //// Use this for initialization
    //protected virtual void Start()
    //{
    //}

    //// Update is called once per frame
    //protected virtual void Update()
    //{
    //}

    //protected virtual void OnCollisionEnter(Collision collision)
    //{
    //}
}
