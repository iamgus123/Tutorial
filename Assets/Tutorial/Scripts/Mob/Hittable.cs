using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent OnHit;
    public UnityEvent<int> OnHitDamgage;

    public void Hit()
    {
        OnHit?.Invoke();
    }

    public void HitDamage(int damage)
    {
        OnHitDamgage?.Invoke(damage);
    }
}