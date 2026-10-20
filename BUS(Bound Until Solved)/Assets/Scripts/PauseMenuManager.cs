using System.Net.NetworkInformation;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseScreenManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public Button resumeGameButton;
    public Button noButton;
    private bool paused;
    private bool otherMenu;

    void Start()
    {
        optionsScreen.SetActive(false);
        pauseScreen.SetActive(false);
       
    }

    void Update()
    {
        Paused();
    }
    public void Paused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused == true)
        {

            if (otherMenu == false)
            {
                pauseScreen.SetActive(true);
            }
            else
            {
                pauseScreen.SetActive(false);
            }
            Time.timeScale = 0;
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                resumeGameButton.Select();
            }

        }
        else
        {
            pauseScreen.SetActive(false);
            optionsScreen.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            Time.timeScale = 1;
        }
    }

    public void Options()
    {
        otherMenu = true;
        optionsScreen.SetActive(true);
    }

    public void Back()
    {
        otherMenu = false;
        optionsScreen.SetActive(false);
        pauseScreen.SetActive(true);
        resumeGameButton.Select();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        if(Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;    
        }
#endif
        else
        {
            Application.Quit();
        }
    }

   public void UnPause()
    {
        paused = false;
    }

  
}