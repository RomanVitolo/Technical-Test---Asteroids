using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CannonWeapon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BulletController _bullets;
    [SerializeField] private BulletMovementData _bulletMovementData;
    
    private Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }
    
    private void Update()
    {
        GetMousePosition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullets();
        }
    }

   

    private void GetMousePosition()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        transform.up = Vector3.MoveTowards(transform.up, mousePosition, _bulletMovementData.RotationSpeed * Time.deltaTime);
    }

    public void SpawnBullets()
    {
        GetBulletFromPool(true);
    }

    private void GetBulletFromPool(bool activeOrDeactivated)
    {
        GameObject spawnObject = ObjectPooler.Instance.GetPooledObject(2);
        spawnObject.SetActive(activeOrDeactivated);
        spawnObject.transform.position = _spawnPoint.position;
        spawnObject.transform.rotation = _spawnPoint.rotation;
        _bullets.Init(_bulletMovementData.Rigidbody2D, transform.up);
    }
}
