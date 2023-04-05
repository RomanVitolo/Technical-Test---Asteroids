using UnityEngine;

[CreateAssetMenu(menuName = "DataSO/PlayerMovementData")]
public class PlayerMovementDataSO : ScriptableObject
{
    [HideInInspector]
    public Rigidbody2D Rigidbody2D;
    
    public float Speed;
    [Range(0.01f, 50f)]
    public float Acceleration;
    [Range(0.01f, 50f)]
    public float Deceleration;
}
