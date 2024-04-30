using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        // in loadScene, enter the name of the scene in paranethese ("level 1") 
        SceneManager.LoadScene("BasicScene");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
