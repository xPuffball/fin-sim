using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    public GameObject objectToShow; // Drag the object you want to show here in the inspector
    public string npcTag = "NPC"; // Set this to the tag of your NPC

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag(npcTag))
        {
            objectToShow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(npcTag))
        {
            objectToShow.SetActive(false);
        }
    }

}
