using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRb;

    public float point = 0f;

    public float flyForce = 10f;
    //public float gravity = -9.8f;
    public bool isDie;

    //private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        birdRb = GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveAnimator();
        if (!isDie)
        {
            BirdFly();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle")) 
        {
            isDie = true;
        }
    }

    void ActiveAnimator()
    {
        if (isDie)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    public void BirdFly()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            birdRb.AddForce(Vector3.up * flyForce, ForceMode2D.Impulse);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                birdRb.AddForce(Vector3.up * flyForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            point++;
            Debug.Log("Point " + point);
        }
    }

}
