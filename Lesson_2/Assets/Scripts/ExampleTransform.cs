using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTransform : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _gameObject;
    public Vector3 a;
    public Vector3 b;
    public Quaternion c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //_transform.position = a;
        a = transform.position;
        Debug.Log($"Position A {a}");
        b = transform.eulerAngles;
        Debug.Log($"Position A {b}");
        c = transform.rotation;
        Debug.Log($"Position A {b}");
        //gameObject.transform.Rotate(1, 1, 1);
       // gameObject.transform.Translate(0.001f, 0.001f, 0.001f);
        Debug.Log($"Index {gameObject.transform.GetSiblingIndex()}"); 
        transform.SetLocalPositionAndRotation(b,c);



    }
}
