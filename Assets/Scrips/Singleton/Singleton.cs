using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindOrCreateInstance();
            }
            return _instance;
        }
    }

    private static T FindOrCreateInstance()
    {
        var instance = GameObject.FindObjectOfType<T>();
        
        if (instance != null)
        {
            return instance;
        }

        var name = typeof (T).Name + "Singleton";
        var containerGameObject = new GameObject(name);

        var singletonComponent = containerGameObject.AddComponent<T>();

        return singletonComponent;
    }
}
