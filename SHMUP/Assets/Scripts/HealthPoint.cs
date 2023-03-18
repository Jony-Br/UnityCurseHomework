using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class HealthPoint : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _ship;
    [SerializeField] private BulletBehaviour _bulletPrefab;

    //[SerializeField] private ContainerEnemy _containerEnemy;
    //[SerializeField] private ShipType _shipToUse;




    private void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log($"[{GetType().Name}][onColisionEnter2D] : {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {
            if (_health <= 1)
            {
                // Debug.Log($"Death: {_health}");
                //Destroy(_ship.gameObject);
                //_ship.SetActive(false);

                Debug.Log($"Death: {_health}");
                Destroy(_ship.gameObject);

            }
            else if (objects.Type == DetectCollisionType.Enemy)
            {
                _health--;
                Debug.Log($"Helth: {_health}");
                
                // Destroy(collision.gameObject);

            }
            else if (objects.Type == DetectCollisionType.Bullet)
            {
                _health--;
                Debug.Log($"Helth: {_health}");
             
                // Destroy(collision.gameObject);

            }
            if (objects.Type == DetectCollisionType.EnemyBullet)
            {
                _health--;
                Debug.Log($"Helth: {_health}");


            }
            if (objects.Type == DetectCollisionType.Player)
            {
                Destroy(_ship.gameObject);
                // Destroy(collision.gameObject);

            }
            

        }

    }


}




