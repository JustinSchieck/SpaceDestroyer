using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{  
    public float SPEED = 20f;
    public float timer = 5f;

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, SPEED * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        timer -= Time.deltaTime;
         if(timer <= 0){
            UnityEngine.Object.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        UnityEngine.Object.Destroy(gameObject);
    }
}
