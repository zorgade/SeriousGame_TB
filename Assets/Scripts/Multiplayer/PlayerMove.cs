using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Prototype.NetworkLobby;

public class PlayerMove : NetworkBehaviour
{

    public static GameObject playerObject;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    private void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        playerObject = this.gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                //Player move to the score case
                if (hit.collider.gameObject.tag == "Case" && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
                {
                    StartCoroutine(SetTargetPosition(hit.point));
                }
                if (hit.collider.gameObject.tag == "Case" && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.black)
                {
                    StartCoroutine(SetTargetOldPosition(hit.point));
                }
            }
        }
    }

    IEnumerator SetTargetPosition(Vector3 position)
    {
        MoveToLocation(position);
        yield return new WaitForSeconds(2f);
        //Load quizz scene
        NetworkManager.singleton.ServerChangeScene("08A.Persistent");
    }

    IEnumerator SetTargetOldPosition(Vector3 position)
    {
        MoveToLocation(position);
        yield return new WaitForSeconds(2f);
    }

    public void MoveToLocation(Vector3 targetPoint)
    {
        playerObject.transform.position = targetPoint;
    }
}
