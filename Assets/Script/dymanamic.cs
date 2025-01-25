using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dymanamic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Camera"))
        {
            transform.parent.transform.position += new Vector3(0, 0, 170);
        }

    }

}
