using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;
    [Header("Limit Settings")]
    public bool haslimit;
    public float timerLimit;

    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TEST with keyboard
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartTimer();
        }



        if (isRunning)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }
        
        if(haslimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            LimitReached();
        }
        SetTimerText();
    }
    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void LimitReached()
    {

    }
}
