using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject[] bird;
    [SerializeField] float flyForce;

    // Start is called before the first frame update

    private void Awake()
    {
        Invoke("CreateBird", 0f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BirdFly();
    }

    void CreateBird()
    {
        int birdIndex = Random.Range(0, bird.Length);
        Instantiate(bird[birdIndex], bird[birdIndex].transform.position, bird[birdIndex].transform.rotation, this.transform);
    }

    void BirdFly()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            transform.Translate(Vector3.up * flyForce * Time.deltaTime);
        }
    }
}
