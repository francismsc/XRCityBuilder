using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// <summary>
/// Transforms the UI images into 3D objects from prefabs
/// </summary>
public class OnRelease2Dto3D : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    private XRGrabInteractable grabInteractable;
    private XRInteractionManager interactionManager;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        interactionManager = FindFirstObjectByType<XRInteractionManager>();



    }

    private void Start()
    {
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Vector3 spawnPosition = this.gameObject.transform.position;
        Quaternion spawnRotation = this.gameObject.transform.rotation;

        // Instantiate the prefab at that position and rotation
        Instantiate(prefabToSpawn, args.interactorObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}
