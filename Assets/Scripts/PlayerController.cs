using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 velocityZ;
    Vector3 velocityX;
    Vector3 velocity;
    [SerializeField] float moveSpeed;

    Vector3 rotVector;
    [SerializeField] float rotSpeed;

    Transform door;
    bool isTouchingDoor;
    bool isOpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();

        if (isTouchingDoor && Input.GetKeyDown(KeyCode.F))
            OpenDoor();
    }

    void Movement()
    {
        //velocityZ = Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //velocityX = Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //transform.Translate(velocityZ + velocityX);

        velocity = ((Vector3.forward * Input.GetAxisRaw("Vertical")
            + Vector3.right * Input.GetAxisRaw("Horizontal")).normalized
            * Time.deltaTime * moveSpeed);

        transform.Translate(velocity);
    }

    void Rotate()
    {
        rotVector = Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;
        transform.Rotate(rotVector);
    }

    void OpenDoor()
    {
        if (!isOpenDoor)
        {
            door.Rotate(0, 90, 0);
            isOpenDoor = true;
        }
        else
        {
            door.Rotate(0, -90, 0);
            isOpenDoor = false;
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Door")
    //    {
    //        isTouchingDoor = true;
    //        door = collision.transform.parent;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.name == "Door")
    //    {
    //        isTouchingDoor = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            isTouchingDoor = true;
            door = other.transform.GetChild(0);
        }

        if(other.gameObject.tag == "Coin")
        {
            print("BlingBling!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            isTouchingDoor = false;
        }
    }
}
