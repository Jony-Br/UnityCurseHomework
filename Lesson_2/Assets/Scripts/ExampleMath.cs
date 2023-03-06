using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExampleMath : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    [SerializeField] private Transform _taeget;
    [SerializeField] private float _duration;

    private float _timeCounter = 0;

    public Vector3 a;
    public Vector3 b;
    public int t;
    // Start is called before the first frame update
    void Start()
    {
        PrepareObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeCounter < _duration)
        {
            Interpolete();
            _timeCounter += Time.deltaTime;
        }
    }

    private void Interpolete()
    {
        var normalizedTime = _timeCounter / _duration;
        _taeget.position = Vector3.Lerp(_startPoint.position, _endPoint.position, normalizedTime);
    }
    [ContextMenu("Reset Target Object")] 
    private void PrepareObject()
    {
        _timeCounter = 0;
        _taeget.position = _startPoint.position;
    }    
}
