using System.Collections;
using System.Collections.Generic;
using LastHand;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private CanvasGroup menuPanel;
    [SerializeField] private CanvasGroup mainPanel;
    [SerializeField] private CanvasGroup minimapPanel;
    [SerializeField] private CanvasGroup puzzlePanel;
    [SerializeField] private CanvasGroup cranePanel;
    [SerializeField] public CanvasGroup gameOverPanel;

    public Text alertText;
    
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;

    [SerializeField] private Button puzzleBackButton;
    [SerializeField] private Button craneBackButton;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        Events.GamePlay.OnPuzzleWin += OnPuzzleWin;
        Events.GamePlay.OnMinimapCollider += OnMinimapCollider;
        Events.GamePlay.OnCraneCollider += OnCraneCollider;
        Events.GamePlay.OnDrawerTrigger += OnDrawerTrigger;
        Events.GamePlay.OnDrawerExit += OnDrawerExit;

        startGameButton.onClick.AddListener(() =>
        {
            Events.Menu.StartGameButton.Call();
            DeActivatePanel(menuPanel);
            ActivatePanel(mainPanel);
        });
        
        exitGameButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        
        puzzleBackButton.onClick.AddListener(() =>
        {
            Events.UIGamePlay.OnPuzzleClose.Call();
            DeActivatePanel(puzzlePanel);
            
            LevelStateManager.Instance.isMinimapPuzzleActive = false;
        });
        
        craneBackButton.onClick.AddListener(() =>
        {
            Events.UIGamePlay.OnCraneClose.Call();

            DeActivatePanel(cranePanel);
            ActivatePanel(mainPanel);

            LevelStateManager.Instance.isCraneActive = false;
        });
    }
    
    private void OnDisable()
    {
        Events.GamePlay.OnPuzzleWin -= OnPuzzleWin;
        Events.GamePlay.OnMinimapCollider -= OnMinimapCollider;
        Events.GamePlay.OnCraneCollider -= OnCraneCollider;
        Events.GamePlay.OnDrawerTrigger -= OnDrawerTrigger;
        Events.GamePlay.OnDrawerExit -= OnDrawerExit;
        
        startGameButton.onClick.RemoveAllListeners();
        exitGameButton.onClick.RemoveAllListeners();
        puzzleBackButton.onClick.RemoveAllListeners();
        craneBackButton.onClick.RemoveAllListeners();
    }
    
    private void OnPuzzleWin()
    {
        DeActivatePanel(puzzlePanel);
        ActivatePanel(mainPanel);
        ActivatePanel(minimapPanel);
        alertText.text = AlertUITexts.HIDE_AGENTS;
    }
    
    private void OnMinimapCollider()
    {
        alertText.text = AlertUITexts.GET_MINIMAP;

        ActivatePanel(puzzlePanel);
        DeActivatePanel(mainPanel);
    }

    private void OnCraneCollider()
    {
        ActivatePanel(cranePanel);
        DeActivatePanel(mainPanel);
    }
    
    private void OnDrawerTrigger()
    {
        alertText.text = AlertUITexts.USE_DRAWER;
    }
    
    private void OnDrawerExit()
    {
        alertText.text = AlertUITexts.CLOSE_DRAWER;
    }
    
    private void ActivatePanel(CanvasGroup panel)
    {
        panel.alpha = 1;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }
    
    private void DeActivatePanel(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.interactable = false;
        panel.blocksRaycasts = false;
    }
}