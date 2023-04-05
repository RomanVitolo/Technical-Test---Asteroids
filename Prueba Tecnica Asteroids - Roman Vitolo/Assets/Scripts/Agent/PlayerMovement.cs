using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public PlayerMovementDataSO PlayerMovementDataSo { get; set; }
    
    [SerializeField] protected float currentVelocity = 3f;
    [SerializeField] protected Vector2 movementDirection;
    [SerializeField] private float rotationSpeed;

    private Camera mainCamera;

    private void Awake()
    {
        PlayerMovementDataSo.Rigidbody2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        PlayerMovementDataSo.Rigidbody2D.velocity = currentVelocity * movementDirection.normalized;
        
    }

    private void Update()
    {
        FaceDirection();
    }

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
            currentVelocity += PlayerMovementDataSo.Acceleration * Time.fixedDeltaTime;
        }
        else
        {
            currentVelocity += PlayerMovementDataSo.Deceleration * Time.fixedDeltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0.01f, PlayerMovementDataSo.Speed);
    }
    
    private void FaceDirection()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        transform.up = mousePosition;
        /*float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);*/
    }
}
