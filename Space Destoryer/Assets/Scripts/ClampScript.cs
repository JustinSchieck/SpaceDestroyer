using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScript : MonoBehaviour
{
    private float clampY = 17f;
    private float clampX = 20f;
    
    // Update is called once per frame
    void Update()
    {

    if (transform.position.x < -clampX || transform.position.x > clampX)
    {
      float xPosition = Mathf.Clamp(transform.position.x, clampX, -clampX);
      transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    if (transform.position.y < -clampY || transform.position.y > clampY)
        {
        float yPosition = Mathf.Clamp(transform.position.y, clampY, -clampY);
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        }
    }
}
