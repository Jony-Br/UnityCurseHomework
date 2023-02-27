using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);

        rb.MovePosition(transform.position + move * _speed * Time.deltaTime);
        
       


        

    }



 

}
