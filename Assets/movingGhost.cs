using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingGhost : MonoBehaviour
{
// Start is called before the first frame update
    public GameObject ghost;
    public Camera camera;
    int thisID;
    void Start()
    {
        name = "Ghost-"+GameManager.id;
        thisID = GameManager.id;
        GameManager.id += 1;
        ghost = GameObject.Find("Ghost-"+thisID);
    }

    
    // Update is called once per frame

    void Update()
    {   
        float step = 1.0f * Time.deltaTime;
        ghost.transform.position = Vector3.MoveTowards(ghost.transform.position, new Vector3(0.0f, 1.0f, 0.0f), step);

    }

    private void OnTriggerEnter(Collider other) {
        Destroy(ghost);
        GameManager.health -= 10;
        Debug.Log(GameManager.health);
    }
}

