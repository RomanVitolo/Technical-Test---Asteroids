using UnityEngine;

[CreateAssetMenu(menuName = "DataSO/BulletMovementData")]
public class BulletMovementData : ScriptableObject
{
    [HideInInspector]
    public Rigidbody2D Rigidbody2D;
    
    public float Speed;
    public float RotationSpeed;
    public int index;

    
    //This option was not implemented. The future goal is that the player can choose whether he wants the bullets to be destroyed or go through the screen.
    [HideInInspector]
    public bool UseScreenWrap;
}
