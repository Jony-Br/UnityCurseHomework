using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    //[SerializeField] private bool _canShoot;
    [SerializeField] private float _timeToDestoy;

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
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

}
