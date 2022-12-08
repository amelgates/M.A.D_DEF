using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEscenas : MonoBehaviour
{
    public void Escena1()
    {
        SceneManager.LoadScene("Cancion1");
    }
    public void Escena2()
    {
        SceneManager.LoadScene("Cancion2");
    }
    public void Escena3()
    {
        SceneManager.LoadScene("Cancion3");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Estacion1()
    {
        SceneManager.LoadScene("Estacion1");
    }
    public void Estacion2()
    {
        SceneManager.LoadScene("Estacion2");
    }
    public void Final1()
    {
        SceneManager.LoadScene("Final1");
    }
    public void Final2()
    {
        SceneManager.LoadScene("Final2");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void SelecPj()
    {
        SceneManager.LoadScene("SelecPj");
    }
}
