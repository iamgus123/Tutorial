using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiRay : MonoBehaviour
{

    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        OnCreated?.Invoke();
    }
}
