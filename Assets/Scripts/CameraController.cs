using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CanvasManager canvasManager;

    private Vector3 offset;

    private float startVertical;

    [SerializeField] private GameManager gameManager;


    private void Start()
    {
        offset = transform.position - target.position;

        startVertical = transform.position.y;
    }

    private void LateUpdate()
    {
        var current = offset + target.position;

        if (current.y > transform.position.y)
            return;

        transform.position = current;

        var progress = Mathf.InverseLerp(startVertical, gameManager.GetFinishPoint(), transform.position.y);
        canvasManager.LevelProgressDisplay.Progress = progress;
        //Debug.Log(progress);

    }

}
