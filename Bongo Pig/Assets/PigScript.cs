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
    public float startingTime = 5f;
    public bool buttonIsEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        startingTime = 5f;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (buttonIsEntered) 
        {
            startingTime -= Time.deltaTime;
        }
        if (buttonIsEntered && (startingTime<0.5))
        {
            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                slotforrigidbody.velocity = Vector2.up * flapForce;
            }
        }
        Debug.Log(startingTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdIsAlive = false;
    }
}
