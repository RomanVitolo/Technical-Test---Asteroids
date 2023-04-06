using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    private float timer;

    void Start() => timer = spawnDelay;

    private void Awake()
    {
        if (GameSettings.Instance.RandomSpawnObjects)
        {
            UtilitySettingsClass.ScreenLimits();
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = spawnDelay;
            SpawnAsteroids(0);
            SpawnAsteroids(1);
        }
    }

    private void SpawnAsteroids(int index)
    {
        GameObject objectToSpawn = ObjectPooler.Instance.GetPooledObject(index);
        objectToSpawn.SetActive(true);
        if (GameSettings.Instance.RandomSpawnObjects)
        {
            objectToSpawn.transform.position = UtilitySettingsClass.RandomSpawnObjects();
        }
        else
        {
            objectToSpawn.transform.position = UtilitySettingsClass.GetLimits();
        }
    }
}


    
