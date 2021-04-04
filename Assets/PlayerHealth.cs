using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int id = 0;
    int health = 100;
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
            name = "Ghost-"+id;
            if(go.name == name) {
                GameObject ghost = GameObject.Find(name);
                
            }
        }
    }
}
