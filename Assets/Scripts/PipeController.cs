using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private float leftBounds = -4f;

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
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }
}
