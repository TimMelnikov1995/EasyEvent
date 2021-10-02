using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EasyApplicationFunctions : MonoBehaviour
{
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void quit()
    {
        Application.Quit();
    }
}