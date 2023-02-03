using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private float leftBounds = -4f;

    public GameObject bird;
    public Bird dieCheck;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird");
        dieCheck = bird.GetComponent<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dieCheck.isDie)
        {
            moveLeft();
        }
        
    }

    public void moveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }
}
