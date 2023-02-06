using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject topPipe;
    [SerializeField] GameObject bottomPipe;
    [SerializeField] GameObject point;
    [SerializeField] Vector2 _space = new Vector2(0, 8.5f);

    private float spawnX = 4f;
    //private float delayTime = 0;
    //private float repeatTime = 3.5f;
    private float maxY = 7f;
    private float minxY = 2.5f;

    public bool _wait { get; set; }

    Bird bird;
    CallSpawn callSpawn;

    // Start is called before the first frame update

    private void Awake()
    {
        callSpawn = GameObject.Find("CallSpawn").GetComponent<CallSpawn>();
        StartCoroutine(WaitBird());
    }


    void Update()
    {
        if (callSpawn != null)
        {
            if (callSpawn._callSpawn && !_wait)
            {
                SpawnPipe();
                _wait = true;
            }
        }

    }

    void SpawnPipe()
    {
        if (!bird.isDie && bird._isStart)
        {
            float positionY = Random.Range(minxY, maxY);
            Vector2 spawnPos = new Vector2(spawnX, Random.Range(spawnX, positionY));
            Instantiate(topPipe, spawnPos, topPipe.transform.rotation);
            Instantiate(bottomPipe, spawnPos - _space, bottomPipe.transform.rotation);
            Instantiate(point, new Vector2(spawnX,0), point.transform.rotation);
        }
    }

    IEnumerator WaitBird()
    {
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("Bird"));

        //while (bird == null)
        //{
        //    bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
        //    yield return null;
        //}
        //yield return new WaitForSeconds(0.001f);
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
        StartCoroutine(WaitGameStart());
    }

    IEnumerator WaitGameStart()
    {
        yield return new WaitUntil(() => bird._isStart);
        SpawnPipe();
    }
}
