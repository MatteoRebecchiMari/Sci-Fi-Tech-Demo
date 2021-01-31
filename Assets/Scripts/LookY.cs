using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    float _sensitivity = 1f;

    // Update is called once per frame
    void Update()
    {
        // Get the mouse x value
        float mouseY = Input.GetAxis("Mouse Y");

        // Local rotation
        Vector3 newRotation = transform.localEulerAngles;

        // We convert the Y input to move UP and DOWN (X axes) the object
        newRotation.x += (mouseY * _sensitivity * -1f);

        // Apply the rotation
        transform.localEulerAngles = newRotation;

    }
}
