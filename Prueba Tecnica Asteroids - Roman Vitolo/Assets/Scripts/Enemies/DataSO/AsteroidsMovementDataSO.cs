using UnityEngine;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "DataSO/AsteroidsMovementData")]
    public class AsteroidsMovementDataSO : ScriptableObject
    {
        [HideInInspector]
        public Rigidbody2D Rigidbody2D;
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public float RotationSpeed { get;  set; }
        [field: SerializeField] public float ChangeDirectionTime { get;  set; }
        [field: SerializeField] public float minXRandomValue { get; private set; }
        [field: SerializeField] public float maxXRandomValue { get; private set; }
        [field: SerializeField] public float minYRandomValue { get; private set; }
        [field: SerializeField] public float maxYRandomValue { get; private set; }
    }
}
