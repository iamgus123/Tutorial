using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Mobs = null;
    public GameObject Middle_Mobs = null;
    public GameObject Event_Mobs = null;
    public GameObject Boss = null;

    public bool playOnStart = true;
    public float startFactor = 1f;
    public float additiveFactor = 0.1f;
    public float delayPerSpawnGroup = 3f;
    public int middlecnt; 

   
    private float min = 2f;
    private float max = 6f;
    private int cnt = 0;

    private void Start()
    {
        SpawnerManager.Instance.AddSpawner(this);
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
        Spawn(Event_Mobs);
        while (true)
        {
            if (cnt % 10 == middlecnt && Middle_Mobs != null)
                Spawn(Middle_Mobs);
            else
                Spawn(Mobs);
            yield return new WaitForSeconds(Random.Range(min, max));
            cnt++;
        }
    }

    private void Spawn(GameObject name)
    {
        if(name == Event_Mobs)
        {
            transform.Translate(0, 10, 0);
            Instantiate(name, transform.position, transform.rotation, transform);
        }
        else
        {
            Instantiate(name, transform.position, transform.rotation, transform);
        }
    }

    public void Max()
    {
        max = 3;
    }

    public void isBoss()
    {
        Instantiate(Boss, transform.position, transform.rotation, transform);
    }
}
