using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Menu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Dict ()
    {
        SceneManager.LoadScene("Dictionary");
    }

    public void Play ()
    {
        SceneManager.LoadScene("Practice");
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
