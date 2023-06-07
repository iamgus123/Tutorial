using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombCreat : MonoBehaviour
{
    public GameObject Bomb = null;

    public bool playOnStart = true;
    public float startFactor = 1f;
    public float additiveFactor = 0.1f;
    public float delayPerSpawnGroup = 0.1f;
    public int Count = 1;

    private void Start()
    {
        if (playOnStart)
            Play();
    }

    public void Play()
    {
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var factor = startFactor;
        var wfs = new WaitForSeconds(delayPerSpawnGroup);
        yield return StartCoroutine(SpawnProcess(factor));
    }

    private IEnumerator SpawnProcess(float factor)
    {
        for (int i=0; i < Count; i++)
        {
            Spawn();
            yield return new WaitForSeconds(delayPerSpawnGroup);
        }
        Stop();
    }

    private void Spawn()
    {
        Instantiate(Bomb, transform.position, transform.rotation, transform);
    }
}
