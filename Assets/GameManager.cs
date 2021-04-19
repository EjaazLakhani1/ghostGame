using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghostPrefab;
    public GameObject bulletPrefab;
    public GameObject shieldPrefab;
    public GameObject gunPrefab;

    public static int id = 1;
    public static int health = 100;
    public static int score = 0;
    public static int bulletId = 1;

    public Text healthText;
    public Text scoreText;
    public Text gameOverText;

    public Button shootButton;

    void Start()
    {
        InvokeRepeating("MoveGhost", 0.0f, 2.0f);

        healthText.GetComponent<UnityEngine.UI.Text>().text = "Health: " + health.ToString();
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();

        Button btn = shootButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        

        GameObject cam = GameObject.Find("AR Camera");
        Vector3 position = cam.transform.position;
        position.z = 0.15f;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(-90.0f, 0, 0);
        GameObject gun = Instantiate(gunPrefab, position, rotation);
        gun.transform.localScale = new Vector3(2f, 2f, 2f);
        gun.name = "Blaster";
        
    }

    

    // Update is called once per frame
    void MoveGhost() 
    {
        float rand = Random.Range(-5.0f, 5.0f);
        float pick = Random.Range(0,10.0f);
        float yLevel = Random.Range(0,3.0f);
        Vector3 position;
        if (pick < 5.0f) {
            if (pick < 2.5f) {
                position = new Vector3(rand, yLevel, 4.5f);
            }
            else {
                position = new Vector3(rand, yLevel, -4.5f);
            }
        }
        else {
            if (pick < 7.5f) {
                position = new Vector3(4.5f, yLevel, rand);
            }
            else {
                position = new Vector3(-4.5f, yLevel, rand);
            }
        }
        Quaternion rotation = Quaternion.identity;
        GameObject ghost = Instantiate(ghostPrefab, position, Quaternion.identity);
        ghost.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f); 
        ghost.transform.LookAt(new Vector3(0, 0.95f, 0));
          
    }
    
    int count = 0;
    int newCount = 0;

    void Update()
    {
            count++;
            newCount++;
            GameObject cam = GameObject.Find("AR Camera");

            healthText.text = "Health: " + health.ToString();
            scoreText.text = "Score: " + score.ToString();
            
            if (health <= 0) {
                gameOverText.GetComponent<UnityEngine.UI.Text>().text = "GAME OVER \n You Scored: " + score.ToString();
                Destroy(this);
            }
            
            if (newCount > 10) {
                newCount++;
                GameObject shooter = GameObject.Find("Blaster");
                shooter.transform.parent = cam.transform;
            }

    }

    void TaskOnClick() {
        if (count > 20) {
            count = 0;
            GameObject cam = GameObject.Find("AR Camera");
            Vector3 camPosition = cam.transform.position;
            Quaternion camRotation = cam.transform.rotation;
            GameObject sphere = Instantiate(bulletPrefab, camPosition, camRotation);
            sphere.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);
        }
    }
}
