using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxThrust;
    public float maxSpin;
    public float health;
    public int asteroidSize;  //3 = large 2 = med 1 = small
    public GameObject asteroidMed;
    public GameObject asteroidSmall;
    public int points;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Add a random spin and speed to a spawned asteroid
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxSpin, maxSpin);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        //finds for player object as these are spawned in not made only once
        player = GameObject.FindWithTag("Player");

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // int i = 0;
        //check to see if bullet hit
        if (other.CompareTag("bullet"))
        {
            //destory bullet
            Destroy(other.gameObject);

            if (asteroidSize == 3)//spawn 2 medium
            {
                Instantiate(asteroidMed, transform.position, transform.rotation);
                Instantiate(asteroidMed, transform.position, transform.rotation);

            }
            else if (asteroidSize == 2) //spawn 2 small
            {
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);

            }
            //Tell the player to score points
            player.SendMessage("ScorePoints", points);
            //remove the asteroid that was destoryed
            Destroy(gameObject);
        }

    }
}
