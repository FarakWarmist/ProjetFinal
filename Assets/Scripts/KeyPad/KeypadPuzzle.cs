using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadPuzzle : MonoBehaviour
{
    public Light greenLight;
    public Light redLight;
    // int[] code = new[] { 2, 3, 4, 1};
    public int[] code;
    [SerializeField] GameObject door; 

    int currentIndex;
    private bool isFinished;

    internal void OnPress(int number)
    {
        
        redLight.enabled = false;

        if (isFinished)
            return;

        if (code[currentIndex] == number)
        {
            if (++currentIndex == code.Length)
            {
                isFinished = true;
                greenLight.enabled = true;
                door.GetComponent<MetalDoor>().isLocked = false;
            }
        }
        else
        {
            currentIndex = 0;
            redLight.enabled = true;
        }
    }
}
