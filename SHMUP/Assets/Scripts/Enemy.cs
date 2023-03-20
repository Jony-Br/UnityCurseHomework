using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestoy;

    [SerializeField] private bool _canShoot = false;

    [SerializeField] private BulletBehaviour _bulletEnemyPrefab;
    [SerializeField] private Transform _bulletEnemyStartPoint1;
    [SerializeField] private Transform _bulletEnemyStartPoint2;

    [SerializeField] private GameObject _ship;
    [SerializeField] private EnemyShipType _typeShip;

    [SerializeField] private float _scorePoint;

    [SerializeField] private bool _hasBonus;

    private bool delay = false;
    private bool bulletDestroy = false;







   



    void Start()
    {

        

    }
    void Update()
    {
        MoveTarget();
       
        StartCoroutine(Shoot(_typeShip));
        Divide();

    }


    private void MoveTarget()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    IEnumerator Shoot(EnemyShipType typeShip)
    {

        if (_canShoot && delay == false) 
        {
            
            if (typeShip.Type == EnemyShipTypes.Destroyer)
            {
                Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint1.position, transform.rotation);
                //Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint2.position, transform.rotation);
                delay = true;
                yield return new WaitForSeconds(5f);
                delay = false;
            }
            if (typeShip.Type == EnemyShipTypes.Himera)
            {
                Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint1.position, transform.rotation);
                delay = true;
                yield return new WaitForSeconds(1f);
                delay = false;
            }
            if (typeShip.Type == EnemyShipTypes.Keeper)
            {
                Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint1.position, transform.rotation);
                delay = true;
                yield return new WaitForSeconds(1f);
                delay = false;
            }


            
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"[{GetType().Name}][onColisionEnter2D] : {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {

            if (objects.Type == DetectCollisionType.Player)
            {
                Debug.Log($"Name {objects.Type} Helth: {_health}");
                DieShip();

            }


            if (objects.Type == DetectCollisionType.Bullet)
            {
                Damage(objects);
                Debug.Log($"Name {objects.Type} Collision on : {collision.gameObject}");

                Destroy(collision.gameObject);

            }


        }


    }


    public void Damage(DetectionCollision objects)
    {
        _health--;
        if (_health <= 1)
        {
            Debug.Log($"Name {objects.Type} Death: {_health}");
            DieShip();
        }
    }

    public void DieShip()
    {
        Debug.Log($"Enemy ship Death");
        Destroy(_ship.gameObject);


    }

    public void Divide()
    {
        if (bulletDestroy)
        {
            var smolletBullet = _bulletEnemyPrefab.transform.localScale / 2;
            Instantiate(_bulletEnemyPrefab, _bulletEnemyPrefab.transform.position, transform.rotation);
        }
        else 
        {
            Destroy(gameObject, _timeToDestoy);
            bulletDestroy = true;
        }
    }

}
