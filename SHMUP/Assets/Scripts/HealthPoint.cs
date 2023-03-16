using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthPoint : MonoBehaviour
{
    [SerializeField] private float _health ;
    [SerializeField] private GameObject _ship;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"[{GetType().Name}][onColisionEnter2D] : {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {
            if (_health == 0)
            {
                Debug.Log($"Death: {_health}");
                _ship.SetActive(false);
            }
            else if (objects.Type == DetectCollisionType.Enemy)
            {
                _health--;
                Debug.Log($"Helth: {_health + 1}");
                // Destroy(collision.gameObject);

            }

        }

    }
}
