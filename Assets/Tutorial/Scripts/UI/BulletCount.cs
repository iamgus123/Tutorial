using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class BulletCount : MonoBehaviour
{
    private TextMeshProUGUI textUI;
    private Magazine leftmagazine = null;
    private Magazine rightmagazine = null;

    private int leftbullet;
    private int rightbullet;

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    public UnityEvent<Magazine> OnMagazine;

    public void NowMagazine()
    {
        leftmagazine = WeaponeManager.Instance.leftmagazine;
        rightmagazine = WeaponeManager.Instance.rightmagazine;
    } 

    private void Update()
    {
        if(leftmagazine == null)
            leftbullet = 0;
        else
        {
            leftbullet = leftmagazine.CurrentBullet();
        }

        if (rightmagazine == null)
            rightbullet = 0;
        else
        {
            rightbullet = rightmagazine.CurrentBullet();
        }

        textUI.text = $"||||||||||||||||||||||||||||||\nx{leftbullet}        x{rightbullet}";
    }
}
