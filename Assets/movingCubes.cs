using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCubes : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cube;
    void Start()
    {
        cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cube.transform.position.z > 0.0f) {
            cube.transform.position += cube.transform.forward * -0.02f; 
        }
        if (cube.transform.position.z < 0.0f) {
            cube.transform.position += cube.transform.forward * 0.02f; 
        }
        if (cube.transform.position.x > 0.0f) {
            cube.transform.position += cube.transform.right * -0.02f; 
        }
        if (cube.transform.position.x < 0.0f) {
            cube.transform.position += cube.transform.right * 0.02f; 
        }
        
    }
}
