using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private BulletBehaviour _bulletPrefab;
    [SerializeField] private Transform _bulletStartPoint1;
    [SerializeField] private Transform _bulletStartPoint2;

    public bool delay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Space) != delay)
        {

            StartCoroutine(Fire());
        }

    }

    IEnumerator Fire()
    {

        Instantiate(_bulletPrefab, _bulletStartPoint1.position, transform.rotation);
        Instantiate(_bulletPrefab, _bulletStartPoint2.position, transform.rotation);
        delay = true;
        yield return new WaitForSeconds(0.1f);
        delay = false;
    }

}
