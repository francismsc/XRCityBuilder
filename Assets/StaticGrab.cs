using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class StaticGrab : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Rola");
        // Prevent actual movement
        trackPosition = false;
        trackRotation = false;

        base.OnSelectEntered(args);
    }
}
