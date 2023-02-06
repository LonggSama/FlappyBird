using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSpawn : MonoBehaviour
{
    public bool _callSpawn { get; set; }

    SpawnManager spawnManager;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _callSpawn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            spawnManager._wait = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _callSpawn = false;
        }
    }
}
