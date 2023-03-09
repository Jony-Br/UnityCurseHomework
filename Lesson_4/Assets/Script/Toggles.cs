using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    [SerializeField] private Toggle _singleToggle;

    // Start is called before the first frame update
    void Start()
    {
        _singleToggle.onValueChanged.AddListener(OnToggleValueChangedHandle);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggleValueChangedHandle(bool isOn)
    {
        Debug.Log($"[{GetType().Name}][OnToggleValueChangedHandle] {gameObject.name}, bool {isOn}");

    }
}
