using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    [SerializeField] private BulletBehaviour _bulletPrefab;
    //public HealthPoint _healthPoint;
    //[SerializeField] private GameObject _target;
    //[SerializeField] private int _health;

    //public bool takeDamage = false;


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"[{GetType().Name}][onColisionEnter2D] : {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {
            if (objects.Type == DetectCollisionType.Enemy)
            {
                //Destroy(collision.gameObject);
                Destroy(_bulletPrefab.gameObject);
                
            }
            if (objects.Type == DetectCollisionType.Player)
            {
                //Destroy(collision.gameObject);
                Destroy(_bulletPrefab.gameObject);

            }


        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[{GetType().Name}][onTriggerEnter2D] : {collision.gameObject.name}");
        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {

            if (objects.Type == DetectCollisionType.Wall)
            {
                // Debug.Log($"[onTriggerEnter2D] : Wall : {objects.name}");
                Destroy(_bulletPrefab.gameObject);
            }
        }
    }

  
}
