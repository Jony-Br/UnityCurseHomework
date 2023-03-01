using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rb;
    public Vector3 Move;
    public float Horizontal ;
    public float Vertical ;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        
        Move = new Vector3(Horizontal, 0, Vertical);

        _rb.MovePosition(transform.position + Move * _speed * Time.deltaTime);
       
    }



 

}
