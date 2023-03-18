using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public float platformSpacing = 2.5f;
    private float nextPlatformY;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        nextPlatformY = platformSpacing;
        for (int i = 0; i < 1000; i++) SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlatform() {
        Instantiate(platform, new Vector3(Random.value * 10f - 5f, nextPlatformY, 0.5f), Quaternion.identity);
        nextPlatformY += platformSpacing;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}
