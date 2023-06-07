using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCounterUI : MonoBehaviour
{
    private int mobkillCount;
    private int score;

    private void Awake()
    {
        mobkillCount = score = 0;
    }

    public void MobKill()
    {
        mobkillCount++;
    }

    public void ScoreAdd(int score)
    {
        this.score += score;
    }

    public int Killed()
    {
        return mobkillCount;
    }

    public int Score()
    {
        return score;
    }
}