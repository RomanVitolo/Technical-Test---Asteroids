using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    private float timer;

    private void Awake()
    {
        UtilitySettingsClass.ScreenLimits();
    }

    void Start() => timer = spawnDelay;

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
        objectToSpawn.transform.position = SpawnPosition();
    }


    private Vector3 SpawnPosition()
    {
        float x = Random.Range(UtilitySettingsClass.minX, UtilitySettingsClass.maxX);
        float y = Random.Range(UtilitySettingsClass.minY, UtilitySettingsClass.maxY);
        float z = 0;
        
        Vector3 vector = new Vector3(x, y, z);

        return vector;
    }
}
