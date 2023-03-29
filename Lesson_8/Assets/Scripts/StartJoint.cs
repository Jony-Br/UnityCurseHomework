using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class StartJoint : MonoBehaviour
{
    [SerializeField] private Joint _rope;
    [SerializeField] private GameObject _sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
    public void StartMetod()
    {
        _rope.gameObject.SetActive(true);
        _sphere.gameObject.SetActive(true);
    }

}
