using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWatch : MonoBehaviour
{
    public GameObject screen;
    public string npcTag = "Watch"; // Set this to the tag of your NPC

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(npcTag))
        {
            screen.SetActive(true);
        }
    }

}
