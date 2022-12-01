using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menudeinicio : MonoBehaviour
{
     public void StartGame()
    {
        SceneManager.LoadScene("Cancion1");
    }
     public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void CreditsGame()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void BackGame()
    {
        SceneManager.LoadScene("Inicio");
    }
}
