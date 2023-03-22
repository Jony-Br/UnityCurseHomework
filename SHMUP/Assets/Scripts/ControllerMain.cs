using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerMain : MonoBehaviour
{


    [SerializeField] private Button _play;
    [SerializeField] private Button _option;



    void Start()
    {
        Button play = _play.GetComponent<Button>();
        Button option = _option.GetComponent<Button>();

        play.onClick.AddListener(OnPlayButtonClick);
        option.onClick.AddListener(OnOptionButtonClick);

    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadSceneAsync("Weve1");
    }

    private void OnOptionButtonClick()
    {
        SceneManager.LoadSceneAsync("Option");
    }

  
}
