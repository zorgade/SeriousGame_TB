using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public static GameObject playerObject;

    // Use this for initialization
    private void Start()
    {
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
                if (hit.collider.gameObject.tag == "Case")// && hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.black)
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
        SceneManager.LoadScene("08A.Persistent", LoadSceneMode.Additive);
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