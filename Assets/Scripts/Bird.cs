using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] AudioClip _dieSound;
    [SerializeField] AudioClip _hitSound;
    [SerializeField] AudioClip _pointSound;
    [SerializeField] AudioClip _wingSound;

    public int point { get; private set; }
    public bool _isStart { get; private set; }
    public bool isDie { get; private set; }

    private Rigidbody2D birdRb;
    private bool _playDieSound;
    
    public float flyForce = 10f;  

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

        if (!isDie)
        {
            BirdFly();
        }

        if (isDie && !_playDieSound)
        {
            AudioManager.Instance.PlaySound(_dieSound);
            _playDieSound = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle")) 
        {
            AudioManager.Instance.PlaySound(_hitSound);
            gameObject.GetComponent<Animator>().enabled = false;
            isDie = true;
        }
    }

    public void BirdFly()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            birdRb.AddForce(Vector3.up * flyForce, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySound(_wingSound);
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
            AudioManager.Instance.PlaySound(_pointSound);
            point++;            
            Debug.Log("Point " + point);
        }
    }
}
