using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector2 velocityLimitMinMax;


    private void FixedUpdate()
    {
        var vertical = myRigidbody.velocity;
        vertical.y = Math.Clamp(vertical.y, velocityLimitMinMax.x, velocityLimitMinMax.y);
        myRigidbody.velocity = vertical;
    }

    private void OnEnable()
    {
        EventManager.OnLevelStarted += BallStateActive;
        EventManager.OnLevelPaused += BallStateDeactive;
    }
    private void OnDisable()
    {
        EventManager.OnLevelStarted -= BallStateActive;
        EventManager.OnLevelPaused -= BallStateDeactive;


    }


    private void BallStateActive() {  myRigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; }
    private void BallStateDeactive() {myRigidbody.constraints = RigidbodyConstraints.FreezeAll; }

}
