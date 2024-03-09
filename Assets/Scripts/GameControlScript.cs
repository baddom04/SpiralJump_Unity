using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public Transform player;
    public Transform column;
    public GameObject blackPlatform;
    public GameObject pinkPlatform;

    private int pinkChance = 25;
    private GameObject platform;
    private float offset = 0.35f;
    void Start()
    {
        for (int i = -3; i < 5; i++)
        {
            int platformCount = 0;
            if (Random.Range(0, 3) != 1)
            {
                randomPlatform();
                Instantiate(platform, 
                            column.transform.position + new Vector3(-offset, i*2f, offset),
                            Quaternion.Euler(-90, 0, 0),
                            column.transform);
                platformCount++;
            }
            if (Random.Range(0, 3) != 1)
            {
                randomPlatform();
                Instantiate(platform, 
                            column.transform.position + new Vector3(offset, i*2f, offset),
                            Quaternion.Euler(-90, 90, 0),
                            column.transform);
                platformCount++;
            }
            if (Random.Range(0, 3) != 1)
            {
                randomPlatform();
                Instantiate(platform, 
                            column.transform.position + new Vector3(offset, i*2f, -offset),
                            Quaternion.Euler(-90, 180, 0),
                            column.transform);
                platformCount++;
            }
            if(platformCount < 3){
                if (Random.Range(0, 3) != 1)
                {
                    randomPlatform();
                    Instantiate(platform, 
                                column.transform.position + new Vector3(-offset, i*2f, -offset),
                                Quaternion.Euler(-90, 270, 0),
                                column.transform);
                }
            }
        }
        pinkChance++;
    }
    private void randomPlatform()
    {
        if (Random.Range(0, 100) < pinkChance)
        {
            platform = pinkPlatform;
        }
        else
        {
            platform = blackPlatform;
        }
    }
    void Update()
    {

    }
}
