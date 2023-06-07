using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HpManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int heelhp = 50;
    public UnityEvent<int> OnHeel;
    private static HpManager instance;
    private int cnt;

    public static HpManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<HpManager>();
            return instance;
        }
    }

    private List<HpBar> bars = new List<HpBar>();

    private void Awake()
    {
        instance = this;
    }

    public void OnSpawn(HpBar bar)
    {
        bars.Add(bar);
        cnt++;
    }

    public void HeelHp()
    {    
        int heelgage = 0;
        heelhp = heelhp/10;
        for (int i = 0; i < heelhp; i++)
        {
            if (cnt >= 10)
                break;
            for (int p = 0; p < 10; p++)
            {
                if (bars[p].number == cnt)
                {
                    bars[p].InCreese();
                    break;
                }
            }
            cnt++;
            heelgage += 10;
        }
        OnHeel?.Invoke(heelgage);
    }

    public void Decrease(int damage)
    {
        damage = damage / 10;
        for (int i=0; i < damage; i++)
        {
            cnt--;
            if(cnt < 0)
                break;
            for(int p=0; p<10;p++)
            {
                if(bars[p].number == cnt) 
                {
                    bars[p].barDecrease();
                    break;
                }
            }
        }
    }
}
