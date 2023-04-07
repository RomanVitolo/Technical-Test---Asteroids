using EnemyBehaviour;
using UnityEngine;

namespace ProjectileBehaviour
{
    public class BulletController : MonoBehaviour
    {
        [Header("Get Bullet Movement Configuration")]
        [SerializeField] private BulletMovementData _bulletMovementData;

        private void OnEnable()
        {
            _bulletMovementData.Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    
        public void Init(Rigidbody2D rigidbody2D, Vector3 dir)
        {
            _bulletMovementData.Rigidbody2D.velocity  = dir * (_bulletMovementData.Speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Enemy"))
            {
                col.transform.GetComponent<EnemyController>().Die();
            
                this.gameObject.SetActive(false);
            }
        }
    }
}
