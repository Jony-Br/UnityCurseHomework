using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _canShoot = false;
    [SerializeField] private float _timeToDestoy;
    [SerializeField] private BulletBehaviour _bulletEnemyPrefab;
    [SerializeField] private Transform _bulletEnemyStartPoint;

    public bool delay = false;
    //[SerializeField] private TypeShip _typeShip;
    //[SerializeField] private ShipAsigning _shipAsigning;

    //[SerializeField] private ScorePoint _scorePoint;
    //[SerializeField] private HealthPoint _healthPoint;
    //[SerializeField] private bool _hasBonus;


    void Start()
    {
        Destroy(gameObject, _timeToDestoy);
    }
    void Update()
    {
        MoveTarget();
       
        StartCoroutine(Shoot());
    }


    private void MoveTarget()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    IEnumerator Shoot()
    {
        if (_canShoot && delay == false) 
        {
            
            Instantiate(_bulletEnemyPrefab, _bulletEnemyStartPoint.position, transform.rotation);
            delay = true;
            yield return new WaitForSeconds(1f);
            delay = false;
        }
    }

}
