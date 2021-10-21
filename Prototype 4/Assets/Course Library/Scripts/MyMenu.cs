using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMenu : MonoBehaviour
{
    // Navigational Function
    public void GoToFunction()
    {
        if (gameObject.tag == "Menu")
        {
        SceneManager.LoadScene(0);
        }
        else if (gameObject.tag == "Prototype")
        {
        SceneManager.LoadScene(1);
        }
        else if (gameObject.tag == "Challenge")
        {
        SceneManager.LoadScene(2);
        }
        else if (gameObject.tag == "Source")
        {
        Application.OpenURL("");
        }
    }
}
