using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    public int maxBullets = 20;
    public float chargingTime = 2f;
    private bool reload = false;
    private string hand;

    private int currentBullets;
    private int CurrentBullets
    {
        get => currentBullets;
        set
        {
            if (value < 0)
                currentBullets = 0;
            else if (value > maxBullets)
                currentBullets = maxBullets;
            else
                currentBullets = value;

            OnBulletsChanged?.Invoke(currentBullets);
            OnChargeChanged?.Invoke((float)currentBullets / maxBullets);
        }
    }

    public UnityEvent OnReloadStart;
    public UnityEvent OnReloadEnd;

    public UnityEvent<int> OnBulletsChanged;
    public UnityEvent<float> OnChargeChanged;

    private void Start()
    {
        CurrentBullets = maxBullets;
    }

    public bool Use(int amount = 1)
    {
        if (CurrentBullets >= amount && !reload)
        {
            CurrentBullets -= amount;

            return true;
        }
        else
        {
            StartReload();
            return false;
        }
    }

    public void StartReload()
    {
        reload = true;
        if (currentBullets == maxBullets)
            return;

        StopAllCoroutines();
        StartCoroutine(ReloadProcess());
    }

    public void StopReload()
    {
        StopAllCoroutines();
    }

    private IEnumerator ReloadProcess()
    {
        OnReloadStart?.Invoke();

        var beginTime = Time.time;
        var beginBullets = currentBullets;
        var enoughPercent = 1f - ((float)currentBullets / maxBullets);
        var enoughChargingTime = chargingTime * enoughPercent;

        while (true)
        {
            var t = (Time.time - beginTime) / enoughChargingTime;
            if (t >= 1f)
                break;

            CurrentBullets = (int)Mathf.Lerp(beginBullets, maxBullets, t);
            yield return null;
        }

        CurrentBullets = maxBullets;
        reload = false;
        OnReloadEnd?.Invoke();
    }

    public void NowMagazine(string hand)
    {
        if(hand == "left")
        {
            Debug.Log("left");
            this.hand = hand;
            WeaponeManager.instance.LeftMagazine(this);
        }
        else
        {
            this.hand = hand;
            WeaponeManager.instance.RightMagazine(this);
        }
    }

    public void Realeasemagazine()
    {
        if (hand == "left")
        {
            this.hand = null;
            WeaponeManager.instance.LeftRealeaseMagazine();
        }
        else
        {
            this.hand = null;
            WeaponeManager.instance.RightRealeaseMagazine();
        }
    }

    public int CurrentBullet()
    {
        return CurrentBullets;
    }
}
