using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer = 5f;
    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
