using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] Color DayLight = Color.white;
    [SerializeField] Color NightLight;
    [SerializeField] AnimationCurve NightTimeCurve;
    [SerializeField] Light2D globalLight;
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] float TimeScale = 120;

    public float startTime;

    float secondInDay = 86400f;
    float time = 0;
    int days = 0;
    

    private void Start(){
        time += startTime;
    }
    private void Update()
    {
        time += Time.deltaTime*TimeScale; 
        if(time >= secondInDay){
            TimeByDays();
        }
        
        TimeUI(time);
        LightCurve(time);
        
    }

    private void TimeByDays()
    {
        time %= secondInDay; // Reset time after a full day
        days += 1;
    }

    private void TimeUI(float time){
        int seconds = Mathf.FloorToInt(time % 60);
        int minutes = Mathf.FloorToInt((time % 3600) / 60); 
        int hours = Mathf.FloorToInt(time / 3600); 
        
        TimeText.text = hours.ToString("00:")+minutes.ToString("00:")+seconds.ToString("00"); 
    }

    private void LightCurve(float time){
        float hoursOnly = time / 3600f;
        float curve = NightTimeCurve.Evaluate(hoursOnly);
        Color light = Color.Lerp(DayLight, NightLight, curve);

        globalLight.color = light;
    }
    
}
