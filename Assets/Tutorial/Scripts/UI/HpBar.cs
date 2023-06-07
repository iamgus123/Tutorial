using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public int number;
    private float hp;
    private Image hpBar;

    private void Awake()
    {
        hpBar = GetComponent<Image>();
        HpManager.Instance.OnSpawn(this);
    }

    public void barDecrease()
    {
        hpBar.fillAmount = 0f;
    }

    public void InCreese()
    {
        hpBar.fillAmount = 1f;
    }

}
