using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    MeshRenderer meshRenderer;

    [SerializeField] float animationSpeed = 1f;

    Bird bird;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(WaitBird());
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }
    
    void MoveLeft()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
        if (bird.isDie)
        {
            animationSpeed = 0;
        }
    }

    IEnumerator WaitBird()
    {
        yield return new WaitForSeconds(0.001f);
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
    }

}
