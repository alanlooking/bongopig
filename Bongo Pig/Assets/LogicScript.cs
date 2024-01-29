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
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public CandyMoveScript candyMoveScript;
    public CandySpawnScript candySpawnScript;
    public PigScript pigScript;
    public GameObject gameOverScreen;
    public GameObject Score;
    public GameObject startScreen;
    public GameObject candyScreen;
    public GameObject pigScreen;
    public GameObject containerForCandy;
    public GameObject candySpawner;
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
        rigidBody = pigScreen.GetComponent<Rigidbody2D>();
        spriteRenderer = pigScreen.GetComponent<SpriteRenderer>();
        candyMoveScript = containerForCandy.GetComponent<CandyMoveScript>();
        candySpawnScript = candySpawner.GetComponent<CandySpawnScript>();
        spriteRenderer.enabled = true;
        rigidBody.simulated = true;
        Score.SetActive(true);
        startScreen.SetActive(false);
        candyScreen.SetActive(true);
        candyMoveScript.enabled = true;
        candySpawnScript.enabled = true;
    }
    public void ExitGame()
    { 
        Application.Quit();
    }
}