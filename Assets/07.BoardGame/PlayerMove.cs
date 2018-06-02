using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    float rotSpeed = 5;
    float speed = 3f;
    bool moving = false;
    NavMeshAgent agent;
    //This is Main Camera in the scene
    Camera mainCamera;
    //This is the second Camera and is assigned in inspector
    public Camera playerCamera;
    public static GameObject playerObject;
    public static Vector3 playerPos = new Vector3(3, 2, 3);

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

    }
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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

        playerObject.gameObject.transform.position = playerPos;

        CameraAction();

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(SetTargetPosition());


        }

        if (!agent.pathPending && !agent.hasPath)
        {
            //CameraAction();
            moving = false;
        }


    }

    IEnumerator SetTargetPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            moving = true;

            //Player move to the score case
            if (hit.collider.gameObject.tag == "Case" && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
            {
                agent.destination = hit.point;
                playerPos = hit.transform.position;

                Debug.Log(agent.destination);
                yield return new WaitForSeconds(2f);
                moving = false;
                SceneManager.LoadScene("08A.Persistent");


            }
            //If answer is wrong, player must return to the old case
            else if (hit.collider.gameObject.tag == "Case" && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.black)
            {
                moving = true;
                agent.destination = hit.transform.position;
                playerPos = agent.destination;

                Debug.Log(agent.destination);

                yield return new WaitForSeconds(2f);
                moving = false;

            }

            else
            {
                yield return null;
            }
        }
    }

    void CameraAction()
    {
        //When player move
        if (moving == true)
        {
            //Enable the second Camera
            playerCamera.enabled = true;

            //The Main first Camera is disabled
            mainCamera.enabled = false;
        }
        //When player don't move
        else if (moving == false)
        {

            //Disable the second camera
            playerCamera.enabled = false;

            //Enable the Main Camera
            mainCamera.enabled = true;
        }
    }
}
