using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ship : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    public int _health;


    [SerializeField] private BulletBehaviour _bulletPrefab;
    [SerializeField] private Transform _bulletStartPoint1;
    [SerializeField] private Transform _bulletStartPoint2;


    public bool delay = false;

    //Shield _shield;


    // Start is called before the first frame update
    void Start()
    {
      // _shield= GetComponent<Shield>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Space) != delay)
        {

            StartCoroutine(Fire(_bulletPrefab._speed, _bulletPrefab.direction, _bulletPrefab.lifeTime));
        }

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
                Destroy(collision.gameObject);



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
            if (objects.Type == DetectCollisionType.Enemy)
            {
                Damage(objects);
                Debug.Log($"Name {objects.Type} Helth: {_health}");



            }

            if (objects.Type == DetectCollisionType.EnemyBullet)
            {
                Damage(objects);
                Debug.Log($"Name {objects.Type} Collision on : {collision.gameObject}  Helth: {_health}");
                Destroy(collision.gameObject);


            }
            if (objects.Type == DetectCollisionType.Buster)
            {
                AddLife();

                Destroy(collision.gameObject);


            }
        }
    }

    public void AddLife()
    {
        if(_health <=3) 
        {
            _health++;
            WeveController.instance.PlusHealth();
        }


    }

    public void Damage(DetectionCollision objects)
    {
        _health--;
        WeveController.instance.MinusHealth();
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



    IEnumerator Fire(float speed, Vector3 direction, float lifeTime)
    {

        Instantiate(_bulletPrefab, _bulletStartPoint1.position, transform.rotation);
        Instantiate(_bulletPrefab, _bulletStartPoint2.position, transform.rotation);

        _bulletPrefab._speed = speed;
        _bulletPrefab.direction = direction;
        _bulletPrefab.lifeTime = lifeTime;
        delay = true;
        yield return new WaitForSeconds(0.15f);
        delay = false;
    }
}
