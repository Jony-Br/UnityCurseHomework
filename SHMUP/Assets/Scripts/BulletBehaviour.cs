using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float _speed;
    public Vector3 direction;

    public float timeToDestoy;
    public float lifeTime;

    public Vector3 bulletPosition;

    void Start()
    {
  

    }


    void Update()
    {

    }

    private void FixedUpdate()
    {

        bulletPosition = direction * _speed * Time.fixedDeltaTime;
        transform.position += bulletPosition;

        timeToDestoy += Time.fixedDeltaTime;
        if(timeToDestoy > lifeTime) 
        {

            DeactivateGameObject();
          
        }

    }

    private void DeactivateGameObject()
    {
        //gameObject.SetActive(false);
         Destroy(gameObject);
         DontDestroyOnLoad(gameObject);
       

    }
}
