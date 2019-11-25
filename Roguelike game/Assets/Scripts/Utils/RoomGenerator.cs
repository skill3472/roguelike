﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject topWall;
    public GameObject rightWall;
    public GameObject bottomWall;
    public GameObject leftWall;
    public int[] possibleRooms = new int[8];
    public GameObject[] currentRooms = new GameObject[8];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; possibleRooms.Length > i ; i++)
        {
            possibleRooms[i] = Random.Range(0, 2);
        }

        for (int i = 0; possibleRooms.Length > i; i++)
        {
            currentRooms[i] = new GameObject("room " + i);
            if (i == 4)
            {
                Instantiate(topWall, currentRooms[i].transform);
                Instantiate(rightWall, currentRooms[i].transform);
                Instantiate(bottomWall, currentRooms[i].transform);
                Instantiate(leftWall, currentRooms[i].transform);
            }
             else if (i == 1 || i == 3 || i == 5 || i == 7)
            {
                if (possibleRooms[i] != 1)
                {
                    continue;
                }
            }
            else
            {
                if (i == 0 && (possibleRooms[1] + possibleRooms[3] == 0))
                {
                    continue;
                }
                if (i == 2 && (possibleRooms[1] + possibleRooms[5] == 0))
                {
                    continue;
                }
                if (i == 6 && (possibleRooms[3] + possibleRooms[7] == 0))
                {
                    continue;
                }
                if (i == 8 && (possibleRooms[5] + possibleRooms[7] == 0))
                {
                    continue;
                }
            }

            currentRooms[i].transform.parent = this.transform;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}