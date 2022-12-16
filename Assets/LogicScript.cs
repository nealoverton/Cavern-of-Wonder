using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public float deadZone = -45;
    public float scrollSpeed = 5;
    public bool gameIsOver = false;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public AudioSource gameOverSFX;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void restartGame()
    {
        gameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() 
    {
        if(!gameIsOver)
        {
            gameOverSFX.Play();
        }

        gameOverScreen.SetActive(true);
        gameIsOver = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
