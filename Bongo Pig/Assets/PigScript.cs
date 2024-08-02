using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PigScript : MonoBehaviour
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
    }
    // Update is called once per frame
    void Update()
    {
        if ((logicScript.playerScore == 5)&&(firstSizeIncreasing == false))
        {
            transform.localScale = transform.localScale + Vector3.one;
            firstSizeIncreasing = true;
        }
        if ((logicScript.playerScore == 10) && (secondSizeIncreasing == false))
        {
            transform.localScale = transform.localScale + Vector3.one;
            secondSizeIncreasing = true;
        }
        if ((logicScript.playerScore == 15) && (thirdSizeIncreasing == false))
        {
            transform.localScale = transform.localScale + Vector3.one;
            thirdSizeIncreasing = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            slotforrigidbody.velocity = Vector2.up * flapForce;
            animator.SetBool("isJump", true);
        }
        else animator.SetBool("isJump", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdIsAlive = false;
    }
}
