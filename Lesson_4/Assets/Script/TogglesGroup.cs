using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TogglesGroup : MonoBehaviour
{
    [SerializeField] private ToggleGroup _toggleGroup;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        Toggle active = _toggleGroup.GetFirstActiveToggle();
        Debug.Log("Toggle name: " + active.name);

    }


}
