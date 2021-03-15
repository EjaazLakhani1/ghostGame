using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubePrefab;
    private GameObject playerObj;
    public Camera camera;
    void Start()
    {
        InvokeRepeating("MoveCube", 0.0f, 2.0f);

    }

    // Update is called once per frame

    int id = 0;
    void MoveCube() 
    {
        float rand = Random.Range(-5.0f, 5.0f);
        float pick = Random.Range(0,10.0f);
        Vector3 position;
        if (pick < 5.0f) {
            if (pick < 2.5f) {
                position = new Vector3(rand, 1.0f, 4.5f);
            }
            else {
                position = new Vector3(rand, 1.0f, -4.5f);
            }
        }
        else {
            if (pick < 7.5f) {
                position = new Vector3(4.5f, 1.0f, rand);
            }
            else {
                position = new Vector3(-4.5f, 1.0f, rand);
            }
        }
        Quaternion rotation = Quaternion.identity;
        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
        cube.name = "Cube-" + id;
        id++;        
    }

    void Update()
    {

    }
}
