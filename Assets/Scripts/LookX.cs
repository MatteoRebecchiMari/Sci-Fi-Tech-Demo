using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
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
        float mouseX = Input.GetAxis("Mouse X");

        // Local rotation
        Vector3 newRotation = transform.localEulerAngles;

        // We convet the X input to move RIGHT and LEFT (Y axes) the object
        newRotation.y += (mouseX * _sensitivity);

        transform.localEulerAngles = newRotation;

    }
}
