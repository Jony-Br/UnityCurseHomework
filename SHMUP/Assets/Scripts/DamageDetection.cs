using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{

    [SerializeField] private BulletBehaviour _bulletPrefab;
    

    //public bool takeDamage = false;

    private void Start()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"[{GetType().Name}][onColisionEnter2D] : {collision.gameObject.name}");
        //Ship _ship = collision.gameObject.GetComponent<Ship>();

        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {

            if (objects.Type == DetectCollisionType.Shield)
            {
                // Debug.Log($"[onTriggerEnter2D] : Wall : {objects.name}");
                Destroy(_bulletPrefab.gameObject);
                //_bulletPrefab.gameObject.SetActive(false);
            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"[{GetType().Name}][onTriggerEnter2D] : {collision.gameObject.name}");
        if (collision.gameObject.TryGetComponent<DetectionCollision>(out var objects))
        {

            if (objects.Type == DetectCollisionType.Shield)
            {
                // Debug.Log($"[onTriggerEnter2D] : Wall : {objects.name}");
                Destroy(_bulletPrefab.gameObject);
                //_bulletPrefab.gameObject.SetActive(false);
            }

            if (objects.Type == DetectCollisionType.Wall)
            {
                // Debug.Log($"[onTriggerEnter2D] : Wall : {objects.name}");
                //_bulletPrefab.gameObject.SetActive(false);

                Destroy(_bulletPrefab.gameObject);
            }



        }


    }



    public void DestroyObj(GameObject value)
    {
       Destroy(value);
    }

}
