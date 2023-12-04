using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    [SerializeField] CanvasGroup hitPanel, gameOverPanel,winTheGamePanel;
    [SerializeField] TextMeshProUGUI hitText, arrowText;

    private byte maxArrow;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        

        Instance = this;
    }

    public void FunctionOfThePartHit(string hitPart)
    {
        hitText.text= hitPart+ " SHOT!!";
        hitPanel.alpha = 0;
        hitPanel.DOFade(1, 2f)
            .OnComplete(() =>
            {
                
                StartCoroutine(FadeOutPanelAfterDelay());
            });
    }

    public void ButtonSystem(GameObject panel)
    {
        if (Time.timeScale==1f)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            return;
        }

        panel.SetActive(false);
        Time.timeScale = 1f;
    }


    private IEnumerator FadeOutPanelAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);

        hitPanel.DOFade(0, 1.0f);
    }


    public void RestartButtonSceneSystem()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void NextLevelButtonSceneSystem()
    {
        SceneManager.LoadScene(2);
    }

    public void WinTheGameButton() 
    {
        SceneManager.LoadScene(0);
    }

    public void HomeButtonSceneSystem()
    {
        SceneManager.LoadScene(0);
    }


    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.DOFade(1, 1.5f).OnComplete(()=>
        {
            Time.timeScale = 0f;
        });
        
        
    }
    
    public void SetTheArrowNumber(byte arrow)
    {
        maxArrow = arrow;
        arrowText.text= "x" + maxArrow;
    }
    
    public void OneArrowDecreased()
    {
        maxArrow--;
        arrowText.text = "x" + maxArrow;
        if (maxArrow<=0)
        {
            GameOver();
        }
    }

    public void LevelWon()
    {
        winTheGamePanel.gameObject.SetActive(true);
        winTheGamePanel.DOFade(1, 1.5f).OnComplete(() =>
        {
            Time.timeScale = 0f;
        });
    }
}
