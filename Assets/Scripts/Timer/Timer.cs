using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    public bool isTiming = false;

    decimal timer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTiming = true;
            timer = 0;
            print($"Collided with {gameObject.name}");
        }
    }

    private void Update()
    {
        StartTimer();
        UpdateTimerDisplay();
        print(timer);
    }

    private void StartTimer()
    {
        if (!isTiming) return;

        timer += (decimal)Time.deltaTime;
    }

    private void UpdateTimerDisplay()
    {
        decimal timeScore = Math.Round(timer, 2);
        timerText.text = $"Time Spent: {timeScore}";
    }
}
