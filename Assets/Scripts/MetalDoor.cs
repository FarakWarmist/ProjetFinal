using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDoor : MonoBehaviour, IInteractable
{
    public GameObject metalDoor;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorLock;
    public bool isLocked;
    private bool state = false;

    public void Interact()
    {
        MyPlayer myPlayer = FindAnyObjectByType<MyPlayer>();

        if (!state)
        {
            if (isLocked && FindAnyObjectByType<MyPlayer>().HasOldKey || !isLocked)
            {
                isLocked = false;
                state = true;
                metalDoor.GetComponent<Animator>().SetBool("Open", state);
                metalDoor.GetComponent<AudioSource>().clip = doorOpen;
                metalDoor.GetComponent<AudioSource>().Play();
                myPlayer.DestroyOldKey();

            }
            else
            {
                metalDoor.GetComponent<AudioSource>().clip = doorLock;
                metalDoor.GetComponent<AudioSource>().Play();
            }
        }
        else
        { 
            state = false; 
            metalDoor.GetComponent<Animator>().SetBool("Open", state) ;
            metalDoor.GetComponent<AudioSource>().clip = doorClose;
            metalDoor.GetComponent<AudioSource>().Play();
        }
    }
}
