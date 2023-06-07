using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomAgentSpeedRatio : MonoBehaviour
{
    public static float min = 0.8f;
    public static float max = 1.5f;

    private NavMeshAgent target;

    public void Call()
    {
        target = GetComponent<NavMeshAgent>();
        target.speed *= Random.Range(min, max);
    }

    public void SpeedMinMax()
    {
        min = 1.5f;
        max = 2f;
    }
}