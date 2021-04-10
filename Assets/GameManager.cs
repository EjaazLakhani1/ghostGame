using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghostPrefab;
    public GameObject bulletPrefab;
    public GameObject shieldPrefab;
    public static int id = 1;
    public static int health = 100;
    public static int score = 0;
    public static int bulletId = 1;
    public Text healthText;
    public Text scoreText;
    public TextAnchor alignment;

    void Start()
    {
        InvokeRepeating("MoveGhost", 0.0f, 2.0f);
        healthText.GetComponent<UnityEngine.UI.Text>().text = "Health: " + health.ToString();
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void MoveGhost() 
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
        GameObject ghost = Instantiate(ghostPrefab, position, Quaternion.identity);
        ghost.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f); 
        ghost.transform.LookAt(new Vector3(0, 0.95f, 0));
          
    }
    int count = 0;
    
    void Update()
    {
        //if (Input.touchCount > 0) {
            //Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Began) {
            count++;
            if (Input.GetMouseButton(0) && count > 10) {
                count = 0;
                GameObject cam = GameObject.Find("AR Camera");
                Vector3 camPosition = cam.transform.position;
                Quaternion camRotation = cam.transform.rotation;
                GameObject sphere = Instantiate(bulletPrefab, camPosition, camRotation);
                sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }

            healthText.text = "Health: " + health.ToString();
            scoreText.text = "Score: " + score.ToString();
        //}

    }
}
