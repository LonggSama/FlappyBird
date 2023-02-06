using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float _minSpeed = 1f;
    [SerializeField] float _boostSpeed = 0.1f;
    static public int _pointPerWave { get; private set; } = 5;

    public float MaxSpeed = 2f;
    public float CurrentSpeed { get; set; }

    private float leftBounds = -4f;

    Bird bird;

    // Start is called before the first frame update
    void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
        StartCoroutine(WaitSpawnPoint());
    }

    private void Start()
    {
        CurrentSpeed = _minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.isDie)
        {
            Move();
        }

        if (CurrentSpeed < MaxSpeed)
        {
            ChangeMoveSpeed();
        }
    }

    void Move()
    {
        transform.Translate(Vector2.left * CurrentSpeed * Time.deltaTime);

        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }

    void ChangeMoveSpeed()
    {
        int wave = bird.point / _pointPerWave;
        CurrentSpeed = _minSpeed + wave * _boostSpeed;
    }

    IEnumerator WaitSpawnPoint()
    {
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("Bird"));
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
    }
}
