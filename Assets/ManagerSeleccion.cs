using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ManagerSeleccion : MonoBehaviour
{
    public void Cargar1()
    {
        SceneManager.LoadScene("Cancion1");
    }

    public void Vicente()
    {
        DataManager.instance.Vicente();
    }

    public void Valeria()
    {
        DataManager.instance.Valeria();
    }

}
