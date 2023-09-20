using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject stagesUI;
    [SerializeField] private GameObject quitConfirmUI;

    [SerializeField] private string stage1Scene = "Stage1Scene";

    void Start()
    {
        mainMenuUI.SetActive(true);
        settingsUI.SetActive(false);
        stagesUI.SetActive(false);
        quitConfirmUI.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // settings functions

    public void onSettings()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(true);
        stagesUI.SetActive(false);

        Debug.Log("onSettings");
    }
    public void onSettingsBack()
    {
        mainMenuUI.SetActive(true);
        settingsUI.SetActive(false);
        stagesUI.SetActive(false);

        Debug.Log("onSettingsBack");
    }

    // stages functions

    public void onStages()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        stagesUI.SetActive(true);

        Debug.Log("onLevelType");
    }
    public void onStagesBack()
    {
        mainMenuUI.SetActive(true);
        settingsUI.SetActive(false);
        stagesUI.SetActive(false);

        Debug.Log("onLevelTypeBack");
    }

    // stage start functions

    public void onStage1Start()
    {
        Debug.Log("onStage1Start");

        SceneManager.LoadScene(stage1Scene);
    }

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

}
