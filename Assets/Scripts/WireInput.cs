using UnityEngine;
using Valve.VR.InteractionSystem;

public class WireInput : MonoBehaviour
{
    [SerializeField] private Transform ConnectedWirePos;
    [SerializeField] private bool IsTrueWireInput;

    private void Start()
    {
        GameObject.Find("Player").transform.SetParent(GameObject.Find("Directional Light").transform);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Wire"))
        {
            collider.gameObject.GetComponent<Interactable>().attachedToHand.DetachObject(collider.gameObject);
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            
        }
    }

    private void OnTriggerStay(Collider collider)
    {
       if(collider.gameObject.CompareTag("Wire"))
        {
            if (collider.gameObject.GetComponent<Interactable>().attachedToHand != null)
            {
                collider.gameObject.GetComponent<Interactable>().attachedToHand.DetachObject(collider.gameObject);
            }
        }
    }
}
