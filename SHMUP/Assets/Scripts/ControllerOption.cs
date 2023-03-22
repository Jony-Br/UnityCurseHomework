using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerOption : MonoBehaviour
{

    [SerializeField] private Button _exit;


    void Start()
    {

        Button exit = _exit.GetComponent<Button>();

        exit.onClick.AddListener(OnExitButtonClick);
    }



    private void OnExitButtonClick()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
