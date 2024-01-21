using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public LevelProgressDisplay LevelProgressDisplay => levelProgressDisplay;
    [SerializeField] private LevelProgressDisplay levelProgressDisplay;
    [SerializeField] private List<UIPanels> Panels;
    [SerializeField] private TextMeshProUGUI LevelText;



    private void OnEnable()
    {
        EventManager.OnLevelCompleted += OnLevelCompleted;
        EventManager.OnLevelFailed+= OnLevelFailed;
    }
    private void OnDisable()
    {
        EventManager.OnLevelCompleted -= OnLevelCompleted;
        EventManager.OnLevelFailed -= OnLevelFailed;
    }
    

    private void Start()
    {
        SetPanel(PanelTypes.Menu); 
        LevelText.text = "Level " + LevelManager.Instance.GetLevel().ToString(); 
    }
    public void PlayGameButton()  { 
        SetPanel(PanelTypes.Game);
        EventManager.OnLevelStarted?.Invoke();
    }
    public void MainMenuButton() { SceneManager.LoadScene(0); }
    private void OnLevelFailed() { SetPanel(PanelTypes.Failed); }
    private void OnLevelCompleted() { SetPanel(PanelTypes.Completed); }


    public void SetPanel(PanelTypes type) 
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            if (type != Panels[i].PanelType)
                Panels[i].PanelTransform.SetActive(false);
           else if (type == Panels[i].PanelType)
                Panels[i].PanelTransform.SetActive(true);

        }
    }
}
[System.Serializable]
public class UIPanels
{
    public PanelTypes PanelType;
    public GameObject PanelTransform;
}


public enum PanelTypes
{
     Menu,
     Game,
     Failed,
     Completed
}