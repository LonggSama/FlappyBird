using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float animationSpeed = 1f;
    public GameObject bird;
    public Bird dieCheck;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        bird = GameObject.FindGameObjectWithTag("Bird");
        dieCheck = bird.GetComponent<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dieCheck.isDie)
        {
            meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
        }
        
    }
}
