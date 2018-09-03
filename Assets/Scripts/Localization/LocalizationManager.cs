using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

/*Load all of the loclized text from 00.AC.StreamingAssets->JSON file
     * for deserialize it into a localization data object
     */
public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;
    private string filePath;
    private string dataAsJson;

    /*Dictionary are strings and human readable, != Array (no index manage)
     */
    private Dictionary<string, string> localizedText;
    //Wait for the Localizationmanger is ready
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    void Awake()
    {
        //Use singleton pattern, keep only one instance! Or in the next scene, an another instance sill be loaded.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Keep access to the gameObject between scene
        DontDestroyOnLoad(gameObject);
    }

    public void LoadFile(string name)
    {
        //start coroutine with name of json file
        StartCoroutine(LoadLocalizedText(name));

    }
    IEnumerator LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log(filePath);

        //If StreamingAsset folder is on the Web download file
      //  if (filePath.Contains("://") || filePath.Contains(":///"))
        //{
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();
            dataAsJson = www.downloadHandler.text;
        /*
         // If StreamingAsset folder is on the Web download file
         //  if (filePath.Contains("://") || filePath.Contains(":///"))
         //{
         UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();
        //byte[] results = www.downloadHandler.data;
        //dataAsJson = System.Convert.ToBase64String(results);
        dataAsJson = Encoding.UTF8.GetString(www.downloadHandler.data);

        Debug.Log(dataAsJson);
        */
        // }
        //LocalPath
        /* else
         {
             dataAsJson = File.ReadAllText(filePath);

         }*/
        Debug.Log(dataAsJson);
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            //Add all items key and value to the dictionnary
            for (int i = 0; i < loadedData.items.Length; i++) 
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        
        //LocalizationManger is ready
        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }

    //Check if the Localizationmanager is ready
    public bool GetIsReady(){
        return isReady;
    }

}