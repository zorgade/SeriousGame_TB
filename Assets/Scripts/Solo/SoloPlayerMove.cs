using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SoloPlayerMove : MonoBehaviour
{
    Vector3 destination;
    public static GameObject playerObject;
    public static Vector3 playerPos = new Vector3(3,0,3);

    private void Awake()
    {
        //playerPos = new Vector3(3,0,3);
        //playerObject = GameObject.FindGameObjectWithTag("Player");

    }
    // Use this for initialization
    private void Start()
    {
        playerObject = this.gameObject; // GameObject.FindGameObjectWithTag("Player");
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
                    //playerObject.gameObject.transform.position = playerPos;

                    StartCoroutine(SetTargetPosition(hit.point));
                }
                if (hit.collider.gameObject.tag == "Case" && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.black)
                {
                    //playerObject.gameObject.transform.position = playerPos;

                    StartCoroutine(SetTargetOldPosition(hit.point));
                }
            }

        }
        playerObject.gameObject.transform.position = playerPos;

    }

    IEnumerator SetTargetPosition(Vector3 position)
    {
        MoveToLocation(position);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("08A.Persistent", LoadSceneMode.Additive);
    }
    IEnumerator SetTargetOldPosition(Vector3 position)
    {
        MoveToLocation(position);
        yield return new WaitForSeconds(2f);
    }
    public void MoveToLocation(Vector3 targetPoint)
    {
        playerPos = targetPoint;
    }
}