using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MAIN_MENU,
    LEVEL_IN_PROGRESS,
    LEVEL_PAUSED,
    LEVEL_EVALUATION
};

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject quitConfirmUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject levelTypeUI;
    [SerializeField] private GameObject levelSelectUI;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject exitConfirmUI; // exit level from pause?
    [SerializeField] private GameObject evaluationUI;

    private PlayerController playerController;
    private bool levelInProgress;

    // better way of instantiating once?
    private bool mainMenuBool;
    private bool levelPausedBool;
    private bool levelEvaluationBool; // finish bool?

    void Start()
    {
        mainMenuUI.SetActive(false);
        quitConfirmUI.SetActive(false);
        settingsUI.SetActive(false);
        levelTypeUI.SetActive(false);
        levelSelectUI.SetActive(false);
        HUD.SetActive(false);
        pausedUI.SetActive(false);
        exitConfirmUI.SetActive(false);
        evaluationUI.SetActive(false);

        mainMenuBool = true;
        gameState = GameState.MAIN_MENU;

        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.MAIN_MENU:

                if (mainMenuBool == true)
                {
                    playerController.Disable();

                    mainMenuUI.SetActive(true);
                    settingsUI.SetActive(false);
                    HUD.SetActive(false);
                    pausedUI.SetActive(false);
                    evaluationUI.SetActive(false);
                    Time.timeScale = 0;

                    mainMenuBool = false;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }

                break;

            case GameState.LEVEL_IN_PROGRESS:

                if (levelInProgress)
                {
                    playerController.Enable();
                    Time.timeScale = 1;

                    levelInProgress = false;

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }

                if (Input.GetKey(KeyCode.Escape) == true) // press esc to pause? button instead
                {

                    gameState = GameState.LEVEL_PAUSED;
                    levelPausedBool = true;

                }

                break;

            case GameState.LEVEL_PAUSED:

                if (levelPausedBool == true)
                {
                    playerController.Disable();

                    HUD.SetActive(false);
                    mainMenuUI.SetActive(false);
                    pausedUI.SetActive(true);
                    evaluationUI.SetActive(false);
                    Time.timeScale = 0;

                    levelPausedBool = false;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }

                break;

            case GameState.LEVEL_EVALUATION:

                if (levelEvaluationBool == true) //disables player movement, activates finish ui and deactivates all other
                {
                    playerController.Disable();
                    
                    HUD.SetActive(false);
                    pausedUI.SetActive(false);
                    evaluationUI.SetActive(true);

                    levelEvaluationBool = false;
                }

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                break;

            default:
                break;
        }
    }

    //----- MAIN MENU FUNCTIONS -----//

    // quit functions

    public void onQuit()
    {
        quitConfirmUI.SetActive(true);
    }
    public void onQuitYes()
    {
        Application.Quit();
        Debug.Log("Error: There was a problem with executing Application.Quit()");
    }
    public void onQuitNo()
    {
        quitConfirmUI.SetActive(false);
    }

    // settings functions

    public void onSettings()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(true);

        Debug.Log("onSettings");
    }
    public void onSettingsBack()
    {
        mainMenuBool = true;
        mainMenuUI.SetActive(true);
        settingsUI.SetActive(false);

        Debug.Log("onSettingsBack");
    }

    // start function

    public void onLevelStart()
    {
        levelInProgress = true;
        levelSelectUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1;
        gameState = GameState.LEVEL_IN_PROGRESS;

        Debug.Log("onLevelStart");
    }

    //----- LEVEL FUNCTIONS -----//

    // level type function

    public void onLevelType()
    {
        mainMenuUI.SetActive(false);
        levelTypeUI.SetActive(true);

        Debug.Log("onLevelType");
    }
    public void onLevelTypeBack()
    {
        mainMenuBool = true;
        mainMenuUI.SetActive(true);
        levelTypeUI.SetActive(false);

        Debug.Log("onLevelTypeBack");
    }

    // level select function

    public void onLevelSelect()
    {
        levelTypeUI.SetActive(false);
        levelSelectUI.SetActive(true);

        Debug.Log("onLevelSelect");
    }
    public void onLevelSelectBack()
    {
        levelTypeUI.SetActive(true);
        levelSelectUI.SetActive(false);

        Debug.Log("onLevelSelectBack");
    }

    //----- PAUSED FUNCTIONS -----//

    public void onResume()
    {
        levelInProgress = true;
        HUD.SetActive(true);
        pausedUI.SetActive(false);
        Time.timeScale = 1;
        gameState = GameState.LEVEL_IN_PROGRESS;

        Debug.Log("onResume");
    }

    public void onMainMenu()
    {
        mainMenuBool = true;
        gameState = GameState.MAIN_MENU;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("onMainMenu");
    }

}
