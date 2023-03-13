using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private bool _speedUP = false;


    public Vector2 move;

    public float horizontal;
    public float vertical;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        move = new Vector2(horizontal, vertical);

        _speedUP = Input.GetKey(KeyCode.LeftShift);

    }

    void FixedUpdate()
    {

        if (_speedUP == false)
        {
            //_rb.AddForce(move * _speed * Time.fixedDeltaTime);
            //_rb.MovePosition(move* _speed* Time.deltaTime);
            _rb.velocity = move * _speed * Time.deltaTime;
        }
        else
        {
            //_rb.AddForce(move * (_speed * 2) *Time.fixedDeltaTime);
            //_rb.MovePosition(transform.position + move * _speed * Time.deltaTime);
            _rb.velocity = move * (_speed * 2) * Time.deltaTime;

        }
    }

}


