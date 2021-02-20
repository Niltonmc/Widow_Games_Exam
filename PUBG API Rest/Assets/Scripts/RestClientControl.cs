using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestClientControl : MonoBehaviour{

    [System.Serializable]
    public struct TournamentDataContainerStruct{
        public TournamentDataStruct[] data;
    };

    [System.Serializable]
    public struct TournamentDataStruct{
        public string type;
        public string id;
       public DateStruct attributes;
    };

    [System.Serializable]
    public struct DateStruct{
        public string createdAt;
    };

    [Header("Tournament Data Structs Variables")]
    public TournamentDataContainerStruct tournamentsData;

    [Header("Tournament Container Variables")]
    public TournamentDataContainer tournamentDataContainer;

    // Start is called before the first frame update
    void Start(){
        SendAPIRequest();
    }

    public void SendAPIRequest(){
        StartCoroutine(APIRquestCoroutine("https://api.pubg.com/tournaments", 
        "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiIzYjA0MGQ1MC01NWRiLTAxMzktOTUyMS0wOTc4ZDBiMTk5YTEiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjEzODQ3Mzc0LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InVuaXR5LXJlc3QtYXBpIn0.1Vaq99MGPm3xwzBtnOwrEW9fS_feJRt37nBaJdkOnFA",
        "application/vnd.api+json"));
    }

    IEnumerator APIRquestCoroutine(string url, string apiKey, string acceptCondition){

        print("Start the API Request Coroutine");

        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        print("Setting autorization and accept conditions");

        webRequest.SetRequestHeader("Authorization","Bearer " + apiKey);
        webRequest.SetRequestHeader("Accept", acceptCondition);  

        yield return webRequest.SendWebRequest();

        if(!webRequest.isNetworkError && !webRequest.isHttpError){
            print("The API request was successful");
            tournamentsData = JsonUtility.FromJson<TournamentDataContainerStruct>(webRequest.downloadHandler.text);
            ShowData();
        }else{
            Debug.LogWarning("There was a problem getting the information!");
            Debug.Log(": Error: " + webRequest.error);
        }
    }

    void ShowData(){
        for(int i = 0; i < tournamentsData.data.Length; ++i){
            tournamentDataContainer.AddData(tournamentsData.data[i].id, tournamentsData.data[i].attributes.createdAt);
        }
    }
}