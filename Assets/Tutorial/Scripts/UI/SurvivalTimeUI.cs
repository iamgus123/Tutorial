using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTimeUI : MonoBehaviour
{
    private float startTime;

    private TextMeshProUGUI textUI;
    private Balance balance;

    private float dif;
    private float minute;
    private float second;
    private bool one = true;
    private bool two = true;

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        balance = GetComponent<Balance>();
    }

    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        dif = Time.time - startTime;
        minute = (int)(dif / 60f);
        second = dif % 60f;
        if (minute == 1 && one)
        {
            one = false;
            balance.One();
        }
        if(minute == 2 && two)
        {
            two = false;
            balance.Two();
        }
        if (minute == 3 && !one)
        {
            one = false;
            balance.Ending();
        }
        textUI.text = $"{minute:00} : {second:00}";
    }

    public float getTime()
    {
        dif = Time.time - startTime;
        return dif;
    }
}