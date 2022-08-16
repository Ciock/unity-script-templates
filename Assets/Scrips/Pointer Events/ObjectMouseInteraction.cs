using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class
ObjectMouseInteraction
:
MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerUpHandler,
IPointerDownHandler,
IPointerClickHandler
{
    Material material;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogFormat("{0} clicked", gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        material.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        material.color = Color.white;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        material.color = Color.yellow;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        material.color = Color.yellow;
    }

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
}
