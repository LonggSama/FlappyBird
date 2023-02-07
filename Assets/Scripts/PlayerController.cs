using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject[] bird;
    [SerializeField] AudioClip _swooshSound;

    // Start is called before the first frame update

    private void Awake()
    {
        Invoke("CreateBird", 0f);
    }

    void CreateBird()
    {
        int birdIndex = Random.Range(0, bird.Length);
        Instantiate(bird[birdIndex], bird[birdIndex].transform.position, bird[birdIndex].transform.rotation, this.transform);
        AudioManager.Instance.PlaySound(_swooshSound);
    }
}
