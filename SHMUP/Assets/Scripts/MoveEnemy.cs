using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _position;
    [SerializeField] private bool _isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isMoving == true)
        {
            
        }
        else 
        {
            _isMoving = true;
            StartCoroutine(Move());
            
        }
        
    }



    IEnumerator Move()
    {

        Instantiate(_enemyPrefab, gameObject.transform.position, transform.rotation);
        
        yield return null;

    }
}
