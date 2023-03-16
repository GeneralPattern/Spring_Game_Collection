using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
