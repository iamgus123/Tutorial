using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextSceen : MonoBehaviour
{
    private float time;
    private int Hp;
    private int kill;
    private int score;

    public float SceenDelay = 3f;

    public static NextSceen instance;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
                instance = this;       
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public UnityEvent OnCall;

    public void Call() 
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        yield return new WaitForSeconds(SceenDelay);
        OnCall?.Invoke();
    }
    
    public void setTime(float time)
    {
        this.time = time;
    }

    public float getTime()
    {
        return time;
    }

    public void setHp(int hp)
    {
        this.Hp = hp;
    }

    public int getHp()
    {
        return Hp;
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return score;
    }

    public void setKill(int kill)
    {
        this.kill = kill;
    }
    
    public int getKill()
    {
        return kill;
    }
}
