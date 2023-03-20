using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _spawnRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, _startPosition.position, _enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(_spawnRate);

        }
    }
}
