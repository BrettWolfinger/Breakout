using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    int numberOfBricks;
    public static Action AllBricksDestroyed = delegate { };
    void Awake() 
    {
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Count();
    }

    void OnEnable()
    {
        BrickCollision.BrickWasDestroyed += UpdateCount;
    }

    void OnDisable()
    {
        BrickCollision.BrickWasDestroyed -= UpdateCount;
    }

    void UpdateCount(int value)
    {
        numberOfBricks--;
        //end game
        if(numberOfBricks == 0)
        {
            AllBricksDestroyed.Invoke();
        }
    }
}
