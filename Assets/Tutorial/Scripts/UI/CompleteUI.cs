using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteUI : MonoBehaviour
{
    private NextSceen target;
    private Text textUI;

    public void Awake()
    {
        textUI = GetComponent<Text>();
        target = NextSceen.instance;
    }

    public void result()
    {
        if(target.getTime() >= 180f)
        {
            textUI.text = "Mission Complete";
        }
        else
        {
            textUI.text = "Mission Fail";
        }
    }

    public void result2()
    {
        if(target.getTime() >= 180f)
        {
            textUI.text = "Clear";
        }
        else
        {
            textUI.text = "Fail";
        }
    }

    public void getTime()
    {
        float dif = target.getTime();
        int minute = (int)(dif / 60f);
        float second = dif % 60f;
        textUI.text = $"{minute:00} : {second:00}";
    }

    public void getScore()
    {
        int score = target.getScore();
        int dif = (int)target.getTime();
        score += dif*50;
        textUI.text = $"{score}";
    }

    public void getHp()
    {
        int hp = target.getHp();
        if(hp < 0)
        {
            hp = 0;
        }
        textUI.text = $"{hp}";
    }

    public void getKill()
    {
        textUI.text = $"{target.getKill()}";
    }
}
