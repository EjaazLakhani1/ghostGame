using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseShoot : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {

    }
    int id = 0;
    // Update is called once per frame
    bool fired = false;
    void Update()
    {
        
        GameObject cam = GameObject.Find("AR Camera");
        Vector3 path = cam.transform.forward;
        foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
            name = "Sphere-" + id;
            //if(go.name == name) {
                GameObject bullet = GameObject.Find(name);
                bullet.transform.position += transform.forward * 0.002f;

                //bullet.transform.Translate(path * 0.02f);
        
            //}
        }
        id++;
    }
}
