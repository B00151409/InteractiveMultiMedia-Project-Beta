using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Adjust the speed as needed
    public float moveDistance = 3f; // Adjust the move distance as needed
    private bool isMovingRight = true;
    private float distanceTraveled = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        float movement = speed * Time.deltaTime;

        if (isMovingRight)
        {
            transform.Translate(Vector3.back * movement);
        }
        else
        {
            transform.Translate(Vector3.forward * movement);
        }

        // Update the distance traveled
        distanceTraveled += Mathf.Abs(movement);

        // Check if the enemy has moved the desired distance, and if so, change direction
        if (distanceTraveled >= moveDistance)
        {
            isMovingRight = !isMovingRight;


            // Reset the distance traveled
            distanceTraveled = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = collision.GetContact(0);

            if (contact.normal.y < 0)
            {
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerDeath>().Die();
            }

        }
    }
}