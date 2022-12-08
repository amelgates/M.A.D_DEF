using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.x) > 1.75f)
                {
                    Debug.Log("Normal hit");
                    GameManager.instance.NormalHit();
                }
                else if(Mathf.Abs(transform.position.x) > 1.6f)
                {
                    Debug.Log("Good Hit");
                    GameManager.instance.GoodHit();
                }
                else
                {
                    Debug.Log("Perfect Hit");
                    GameManager.instance.PerfectHit();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
        if(other.tag == "Barrier")
        {
            GameManager.instance.NoteMissed();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            gameObject.SetActive(false);
            GameManager.instance.NoteMissed();
        }
    }
}
