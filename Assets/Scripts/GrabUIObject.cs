using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabUIObject : MonoBehaviour
{
    [SerializeField]
    public GameObject prefabToSpawn;
    [SerializeField]
    private XRInteractionManager interactionManager;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = this.GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    public void OnButtonGrabbed(XRBaseInteractor interactor)
    {
        if (prefabToSpawn == null || interactor == null)
        {
            Debug.LogWarning("Missing prefab or interactor.");
            return;
        }

        // Instantiate the prefab at the interactor's (hand's) position and rotation
        GameObject spawned = Instantiate(prefabToSpawn, interactor.transform.position, interactor.transform.rotation);

        XRGrabInteractable grab = spawned.GetComponent<XRGrabInteractable>();
        if (grab == null)
        {
            Debug.LogWarning("Spawned prefab must have XRGrabInteractable.");
            return;
        }

        // Attach hand to object
        grab.attachTransform = interactor.transform;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector3 spawnPosition = this.gameObject.transform.position;
        Quaternion spawnRotation = this.gameObject.transform.rotation;


        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        interactionManager.SelectEnter(args.interactorObject, spawnedPrefab.GetComponent<IXRSelectInteractable>());
        Destroy(this.gameObject);

    }






}
