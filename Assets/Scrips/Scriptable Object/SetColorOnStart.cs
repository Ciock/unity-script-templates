using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorOnStart : MonoBehaviour
{
    [SerializeField] ObjectColor objectColor;

    void Start()
    {
        if(objectColor != null){
            GetComponent<Renderer>().material.color = objectColor.color;
        }
    }

}
