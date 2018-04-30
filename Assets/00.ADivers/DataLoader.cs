using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour {

	public string[] items;
    public Text txt;
    //string itemsDataString = "";

    IEnumerator Start(){
		WWW itemsData = new WWW("http://localhost:8080/SeriousGame/UserData.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split(';');
		txt.text = GetDataValue(items[0], "Name:");
	}

	string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}


}


























//void Start(){
//	string data = "ID:1|Name:Health Potion|Type:consumables|Cost:50";
//	print(GetDataValue(data, "Cost:"));
//}
//
//void Update(){
//	
//}
//
//string GetDataValue(string data ,string index){
//	string value = data.Substring(data.IndexOf(index)+index.Length);
//	if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
//	return value;
//}
