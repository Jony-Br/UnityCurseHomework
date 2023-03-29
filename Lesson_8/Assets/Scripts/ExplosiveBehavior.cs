using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ExplosiveBehavior : MonoBehaviour
{


    [SerializeField] private TMP_Text _timerText;
    public float time = 3;
    private bool _timer = false;


    [SerializeField] private float _explosionForce = 400f;
    [SerializeField] private float _radius = 120f;

    [SerializeField] private Transform _explosionStartPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                _timerText.SetText(time.ToString("0"));
            }
            else
            {
                time = 0;
                _timer = false;
                Debug.Log($"Timmer {time}");
                StartExplotion();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log($"[{GetType().Name}][OnTriggerEnter] collided with : {collider.gameObject.name}");
        _timer = true;
    }

    public void StartExplotion()
    {
        var colliders = Physics.SphereCastAll(_explosionStartPoint.position, _radius, _explosionStartPoint.up);

        foreach (var collider in colliders) 
        {
            if(collider.collider.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, _explosionStartPoint.position, _radius);
            }
        }

    }
}
