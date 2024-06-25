using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    public Button myButton;

    public void Start()
    {
        myButton.onClick.AddListener(RestartScene);
    }

}
