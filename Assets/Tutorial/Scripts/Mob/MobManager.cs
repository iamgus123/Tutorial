using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobManager : MonoBehaviour
{
    private static MobManager instance;
    public static MobManager Instance
    {
        get
        {
            return instance;
        }
    }

    private List<Mob> mobs = new List<Mob>();
    private MobCounterUI target;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        target = GetComponent<MobCounterUI>();
        if (instance == null)
                instance = GameObject.FindObjectOfType<MobManager>();
        if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnSpawned(Mob mob)
    {
        mobs.Add(mob);
    }

    public void OnDestroyed(Mob mob)
    {
        target.MobKill();
        target.ScoreAdd(mob.Score);
        mobs.Remove(mob);
    }

    public void DestroyAll()
    {
        NextSceen.instance.setKill(target.Killed());
        NextSceen.instance.setScore(target.Score());
        while (mobs.Count > 0)
        {
            mobs[0]?.Destroy();
        }
    }
}