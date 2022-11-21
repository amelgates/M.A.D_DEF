using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    public int estado;
    public Vector3 estado1;
    public Vector3 estado2;
    public Vector3 estado3;
    public Transform playerTransform;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        playerTransform = gameObject.transform;
        estado = 2;
        playerTransform.position = estado2;
    }
    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                estado++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                estado--;
            }
            if (estado < 1)
            {
                estado = 1;
            }
            if (estado > 3)
            {
                estado = 3;
            }
            switch (estado)
            {
                case 1:
                    playerTransform.position = estado1;
                    break;
                case 2:
                    playerTransform.position = estado2;
                    break;
                case 3:
                    playerTransform.position = estado3;
                    break;
            }
        }
        
    }
}
