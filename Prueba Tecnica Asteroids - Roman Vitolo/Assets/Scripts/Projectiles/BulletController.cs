using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletMovementData _bulletMovementData;

    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _bulletMovementData.Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Init(Rigidbody2D rigidbody2D, Vector3 dir)
    {
       _bulletMovementData.Rigidbody2D.velocity  = dir * (_bulletMovementData.Speed * Time.fixedDeltaTime);
    }


    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        //ObjectPooler.Instance.GetAllPooledObjects(_bulletMovementData.index);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            col.transform.GetComponent<EnemyController>().Die();
            
            this.gameObject.SetActive(false);
           // ObjectPooler.Instance.GetAllPooledObjects(_bulletMovementData.index);
        }
    }
}
