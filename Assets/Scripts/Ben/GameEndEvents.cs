using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndEvents : MonoBehaviour
{
    public GameObject GameEndingObj;

    private ChooseWire GMPaused;

    private void Start()
    {
        GMPaused = this.GetComponent<ChooseWire>();
    }

    public void GameEnd(string message)
    {
        GMPaused.isPaused = true;
        GameEndingObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
        GameEndingObj.SetActive(true);

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
