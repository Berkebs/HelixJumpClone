using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressDisplay : MonoBehaviour
{ 

    [SerializeField] private RectTransform imageBackground;
    [SerializeField] private Image imageDisplay;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;

    float progressPoint;

    public float Progress
    {
        get => _progress;
        set
        {   
            _progress = value;
            imageDisplay.rectTransform.sizeDelta = new Vector2(imageBackground.sizeDelta.x * _progress, imageDisplay.rectTransform.sizeDelta.y);
        }
    }

    private float _progress;

    private void Start()
    {
        int level  = LevelManager.Instance.GetLevel();

        currentLevelText.text = level.ToString();
        nextLevelText.text = (level+1).ToString();

    }





}
