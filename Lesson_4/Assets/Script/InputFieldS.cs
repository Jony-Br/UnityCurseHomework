using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InputFieldS : MonoBehaviour
{
    [SerializeField] private InputField _input;
    [SerializeField] private Button _button;
    [SerializeField] private Text _textChange;

   


    private void Start()
    {
        _input.GetComponent<InputField>();
        _textChange.GetComponent<Text>();
    }

    private void Update()
    {
        
        OnClick();

    }

    private void OnClick()
    {
        if (_button == true)
        {
            _input.text = _textChange.text;
        }
    }
}
