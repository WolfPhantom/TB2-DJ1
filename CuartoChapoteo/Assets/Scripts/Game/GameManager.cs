using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject platform;
    private float minX = -2.5f, maxX = 2.5f, minY = -4.7f, maxY = 4.7f;

    private bool lerpCamera;
    private float lerpTime = 1.5f;
    private float lerpX;

    void Awake()
    {
        MakeInstace();
        CreateInitialPlarform();
    }

    void MakeInstace()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void CreateInitialPlarform()
    {
        Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY, maxY), 0);
        Instantiate(platform, temp, Quaternion.identity);
        temp.y += 2f;
        Instantiate(player, temp, Quaternion.identity);
        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0);
        Instantiate(platform, temp, Quaternion.identity);
    }
}
