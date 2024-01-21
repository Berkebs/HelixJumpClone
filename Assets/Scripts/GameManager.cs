using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlaceManager placeManager;
    [SerializeField] private GameObject Cylinder;

    [SerializeField] private int baseCreatePlaceAmount;

    [SerializeField]
    private CompletedPlaceTrigger completedPlacePrefab;

    private float finishPoint;

    private void Awake()
    {
        EventManager.OnLevelPaused?.Invoke();
        PrepareScene();
    }

    void PrepareScene()
    {
        int placeAmount = baseCreatePlaceAmount + LevelManager.Instance.GetLevel();

        float cylinderScale = placeManager.GetVerticalDistance() * (placeAmount + 1);
        Cylinder.transform.localScale = new Vector3(1, cylinderScale, 1);
        Cylinder.transform.position = new Vector3(0, (-cylinderScale / 2) + 1, 0);

        placeManager.CreatePlace(placeAmount);

        completedPlacePrefab = Instantiate(completedPlacePrefab);
        completedPlacePrefab.transform.position = new Vector3(0, -placeManager.GetVerticalDistance() * (placeAmount + 1), 0);
        finishPoint = completedPlacePrefab.transform.position.y + completedPlacePrefab.transform.localScale.y;

    }

    public float GetFinishPoint() { return finishPoint; }

}
