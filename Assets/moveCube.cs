using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour
{

    
    // Start is called before the first frame update

    private void MoveOnZ(float amount) {
        transform.position += transform.forward * amount;
    }

    void Start()
    {
        MoveOnZ(5.0f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
