using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePassedTrigger : MonoBehaviour
{
    [SerializeField] PlaceController placeController;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            placeController.PassedPlace();
        }
    }
}
