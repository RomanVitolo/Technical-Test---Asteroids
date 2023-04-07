using UnityEngine;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "DataSO/EnemyScoreData")]
    public class AsteroidDataSO : ScriptableObject
    { 
        [field: SerializeField] public int ScoreValue { get; private set; }
        [field: SerializeField] public int index { get; private set; }
    }
}
