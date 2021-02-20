using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TournamentData : MonoBehaviour{

    [Header("Tournament Data Variables")]
    private string tournamentID;
    private string dateCreated;

    [Header("Tournament Text Variables")]
    public Text textID;
    public Text textDate;

    public void SetInitialValues(string id, string date){
        tournamentID = id;
        dateCreated = date;
        textID.text = "ID: " + tournamentID;
        textDate.text = "Date: " + date;
        transform.localScale = new Vector3(1,1,1);
    }
}
