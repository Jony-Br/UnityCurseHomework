using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestoy;
    [SerializeField] private float _lifeTime;

    [SerializeField] private bool _canShoot = false;

    [SerializeField] private BulletBehaviour _bulletEnemyPrefab;
    [SerializeField] private BulletBehaviour _bulletEnemyPrefabSmoler;
    [SerializeField] private Transform _bulletEnemyStartPoint;

    [SerializeField] private GameObject _ship;
    [SerializeField] private EnemyShipType _typeShip;

    public int scorePoint;

    public GameObject _buster;
    public bool _hasBonus;

    private bool delay = false;

    BulletBehaviour bullet;
    Vector3 endPosition;

    Vector2 direction;
    //private bool bulletDestroy = false;




    void Start()
    {
        WeveController.instance.AddEnemy();
    }
    void Update()
    {
        MoveTarget();
        
        StartCoroutine(Shoot(_typeShip));

        TimeToDestroy();


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
                if (_ship != null)
                {
                    bullet = Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint.position, Quaternion.identity);
                    Invoke("DestroyerShoot", _bulletEnemyPrefab.lifeTime);
                }
                else { yield return null; }

                //Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint2.position, transform.rotation);
                delay = true;
                yield return new WaitForSeconds(2f);
                delay = false;
            }
            if (typeShip.Type == EnemyShipTypes.Himera)
            {
                Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint.position, transform.rotation);
                delay = true;
                yield return new WaitForSeconds(1f);
                delay = false;
            }
            if (typeShip.Type == EnemyShipTypes.Keeper)
            {
                Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint.position, transform.rotation);
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
        if (_hasBonus)
        {
           Instantiate(_buster.gameObject, _ship.gameObject.transform.position,Quaternion.identity);
            _buster.gameObject.transform.position = _ship.gameObject.transform.position;
//            _buster.gameObject.transform.position = _ship.gameObject.transform.position;
        }
        Destroy(_ship.gameObject);
        WeveController.instance.AddScore(scorePoint);


    }


    public void TimeToDestroy()
    {
        _timeToDestoy += Time.fixedDeltaTime;
        if (_timeToDestoy > _lifeTime)
        {
            Destroy(_ship.gameObject);
        }
    }
    public void DestroyerShoot()
    {
        if (bullet != null)
        {
            // Debug.Log($"Position bullet {_bulletEnemyPrefab.transform.position} and end bullet posiotion {bullet.transform.position}");
            _bulletEnemyPrefabSmoler._speed = 5;

            _bulletEnemyPrefabSmoler.direction = new Vector3(-1, 1, 1);
            Instantiate(_bulletEnemyPrefabSmoler.gameObject, bullet.transform.position, _bulletEnemyPrefabSmoler.transform.rotation);

            _bulletEnemyPrefabSmoler.direction = new Vector3(-1, 0, 0);
            Instantiate(_bulletEnemyPrefabSmoler.gameObject, bullet.transform.position, transform.rotation);

            _bulletEnemyPrefabSmoler.direction = new Vector3(-1, -1, -1);
            Instantiate(_bulletEnemyPrefabSmoler.gameObject, bullet.transform.position, transform.rotation);
        }
        _bulletEnemyPrefabSmoler.direction = new Vector3(-1, 0, 0);


    }

    public void OnDestroy()
    {
        WeveController.instance.RemoveEnemy();
    }

}
