using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject placePartPrefab;
    [SerializeField]
    private PlaceController placePrefab;
        

    [SerializeField] private int verticalDistance;
    [SerializeField] private GameObject Cylinder;

    public void CreatePlace(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            PlaceController place = Instantiate(placePrefab);
            place.transform.position = new Vector3(0, verticalDistance * -i, 0);
            int nonActiveRandom = Random.Range(3, 7);
            int failedPlaceRandom = Random.Range(1, 3);

            place.PrepareSimple(nonActiveRandom,failedPlaceRandom);

            place.transform.parent = Cylinder.transform;
        }
    }

    

    public int GetVerticalDistance() { return verticalDistance; }

}
