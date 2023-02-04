using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private float leftBounds = -4f;

    public bool _callSpawn { get; private set; }

    Bird bird;

    // Start is called before the first frame update
    void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.isDie)
        {
            MoveLeft();
        }
        ChangeMoveSpeed();
        Debug.Log("Pipe Controller Not Enter " + _callSpawn + " " + GetInstanceID());
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }

    void ChangeMoveSpeed()
    {
        if (speed < 2f)
        {
            int wave = bird.point / 1;
            for (int i = 0; i < wave; i++)
            {
                speed += 0.5f;
            }
        }
        else
            speed = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CallSpawn"))
        {
            _callSpawn = true;
            for (int i = 0;i < 10;i++)
            {
                Debug.Log("Pipe Controller Enter " + _callSpawn + " " + GetInstanceID());
            }
            
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("CallSpawn"))
    //    {
    //        _callSpawn = false;
    //        Debug.Log("Pipe Controller Exit " + _callSpawn);
    //    }
    //}
}
