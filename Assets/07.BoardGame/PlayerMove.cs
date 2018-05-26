using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    float rotSpeed = 5;
    float speed = 2.5f;
    bool moving = false;

    //This is Main Camera in the scene
    Camera mainCamera;
    //This is the second Camera and is assigned in inspector
    public Camera playerCamera;

    // Use this for initialization
    void Start()
    {
        //This gets the Main Camera from the scene
        mainCamera = Camera.main;
        //This enables Main Camera
        mainCamera.enabled = true;
        //Use this to disable secondary Camera
        playerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        if (moving)
        {
            Move();
            CameraAction();

        }
    }
    void SetTargetPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.gameObject.tag == "Case" && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
            {
                Debug.Log(" I hit tag : " + hit.collider.gameObject.tag);
                targetPosition = hit.point;
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                    transform.position.y,
                    targetPosition.z - transform.position.z);
                playerRot = Quaternion.LookRotation(lookAtTarget);
                moving = true;
            }
            else
            {
                return;
            }

        }
    }
    void Move()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                playerRot,
                                                rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,
                                                 targetPosition,
                                                 speed * Time.deltaTime);
        //stop moving if on target position
        if (transform.position == targetPosition)
        {
            moving = false;
        }
    }

    void CameraAction()
    {
        if (moving == true)
        {
            //Enable the second Camera
            playerCamera.enabled = true;

            //The Main first Camera is disabled
            mainCamera.enabled = false;
        }
        //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
        else if (moving == false)
        {
            //Disable the second camera
            playerCamera.enabled = false;

            //Enable the Main Camera
            mainCamera.enabled = true;
        }
    }
}
