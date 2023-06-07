using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    private int Gundamage;
    private int damagecount;

    public Mob target;

    public void Call(int damage)
    {
        target.DecreaseMobHP(damage);
    }
}
