using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCubes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    public Camera camera;
    void Start()
    {

    }

    int id = 0;
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
            name = "Cube-" + id;
            if(go.name == name) {
                GameObject cube0 = GameObject.Find(name);

                if (cube0.transform.position.z > 0.0f) {
                        cube0.transform.position += cube0.transform.forward * -0.02f; 
                }
                if (cube0.transform.position.z < 0.0f) {
                    cube0.transform.position += cube0.transform.forward * 0.02f; 
                }
                if (cube0.transform.position.x > 0.0f) {
                    cube0.transform.position += cube0.transform.right * -0.02f; 
                }
                if (cube0.transform.position.x < 0.0f) {
                    cube0.transform.position += cube0.transform.right * 0.02f; 
                }
            }
            id++;
        }
        
    }
}
