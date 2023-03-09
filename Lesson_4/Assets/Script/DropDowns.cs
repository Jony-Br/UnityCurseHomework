using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDowns : MonoBehaviour
{
  
    [SerializeField] private TMPro.TMP_Dropdown _dropDown;

    private List<TMPro.TMP_Dropdown.OptionData> _listDropDown;

    void Start()
    {
        _dropDown.onValueChanged.AddListener(valueChange);
        _listDropDown = _dropDown.options;
    }
    private void valueChange(int button)
    {

        Debug.Log($"[{GetType().Name}] [{gameObject.name}] panel: {_listDropDown[button].text}");
    }
}
