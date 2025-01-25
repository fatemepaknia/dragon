using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    
    public GameObject mainCharacter;
    private Vector3 CameraPosition;
    private Vector3 CharacterPosition;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        CameraPosition=this.transform.position;
        CharacterPosition=mainCharacter.transform.position;
        distance=CharacterPosition-CameraPosition;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        CharacterPosition=mainCharacter.transform.position;
     CameraPosition=CharacterPosition-distance;
     this.transform.position=CameraPosition;
    }
}
