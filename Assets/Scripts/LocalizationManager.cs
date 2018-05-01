using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*Load all of the loclized text from 00.AC.StreamingAssets->JSON file
     * for deserialize it into a localization data object
     */
public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;
    
    
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

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();

        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            //Read all the JSON file
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            //Add all items key and value to the dictionnary
            for (int i = 0; i < loadedData.items.Length; i++) 
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
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