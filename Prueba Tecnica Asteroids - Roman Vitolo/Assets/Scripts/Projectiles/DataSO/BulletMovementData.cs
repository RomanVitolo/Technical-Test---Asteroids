using UnityEngine;

[CreateAssetMenu(menuName = "DataSO/BulletMovementData")]
public class BulletMovementData : ScriptableObject
{
    [SerializeField] public float Speed;
    [SerializeField] public float RotationSpeed;
    [SerializeField] public int index;

    [HideInInspector]
    public Rigidbody2D Rigidbody2D;
    
}
