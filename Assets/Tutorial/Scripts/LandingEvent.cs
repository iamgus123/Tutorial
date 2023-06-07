using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandingEvent : MonoBehaviour
{
    public UnityEvent OnCall;

    public void Awake()
    {
        OnCall?.Invoke();
    }
}
