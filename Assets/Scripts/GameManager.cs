using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI panelScore;
    [SerializeField] TextMeshProUGUI finishScore;

    [SerializeField]ScoreDataSO scoreDataSO;
    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject finishPanel;

    [SerializeField] GameObject player;
    
    private void Start()
    {  
        restartPanel.SetActive(false);
        finishPanel.SetActive(false);
    }
    public void AddScore()
    {
        scoreDataSO.score++; 
        scoreText.text = scoreDataSO.score.ToString();
    }
   
    public void EndGame()
    {
        player.SetActive(false);
        panelScore.text = scoreDataSO.score.ToString();
        restartPanel.SetActive(true);  
    }
    public void StartGame()
    {
        scoreDataSO.score = 0;
        scoreText.text = scoreDataSO.score.ToString();
        restartPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void FinishGame()
    {
        player.SetActive(false);
        finishScore.text = scoreDataSO.score.ToString();
        finishPanel.SetActive(true);
    }
}
