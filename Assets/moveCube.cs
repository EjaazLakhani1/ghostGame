using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour
{
    //public GameObject cubePrefab;
    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");
        
        
    }
    // Update is called once per frame

   
    void Update()
    {
        //Debug.Log(cube.transform.position);
        if (cube.transform.position.z > 1.5f) {
            cube.transform.position += cube.transform.forward * -0.02f; 
        }
        
    }
}
