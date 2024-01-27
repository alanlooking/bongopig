using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject Score;
    public GameObject startScreen;
    public GameObject candyScreen;
    public GameObject pigScreen;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public GameObject containerForCandy;
    public CandyMoveScript candyMoveScript;
    public GameObject candySpawner;
    public CandySpawnScript candySpawnScript;
    public PigScript pigScript;
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        pigScript = pigScreen.GetComponent<PigScript>();
        pigScript.buttonIsEntered = true;
        spriteRenderer = pigScreen.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        Score.SetActive(true);
        startScreen.SetActive(false);
        candyScreen.SetActive(true);
        if (pigScript.startingTime < 0.5) 
        {
            candyMoveScript = containerForCandy.GetComponent<CandyMoveScript>();
            candyMoveScript.enabled = true;
            candySpawnScript = candySpawner.GetComponent<CandySpawnScript>();
            candySpawnScript.enabled = true;
            rigidBody = pigScreen.GetComponent<Rigidbody2D>();
            rigidBody.simulated = true;
        }
    }
    public void ExitGame()
    { 
        Application.Quit();
    }
}