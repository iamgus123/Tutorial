using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponeManager : MonoBehaviour
{
    public static WeaponeManager instance;
    public Magazine rightmagazine;
    public Magazine leftmagazine;

    public static WeaponeManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<WeaponeManager>();
            return instance;
        }
    }

    public UnityEvent<Gun> OnDestroy;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
                instance = this;       
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void RightMagazine(Magazine magazine)
    {
        rightmagazine = magazine;
    }

    public void RightRealeaseMagazine()
    {
        rightmagazine = null;
    }

    public void LeftMagazine(Magazine magazine)
    {
        leftmagazine = magazine;
    }

    public void LeftRealeaseMagazine()
    {
        leftmagazine = null;
    }

    public void Destroyed()
    {
        rightmagazine = null;
        leftmagazine = null;
    }
}
