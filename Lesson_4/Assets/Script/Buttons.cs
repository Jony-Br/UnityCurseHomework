using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    [SerializeField] private Button _acceptButton;
    // Start is called before the first frame update
    void Start()
    {
        _acceptButton.onClick.AddListener(OnCloseButtonHandle);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCloseButtonHandle()
    {
        Debug.Log($"[{GetType().Name}][OnCloseButtonHandle] OK {_acceptButton.name}");
        

    }
}
