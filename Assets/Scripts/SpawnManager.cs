using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject topPipe;
    [SerializeField] GameObject bottomPipe;
    [SerializeField] GameObject point;

    private float spawnX = 4f;
    private float delayTime = 1f;
    private float repeatTime = 3.5f;
    private float maxY = 7f;
    private float minxY = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPipe", delayTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnPipe()
    {
        float positionY = Random.Range(minxY, maxY);
        Vector2 spawnPos = new Vector2(spawnX, Random.Range(spawnX, positionY));
        Instantiate(topPipe, spawnPos, topPipe.transform.rotation);
        Instantiate(bottomPipe, spawnPos - new Vector2(0,7.5f), bottomPipe.transform.rotation);
        Instantiate(point, spawnPos - new Vector2(0,positionY), point.transform.rotation);
    }
}
