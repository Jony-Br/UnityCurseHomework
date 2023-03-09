using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InputFieldS : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField input;
    public Text output;

    public void OnClick()
    {
        output.text = input.text;
    }
}
