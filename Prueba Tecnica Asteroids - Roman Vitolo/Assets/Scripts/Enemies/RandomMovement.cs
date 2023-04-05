using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomMovement : MonoBehaviour
{
    [SerializeField] private AsteroidsMovementDataSO _asteroidsMovementDataSo;
    
    private float timer;

    void Awake()
    {
        _asteroidsMovementDataSo.Rigidbody2D = GetComponent<Rigidbody2D>();
        timer = 0f;
    }

    private void Start()
    {
        ChangeDirection();
        Move();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= _asteroidsMovementDataSo.ChangeDirectionTime)
        {
            timer = 0f;
            ChangeDirection();
        }
        Move();
    }
    
    private void ChangeDirection()
    {
        Vector2 direction = new Vector2(Random.Range(_asteroidsMovementDataSo.minXRandomValue, _asteroidsMovementDataSo.maxXRandomValue), 
            Random.Range(_asteroidsMovementDataSo.minYRandomValue, _asteroidsMovementDataSo.maxYRandomValue));
        _asteroidsMovementDataSo.Rigidbody2D.velocity = direction.normalized * (_asteroidsMovementDataSo.Speed * Time.fixedDeltaTime);
    }
    
    void Move()
    {
        Vector2 position =  _asteroidsMovementDataSo.Rigidbody2D.position;
        _asteroidsMovementDataSo.Rigidbody2D.position = position;
        _asteroidsMovementDataSo.Rigidbody2D.velocity =  _asteroidsMovementDataSo.Rigidbody2D.velocity.normalized * (_asteroidsMovementDataSo.Speed * Time.fixedDeltaTime);
    }
}
