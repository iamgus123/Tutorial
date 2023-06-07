using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private static SpawnerManager instance;

    public static SpawnerManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<SpawnerManager>();
            return instance;
        }
    }

    private List<Spawner> Spawners = new List<Spawner>();

    public void AddSpawner(Spawner spawner)
    {
        Spawners.Add(spawner);
    }

    public void SectionOne()
    {
        for (int i=0; i <Spawners.Count; i++)
        {
            Spawners[i].Max();
        }
    }

    public void isBoss()
    {
        Spawners[Random.Range(0, Spawners.Count)].isBoss();
    }

    public void Stopped()
    {
        for (int i = 0; i < Spawners.Count; i++)
        {
            Spawners[i].Stop();
        }
    }
}
