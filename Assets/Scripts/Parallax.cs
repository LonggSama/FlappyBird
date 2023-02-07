using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    MeshRenderer meshRenderer;

    [SerializeField] float _minAnimationSpeed;
    [SerializeField] float _boostSpeed;

    public float CurrentAnimationSpeed { get; set; }

    Bird bird;
    MoveLeft moveLeft;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(WaitBird());
    }

    private void Start()
    {
        CurrentAnimationSpeed = _minAnimationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (bird != null && !bird.isDie)
        {
            MoveLeft();
            ChangeAnimationSpeed();
        }
        if (bird.isDie)
        {
            CurrentAnimationSpeed = 0;
        }

    }

    void MoveLeft()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(CurrentAnimationSpeed * Time.deltaTime, 0);
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
    }

    void ChangeAnimationSpeed()
    {
        int wave = bird.point / 5;
        CurrentAnimationSpeed = _minAnimationSpeed + wave * _boostSpeed;
    }
}
