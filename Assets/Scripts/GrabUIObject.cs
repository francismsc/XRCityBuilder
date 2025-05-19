using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabUIObject : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private XRGrabInteractable grabInteractable;
    [SerializeField]
    private XRInteractionManager interactionManager;

    private void Awake()
    {
        grabInteractable = this.GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);

    }

    public void OnButtonGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Missing prefab or interac.");
        if (prefabToSpawn == null || interactor == null)
        {
            Debug.LogWarning("Missing prefab or interactor.");
            return;
        }

        // Instantiate the prefab at the interactor's (hand's) position and rotation
        GameObject spawned = Instantiate(prefabToSpawn, interactor.transform.position, interactor.transform.rotation);

        // Get the XRGrabInteractable component
        XRGrabInteractable grab = spawned.GetComponent<XRGrabInteractable>();
        if (grab == null)
        {
            Debug.LogWarning("Spawned prefab must have XRGrabInteractable.");
            return;
        }

        // Let the hand grab the new object
        grab.attachTransform = interactor.transform;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        // Get the world position of the UI element

        Vector3 spawnPosition = this.gameObject.transform.position;
        Quaternion spawnRotation = this.gameObject.transform.rotation;

        // Instantiate the prefab at that position and rotation
        Instantiate(prefabToSpawn, args.interactorObject.transform.position, this.gameObject.transform.rotation);
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        interactionManager.SelectEnter(args.interactorObject, spawnedPrefab.GetComponent<IXRSelectInteractable>());
        Destroy(this.gameObject);

    }






}
