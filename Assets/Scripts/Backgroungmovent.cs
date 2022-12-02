using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroungmovent : MonoBehaviour
{
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying == true)
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        else if (!GameManager.instance.isPlaying == true)
        {
            transform.Translate(Vector3.left * 0.0f * Time.deltaTime);
        }

    }
}
