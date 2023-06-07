using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    public int maxHP = 100;
    private int hp;

    public UnityEvent<int> OnHpChanged;
    public UnityEvent OnHit;
    public UnityEvent OnDestroy;

    private static Core instance;
    public static Core Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Core>();
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        hp = maxHP;
    }

    public void OnTriggerEnter(Collider other)
    {
        var mob = other.GetComponent<Mob>();
        if (mob != null)
        {
            DecreaseHP(mob.Attack());
            mob.Attacked();
        }
    }

    private void DecreaseHP(int damage)
    {
        hp -= damage;
        HpManager.Instance.Decrease(damage);
        if (hp <= 0)
        {
            NowHp();
            OnDestroy?.Invoke();
        }
    }
    
    public void NowHp()
    {
        NextSceen.instance.setHp(hp);
    }

    public void HellHp(int heelgage)
    {
        hp += heelgage;
    }
}