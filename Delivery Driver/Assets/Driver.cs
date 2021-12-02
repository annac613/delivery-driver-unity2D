using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    bool collided;
    bool spedUp;
    float speedChangeDelay = 0f;
    // float destroyDelay = 0.05f;
    float delay = 100f;
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        collided = true;
        speedChangeDelay = 0;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "SpeedUp")
        {
            spedUp = true;
            speedChangeDelay = 0;
            // Destroy(other.gameObject, destroyDelay);
        }
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if(collided)
        {
            if(speedChangeDelay <= delay)
            {
                moveAmount = Input.GetAxis("Vertical") * slowSpeed * Time.deltaTime;
                speedChangeDelay++;
            }
            else
            {
                collided = false;
            }
        }
        else if(spedUp)
        {
            if(speedChangeDelay <= delay)
            {
                moveAmount = Input.GetAxis("Vertical") * boostSpeed * Time.deltaTime;
                speedChangeDelay++; 
            }
            else
            {
                spedUp = false;
            }
        }
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
