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
        //InvokeRepeating()
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("station1"))
        {
            GameObject mapa = Instantiate(station1, new Vector3(684.4f, 185.7f, -4.84f), Quaternion.identity);
        }
        if (other.CompareTag("Station2"))
        {
            GameObject mapa = Instantiate(station2, new Vector3(684.4f, 185.7f, -4.84f), Quaternion.identity);
        }
    }
}
