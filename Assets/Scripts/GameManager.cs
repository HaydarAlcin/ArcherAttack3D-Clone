using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1.0f;
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseThePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenThePanel(GameObject panel)
    {
        panel.SetActive(true);
    }


}
