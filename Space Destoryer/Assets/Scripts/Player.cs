using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{

    //player information
    public float playerHealth = 100;
    public float Lives;
    public float deathForce;


    //UI elements
    public int score;
    public Text scoreText;
    public Text livesText;

    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    public float maxVelocity = 20;
    public float rotationSpeed = 3;

    //shot information
    public GameObject Shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.5f;

    #region MonoBehavoir API
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;

        //initialize the text boxes
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + Lives;
    }

    private void Update()
    {
        //For Firing weapons
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
        }

        //For player movement
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        ThrustForward(yAxis);
        Rotate(transform, xAxis * -rotationSpeed);
    }



    #endregion


    #region Manuvering API
    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb2d.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb2d.velocity.y, -maxVelocity, maxVelocity);

        rb2d.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float speed)
    {
        Vector2 force = transform.up * speed * 10;
        rb2d.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    #endregion

    #region PlayerStatus API

    void ScorePoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > deathForce)
        {
            Lives--;
            livesText.text = "Lives: " + Lives;
            if (Lives >= 0)
            {
                //Gameover
            }
        }
    }
    #endregion
}
