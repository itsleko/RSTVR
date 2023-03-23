using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireInput : MonoBehaviour
{
    [SerializeField] 
    private Transform ConnectedWirePos;

    private void OnTriggerStay(Collider colider)
    {
        if(colider.gameObject.CompareTag("Wire"))
        {
            colider.transform.position = ConnectedWirePos.position;
            colider.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
