using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour
{

    [SerializeField] private Transform _pointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(ray,out hit) )
        {
            _pointer.position = hit.point;

            if (hit.collider.gameObject.GetComponent<StartJoint>() && Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.GetComponent<StartJoint>().StartMetod() ;
                
            }
        }
    }
}
