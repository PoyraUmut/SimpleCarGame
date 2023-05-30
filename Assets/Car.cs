using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]float steer_speed = 170;
    [SerializeField]float move_speed = 10;

    float boost_speed = 15;
    float low_speed = 5;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "boost"){
            move_speed = boost_speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
            move_speed = low_speed;
        }
                           
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical")* move_speed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal")* steer_speed * Time.deltaTime;

        transform.Translate(0,moveAmount,0);
        transform.Rotate(0,0,-steerAmount);
    }
}
