using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float force = 200f;

    private Rigidbody rb;

    private float yMin = -3f, yMax = 3.3f;

    private Animation thisAnimation;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();

            rb.velocity = Vector3.zero;

            rb.AddForce(new Vector3(0, force, 0)); transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, yMin, yMax), 0);

            if (yMin >= -3.5f)
            {
                SceneManager.LoadScene("GameOver");
            }

            if (yMax >= 3f)
            {
                SceneManager.LoadScene("GameOver");
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
