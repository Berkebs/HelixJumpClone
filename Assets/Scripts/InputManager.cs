using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour,IDragHandler, IBeginDragHandler
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cylinder;


    public void OnDrag(PointerEventData eventData)
    {

        var rotation = cylinder.rotation;
        var current = rotation.eulerAngles.y;
        current += -eventData.delta.x * speed;
        rotation.eulerAngles = new Vector3(0, current, 0);

        cylinder.rotation = rotation;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //GameStart
    }
}
