using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiceBoardGame : MonoBehaviour
{

    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;
    public static int countSpace;

    public Text playerName;

    public Text score;

    public static int diceNumber = 0;
    public Button btn;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countSpace = 0;
        btn.gameObject.SetActive(false);
    
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))// && _player.played == false)
        {
            Launch();
            btn.gameObject.SetActive(true);
        }
        score.text = diceNumber.ToString();
    }

    void Launch()
    {
        countSpace++;
        diceNumber = 0;
        float dirX = Random.Range(500, 1000);
        float dirY = Random.Range(500, 1000);
        float dirZ = Random.Range(500, 1000);
        transform.position = new Vector3(2, 5, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(Random.onUnitSphere * forceAmount, forceMode);
        rb.AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
        rb.AddForce(transform.up * 100);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
