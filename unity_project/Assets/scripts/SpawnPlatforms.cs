using UnityEngine;
using System.Collections;

public class SpawnPlatforms: MonoBehaviour
{

    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin;
    public float horizontalMax;
    public float verticalMin;
    public float verticalMax;
    private Vector2 originPosition;


    void Start()
    {
        originPosition = transform.position;
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}