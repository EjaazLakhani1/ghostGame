using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shield;
    public GameObject ghost;
    public float radius = 15.0f;
    int thisID;
    // Start is called before the first frame update
    void Start()
    {
        name = "Bullet-"+GameManager.bulletId;
        thisID = GameManager.bulletId;
        GameManager.bulletId += 1;
        bullet = GameObject.Find("Bullet-"+thisID);
        shield = GameObject.Find("Cylinder");
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),shield.GetComponent<Collider>(),true);


    }
    // Update is called once per frame

    void Update()
    {
        GameObject cam = GameObject.Find("AR Camera");
        Vector3 path = cam.transform.forward;
        float step = 10.0f * Time.deltaTime;
        bullet.transform.position += transform.forward * step;
        float distance = Vector3.Distance(shield.transform.position,bullet.transform.position);
        if (distance >= radius) {
            Destroy(bullet);
        }

        if (GameManager.health <= 0) {
                Destroy(this);
                
        }
    }
    private void OnTriggerEnter(Collider other) {
            string ghostName = "Ghost-"+GameManager.id;
            Destroy(bullet);
            GameManager.score += 10;
            Debug.Log("test");
    }
}
