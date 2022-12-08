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
    public Animator animator;
    public Sprite arriba, abajo, medio;
    public SpriteRenderer indicador;

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
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Punch", true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                estado++;
                animator.SetBool("MoverArriba", true);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                estado--;
                animator.SetBool("MoverAbajo", true);
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
                    indicador.sprite = abajo;
                    break;
                case 2:
                    playerTransform.position = estado2;
                    indicador.sprite = medio;
                    break;
                case 3:
                    playerTransform.position = estado3;
                    indicador.sprite = arriba;
                    break;
            }
        }
        
    }
}
