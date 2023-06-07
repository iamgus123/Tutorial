using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Balance : MonoBehaviour
{
    private SurvivalTimeUI target;

    public UnityEvent OnSectionOne, OnSectionTwo, OnEding;

    public void Awake()
    {
        target = GetComponent<SurvivalTimeUI>();
    }

    public void One()
    {
        OnSectionOne?.Invoke();
    }

    public void Two()
    {
        OnSectionTwo?.Invoke();
    }

    public void Ending()
    {
        NextSceen.instance.setTime(target.getTime());
        OnEding?.Invoke();
    }
}
