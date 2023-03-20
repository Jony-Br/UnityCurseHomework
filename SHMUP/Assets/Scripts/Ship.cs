using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ship : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private int _health;
    //[SerializeField] private ShipAsigning _shipAsigning;

    //[SerializeField] private WeaponType _weaponType;
    //[SerializeField] private ScorePoint _scorePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"[{GetType().Name}][onColisionEnter2D] : {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {


            if (objects.Type == DetectCollisionType.Enemy)
            {
                Damage(objects);
                Debug.Log($"Name {objects.Type} Helth: {_health}");

                

            }

            if (objects.Type == DetectCollisionType.EnemyBullet)
            {
                Damage(objects);
                Debug.Log($"Name {objects.Type} Collision on : {collision.gameObject}");
                Destroy(collision.gameObject);


            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {
            

            if (objects.Type == DetectCollisionType.EnemyBullet)
            {
                Damage(objects);
                Debug.Log($"Name {objects.Type} Collision on : {collision.gameObject}  Helth: {_health}");
                Destroy(collision.gameObject);


            }

        }
    }

    public void Damage(DetectionCollision objects)
    {
        _health--;
        if (_health <= 0)
        {
            Debug.Log($"Name {objects.Type} Death: {_health}");
            DieShip();
        }
    }

    public void DieShip()
    {
        Debug.Log($"Ship Death");
        Destroy(_ship.gameObject);


    }
}
