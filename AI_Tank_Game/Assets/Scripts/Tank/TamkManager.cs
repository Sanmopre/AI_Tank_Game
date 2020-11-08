using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamkManager : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            blue.SetActive(true);
            blue.GetComponent<TankStats>().Reset();
            blue.GetComponent<Wandering>().Retarget();

            red.SetActive(true);
            red.GetComponent<TankStats>().Reset();
            red.GetComponent<Patroling>().NextCheckpoint();
        }
    }
}
