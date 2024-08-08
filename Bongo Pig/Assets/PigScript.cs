using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PigScript : Sounds
{
    public Rigidbody2D slotforrigidbody;
    public float flapForce;
    public LogicScript logicScript;
    public bool birdIsAlive = true;
    bool firstSizeIncreasing = false;
    bool secondSizeIncreasing = false;
    bool thirdSizeIncreasing = false;
    [Header("Animation settings")]
    public Animator animator;
    void Start()
    {
        Time.timeScale = 0f;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logicScript.lastScoreInt = PlayerPrefs.GetInt("LastScore");
        logicScript.lastScoreText.text = logicScript.lastScoreInt.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if ((logicScript.playerScore > 4)&&(firstSizeIncreasing == false))
        {
            transform.localScale = transform.localScale + Vector3.one;
            firstSizeIncreasing = true;
            PlaySound(sounds[2]);
        }
        if ((logicScript.playerScore > 9) && (secondSizeIncreasing == false))
        {
            transform.localScale = transform.localScale + Vector3.one;
            secondSizeIncreasing = true;
            PlaySound(sounds[2]);
        }
        if ((logicScript.playerScore > 14) && (thirdSizeIncreasing == false))
        {
            transform.localScale = transform.localScale + Vector3.one;
            thirdSizeIncreasing = true;
            PlaySound(sounds[2]);
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            slotforrigidbody.velocity = Vector2.up * flapForce;
            animator.SetBool("isJump", true);
            PlaySound(sounds[0]);
        }
        else animator.SetBool("isJump", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        PlaySound(sounds[3]);
        birdIsAlive = false;
    }
}
