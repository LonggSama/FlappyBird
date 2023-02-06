using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRb;

    public int point { get; private set; }
    public bool _isStart { get; private set; }
    public float flyForce = 10f;
    public bool isDie { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        birdRb = GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
        {
            StartGame();
        }

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

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        birdRb.AddForce(Vector3.up * flyForce, ForceMode2D.Impulse);
        //    }
        //}
    }

    void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            birdRb.bodyType = RigidbodyType2D.Dynamic;
            _isStart = true;
            isDie = false;
        }
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        birdRb.bodyType = RigidbodyType2D.Dynamic;
        //        _isStart = true;
        //        isDie = false;
        //    }
        //}
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
