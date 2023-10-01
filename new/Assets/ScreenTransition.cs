using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject nextScreen;
    

    public void SwitchScreen()
    {
        currentScreen.SetActive(false);
        nextScreen.SetActive(true);
    }
}
