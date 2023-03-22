using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject _shield;
    public bool _isActive = false;
    //[SerializeField] private int health = 3;
    public Transform _positionToApper;

    private void Start()
    {
        _shield.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _isActive == false)
        {
           _shield.gameObject.SetActive(true);
           _shield.gameObject.transform.position = _positionToApper.transform.position; 
    // StartCoroutine(SetActiveShield());
}
        else 
        {
           
            _shield.gameObject.SetActive(false);
        }
            
        
    }





}
