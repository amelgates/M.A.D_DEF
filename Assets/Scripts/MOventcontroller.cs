using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOventcontroller : MonoBehaviour
{
    public GameObject station1;
    public GameObject station2;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("station1"))
        {
            station1.transform.position = spawn.transform.position;
        }
        if (other.CompareTag("Station2"))
        {
            station2.transform.position = spawn.transform.position;
        }

    }
}
