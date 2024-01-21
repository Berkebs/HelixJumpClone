using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedPlaceTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            EventManager.OnLevelCompleted?.Invoke();
            EventManager.OnLevelPaused?.Invoke();

        }
    }

}
