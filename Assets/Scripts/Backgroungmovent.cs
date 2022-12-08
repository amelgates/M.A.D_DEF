using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroungmovent : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlaying == true)
        {
            if (GameManager.instance.inOptions == false)
            {

                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            else if (!GameManager.instance.inOptions == false)
            {
                transform.Translate(Vector3.left * 0.0f * Time.deltaTime);
            }
        }
    }
}
