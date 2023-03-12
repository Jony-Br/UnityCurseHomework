
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TogglesGroup : MonoBehaviour
{
    //[SerializeField] private ToggleGroup _toggleGroup;

    // public Toggle togles;
    // Start is called before the first frame update
    [SerializeField] private Toggle[] _toggles ;

    void Start()
    {
        _toggles = GetComponentsInChildren<Toggle>();
        //Toggle simpleToggle;
        foreach (Toggle simpleToggle in _toggles)
        {
            simpleToggle.onValueChanged.AddListener(delegate { GetTogglesHandle(simpleToggle); });
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        /* Toggle active = _toggleGroup.GetFirstActiveToggle();
         Debug.Log("Toggle name: " + active.name);*/

    }
    

    private void GetTogglesHandle(Toggle t)
    {
        if (t.isOn)
        {
            Debug.Log($"Toggle Switch : {t.name}"); 
                                                  
        }
        
    }



}
