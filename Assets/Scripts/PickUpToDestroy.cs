using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpToDestroy : MonoBehaviour, IInteractable
{
    public GameObject toDestroy;
    public void Interact()
    {
        Destroy(toDestroy);
        Destroy(gameObject);
    }
}
