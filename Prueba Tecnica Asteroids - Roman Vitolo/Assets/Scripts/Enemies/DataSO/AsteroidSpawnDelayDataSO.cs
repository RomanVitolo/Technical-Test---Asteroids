using UnityEngine;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "DataSO/AsteroidsSpawnDelay")]
    public class AsteroidSpawnDelayDataSO : ScriptableObject
    {
        //This script was created in case you want to have different object spawners. Not implemented yet
        public float SpawnDelay { get; set; }
    }
}
