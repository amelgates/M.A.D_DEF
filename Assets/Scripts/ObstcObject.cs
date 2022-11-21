using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            GameManager.instance.NoteMissed();
            gameObject.SetActive(false);
        }
        if (other.tag == "Barrier")
        {
            gameObject.SetActive(false);
        }
    }
}
