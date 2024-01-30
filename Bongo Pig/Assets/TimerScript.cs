using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeForBeginning = 6f;
    public LogicScript logicScript;
    public GameObject Logic;
    [SerializeField] Text timer; 
    
    private void Start()
    {
        timer.enabled = false;
        logicScript = Logic.GetComponent<LogicScript>();
    }
    void Update()
    {
        if (logicScript.isGameStarted)
        {
            timer.enabled = true;
            if (timeForBeginning > 0)
            {
                int timeInt = Mathf.FloorToInt(timeForBeginning % 60);
                timeForBeginning -= (Time.realtimeSinceStartup) / 3600;
                timer.text = string.Format("{0}", timeInt);
            }
            else
            {
                timeForBeginning = 0f;
                timer.enabled = false;
            }
        }
    }
}
