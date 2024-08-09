using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : Sounds
{
    public Text BestScoreText;
    public int playerScore;
    public int lastScoreInt;
    public bool isGameStarted = false;
    public Text lastScoreText;
    public Text scoreText;
    public Text timer;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public CandyMoveScript candyMoveScript;
    public CandySpawnScript candySpawnScript;
    public PigScript pigScript;
    public GameObject Timer1;
    public GameObject gameOverScreen;
    public GameObject Score;
    public GameObject LastScore;
    public GameObject startScreen;
    public GameObject candyScreen;
    public GameObject pigScreen;
    public GameObject containerForCandy;
    public GameObject candySpawner;
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        lastScoreInt = playerScore;
        lastScoreText.text = lastScoreInt.ToString();
    }
    public void RestartGame()
    {
        PlaySound(sounds[0], 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (playerScore > PlayerPrefs.GetInt("LastScore"))
        {
            PlayerPrefs.SetInt("LastScore", playerScore);
        }
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        PlaySound(sounds[0], 2);
        BestScoreText.enabled = false;
        lastScoreText.enabled = false;
        //Timer1.SetActive(true);
        isGameStarted = true;
        StartCoroutine(TimerCoroutine());
        pigScript = pigScreen.GetComponent<PigScript>();
        rigidBody = pigScreen.GetComponent<Rigidbody2D>();
        spriteRenderer = pigScreen.GetComponent<SpriteRenderer>();
        candyMoveScript = containerForCandy.GetComponent<CandyMoveScript>();
        candySpawnScript = candySpawner.GetComponent<CandySpawnScript>();
        spriteRenderer.enabled = true;
        Score.SetActive(true);
        rigidBody.simulated = true;
        startScreen.SetActive(false);
        candyScreen.SetActive(true);
        candyMoveScript.enabled = true;
        candySpawnScript.enabled = true;

    }
    private IEnumerator TimerCoroutine()
    { 
        yield return new WaitForSecondsRealtime(7);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        PlaySound(sounds[1], 2);
        Application.Quit();
    }
}