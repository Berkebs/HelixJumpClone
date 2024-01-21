using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPlaceTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            EventManager.OnLevelFailed?.Invoke();
            EventManager.OnLevelPaused?.Invoke();
        }
    }

}
