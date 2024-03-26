using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Keep track of all bricks so we know when they are all cleared to restart level
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

    //updates each time brick is destroyed
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
