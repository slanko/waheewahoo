using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    public static gameScript instance;
    private Vector3 startPos;
    GameObject scoreBoard;
    TextMesh scoreText;
    public float rScore, bScore;
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        startPos = transform.position;

        scoreBoard = GameObject.Find("ScoreText");

        scoreText = scoreBoard.GetComponent<TextMesh>();

        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            transform.position = startPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
            scoreText = scoreBoard.GetComponent<TextMesh>();
            scoreText.text = bScore.ToString() + " : " + rScore.ToString();

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "rGoal")
        {
            bScore++;
            scoreText.text = bScore.ToString() + " : " + rScore.ToString();
        }
        if(other.tag == "bGoal")
        {
            rScore++;
            scoreText.text = bScore.ToString() + " : " + rScore.ToString();
        }
    }
}
