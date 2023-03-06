using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleObjectDebug : MonoBehaviour
{

    public bool _activeInHierarchy = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var type =  gameObject.AddComponent<Cloth> (); 
        Debug.Log($"Active In Hierarchy |{gameObject.activeInHierarchy}| Game Object {gameObject.name} ");
        Debug.Log($"Active Self |{gameObject.activeSelf}| Game Object {gameObject.name} ");
        Debug.Log($"Scene  |{gameObject.scene}| Game Object {gameObject.name} ");
        Debug.Log($"Scene Path |{gameObject.scene.path}| Game Object {gameObject.name} ");
        Debug.Log($"Scene Name |{gameObject.scene.name}| Game Object {gameObject.name} ");
        Debug.Log($"Layer |{gameObject.layer}| Game Object {gameObject.name} ");
        Debug.Log($"Tag |{gameObject.tag}| Game Object {gameObject.name} ");
        Debug.Log($"Transform |{gameObject.transform}| Game Object {gameObject.name} ");
        Debug.Log($"Transform |{gameObject.transform.name}| Game Object {gameObject.name} ");
        Debug.Log($"Transform |{gameObject.transform.position}| Game Object {gameObject.name} ");
        Debug.Log($"Transform |{gameObject.transform.rotation}| Game Object {gameObject.name} ");
        //Debug.Log($"AddComponent |{type}| Game Object {gameObject.name} " );
        Debug.Log($"GetCpmponent |{gameObject.GetComponent<Rigidbody>()}| Game Object {gameObject.name} ");
        Debug.Log($"CompareTag |{gameObject.CompareTag("Finish")}| Game Object {gameObject.name} ");




    }
}
