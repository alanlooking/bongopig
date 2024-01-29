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
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            slotforrigidbody.velocity = Vector2.up * flapForce;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdIsAlive = false;
    }
}
