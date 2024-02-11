using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IDragHandler
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cylinder;

    private void OnEnable()
    {
        EventManager.OnLevelFailed += LevelFinished;
        EventManager.OnLevelCompleted += LevelFinished;
    }
    private void OnDisable()
    {
        EventManager.OnLevelFailed -= LevelFinished;
        EventManager.OnLevelCompleted -= LevelFinished;
    }

    void LevelFinished()
    {
        this.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        var rotation = cylinder.rotation;
        var current = rotation.eulerAngles.y;
        current += -eventData.delta.x * speed;
        rotation.eulerAngles = new Vector3(0, current, 0);

        cylinder.rotation = rotation;
    }
}
