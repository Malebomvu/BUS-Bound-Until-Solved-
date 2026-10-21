using System.Runtime.CompilerServices;
using UnityEngine;

public class HudPause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    private bool isPaused;

    private void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = true;
        }

    }

    public void PauseGame()
    {
        if (pauseMenu == null) return;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenu == null) return;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }

    public void OpenOptions()
    {
        Debug.Log("Options menu opened");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      
        Application.Quit();
#endif
    }
    
}
