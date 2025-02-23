using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] Color DayLight = Color.white;
    [SerializeField] Color NightLight;
    [SerializeField] AnimationCurve NightTimeCurve;
    [SerializeField] TextMeshProUGUI TimeText;

    float secondInDay = 86400f;
    float time = 0;

    private void Update()
    {
        time += Time.deltaTime*120; 
        time %= secondInDay; // Reset time after a full day

        int seconds = Mathf.FloorToInt(time % 60);
        int minutes = Mathf.FloorToInt((time % 3600) / 60); 
        int hours = Mathf.FloorToInt(time / 3600); 
        
        TimeText.text = $"{hours:00}:{minutes:00}:{seconds:00}"; 

    }
    
}
