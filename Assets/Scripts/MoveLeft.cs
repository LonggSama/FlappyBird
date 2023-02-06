using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private float leftBounds = -4f;

    Bird bird;

    // Start is called before the first frame update
    void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
        StartCoroutine(WaitSpawnPoint());
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.isDie)
        {
            Move();
        }
        ChangeMoveSpeed();
    }

    void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }

    void ChangeMoveSpeed()
    {
        int wave = bird.point / 1;
        while (speed < 2)
        {
            speed += 0.1f;
        }
        
    }

    IEnumerator WaitSpawnPoint()
    {
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("Bird"));
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
    }
}
