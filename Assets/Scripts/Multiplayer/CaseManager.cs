using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    private static bool created = false;
    public GameObject go;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(go);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
       /* else
        {
            Destroy(this.gameObject);
        }*/
    }
}
