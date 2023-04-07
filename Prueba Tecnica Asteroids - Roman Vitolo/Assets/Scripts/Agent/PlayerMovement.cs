using UnityEngine;

namespace PlayerBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Get Player Movement Configuration")]
        [Space(15)]
        [SerializeField] private PlayerMovementDataSO _playerMovementData;
        
        [Header("Utility Parameters")]
        [SerializeField] protected float currentVelocity = 3f;
        [SerializeField] protected Vector2 movementDirection;
        
        private Camera mainCamera;
    
        private void Awake()
        {
            _playerMovementData.Rigidbody2D = GetComponent<Rigidbody2D>();
            mainCamera = Camera.main;
        }
    
        private void FixedUpdate()
        {
            _playerMovementData.Rigidbody2D.velocity = currentVelocity * movementDirection.normalized;
        }
    
        private void Update() =>  FaceDirection();
        
        public void MovePlayer(Vector2 movementInput)
        {
            if (movementInput.magnitude > 0)
            {
                if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                    currentVelocity = 0;
                movementDirection = movementInput.normalized;
            }
            currentVelocity = CalculateSpeed(movementInput);
        }
    
        private float CalculateSpeed(Vector2 movementInput)
        {
            if (movementInput.magnitude > 0)
            {
                currentVelocity += _playerMovementData.Acceleration * Time.fixedDeltaTime;
            }
            else
            {
                currentVelocity += _playerMovementData.Deceleration * Time.fixedDeltaTime;
            }
    
            return Mathf.Clamp(currentVelocity, 0.01f, _playerMovementData.Speed);
        }
        
        private void FaceDirection()
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
    
            transform.up = mousePosition;
        }
    }
}

