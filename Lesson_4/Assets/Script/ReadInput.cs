using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadInput : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TMP_InputField _inputField;

    public void SetName()
    {
        _name.text = _inputField.text;
    }
}
