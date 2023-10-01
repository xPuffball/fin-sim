using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public InputActionProperty showObjectAction;

    private bool isObjectShown = false; // To track the visibility state of the object
    public GameObject objectToShow;

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        objectToShow.SetActive(false); // Hide the object at the start
    }

    // Update is called once per frame
    void Update()
    {

        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);

        // Check for button press to show/hide the object
        if (showObjectAction.action.triggered)
        {
            ToggleObjectVisibility();
        }

    }

    private void ToggleObjectVisibility()
    {
        isObjectShown = !isObjectShown; // Toggle the state
        objectToShow.SetActive(isObjectShown); // Set the object's active state
    }
}
