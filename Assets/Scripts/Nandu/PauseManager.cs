using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private ChooseWire GMPaused;

    private void Start()
    {
        GMPaused = this.GetComponent<ChooseWire>();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GMPaused.isPaused = true;
        pauseMenu.SetActive(true);
        //pause state of game at some point
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GMPaused.isPaused = false;
        pauseMenu.SetActive(false);
        //resume game state
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        //add scene manager here to load the correct scene
    }
}
