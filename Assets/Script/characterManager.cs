// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class characterManager : MonoBehaviour
// { 
//     Vector3 movementDirection;
//     [SerializeField] float speed;
//     Vector3 characterPosition;
//     int RoadIndex=0;
//     int RoadSpace=3;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         movementDirection = new Vector3(0, 0, 1);
//         transform.Translate(movementDirection * Time.deltaTime * speed);
//         characterPosition=this.transform.position;
//         if(Input.GetKeyDown(KeyCode.LeftArrow))
//         {
//             if(RoadIndex >-1)
//             RoadIndex--;
//         }
//                 if(Input.GetKeyDown(KeyCode.RightArrow))
//         {
//             if(RoadIndex <1)
//             RoadIndex++;
//         }
//        transform.position=new Vector3(RoadIndex * RoadSpace,characterPosition.y,characterPosition.z);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterManager : MonoBehaviour
{
    // Movement
    Vector3 movementDirection;
    [SerializeField] float speed = 5f;
    Vector3 characterPosition;
    int RoadIndex = 0;
    int RoadSpace = 3;

    // Jumping
    [SerializeField] float jumpForce = 5f; // How high the character will jump
    bool isGrounded; // To check if the character is on the ground
    float groundCheckDistance = 0.3f; // Distance to check if the character is grounded
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement (left-right)
        movementDirection = new Vector3(0, 0, 1);
        transform.Translate(movementDirection * Time.deltaTime * speed);

        characterPosition = this.transform.position;

        // Handling road shifting (left and right movement)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (RoadIndex > -1)
                RoadIndex--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (RoadIndex < 1)
                RoadIndex++;
        }

        // Update character's position based on RoadIndex
        transform.position = new Vector3(RoadIndex * RoadSpace, characterPosition.y, characterPosition.z);

        // Jump input detection and jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Check if the character is grounded (for jump)
        CheckGroundStatus();
    }

    // Function to handle jumping
    void Jump()
    {
        // Applying an upward force to make the character jump
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Ensure the y-velocity is reset before jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Function to check if the character is grounded
    void CheckGroundStatus()
    {
        // Check if the character is grounded by casting a ray downward
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // Debug line to visualize the ray
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);
    }
}

