using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimerScript : MonoBehaviour
{
    public float timeForBeginning = 5f;

    void Update()
    {
        timeForBeginning -= Time.deltaTime;
        Debug.Log(timeForBeginning);
    }
}
