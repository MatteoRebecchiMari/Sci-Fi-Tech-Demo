using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if(_controller == null)
        {
            Debug.LogError("CharacterController not found!");
        }

        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        HandleShotWithRay();
        HandleMovements();
        HandleMouseCursorVisibility();
    }

    // Fixed update
    void FixedUpdate()
    {
        
    }

    [SerializeField]
    float _speed = 3.5f;

    [SerializeField]
    float _gravity = 9.81f;

    /// <summary>
    /// Handle player movementes
    /// </summary>
    void HandleMovements()
    {
        // Handle User Input
        // NOTE: GetAxis --> See Input Manager in Unity Editor
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Convert the input into motion DIRECTION
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);


        // Handle Gravity
        if (_controller.isGrounded == false)
        {
            direction.y -= _gravity;
        }

        // Convert the local player direction into a GLOBAL motion
        // (controller.Move() method handle ABSOLUTE movements (not relative to the gameobject))
        Vector3 worldSpaceDirection = transform.TransformDirection(direction);

        // Move the player
        _controller.Move(worldSpaceDirection * _speed * Time.deltaTime);

    }

    /// <summary>
    /// Toggle the mouse cursor visibility
    /// </summary>
    void HandleMouseCursorVisibility()
    {
        // When pressing ESC we toggle the mouse visibility
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    /// <summary>
    /// Handle ray cast shooting from the main camera to the forward position.
    /// </summary>
    void HandleShotWithRay()
    {

        // Left click mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // We cast a ray from the main camera to its forward position: CENTER OF THE SCREEN.
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                Debug.Log("We have hitten " + hit.collider.gameObject.name);
            }
        }        
    }

}
