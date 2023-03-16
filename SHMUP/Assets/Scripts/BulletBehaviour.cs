using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestoy;
   // [SerializeField] private float _damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _timeToDestoy);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
