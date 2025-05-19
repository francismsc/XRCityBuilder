using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
    
public class OnRelease2Dto3D : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private XRGrabInteractable grabInteractable;
    [SerializeField]
    private XRInteractionManager interactionManager;
    [SerializeField]
    private ParticleSystem transitionEffect;
    private void Awake()
    {
        grabInteractable = this.GetComponent<XRGrabInteractable>();
        interactionManager = GameObject.Find("XR Interaction Manager")?.GetComponent<XRInteractionManager>();

        grabInteractable.selectExited.AddListener(OnRelease);

    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Vector3 spawnPosition = this.gameObject.transform.position;
        Quaternion spawnRotation = this.gameObject.transform.rotation;

        // Instantiate the prefab at that position and rotation
        Instantiate(prefabToSpawn, args.interactorObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
        transitionEffect.Play();
    }
}
