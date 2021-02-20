using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentDataContainer : MonoBehaviour{

    [Header("Tournament List Variables")]
    public List<TournamentData> listTournamentData;

    [Header("Tournament Prefab Variables")]
    public GameObject objTournamentData;

    [Header("Tournament Content Variables")]
    public Transform contentTransform;

    public void AddData(string id, string date){
        GameObject tmp = Instantiate(objTournamentData, transform.position, transform.rotation);
        tmp.transform.SetParent(contentTransform);
        tmp.GetComponent<TournamentData>().SetInitialValues(id, date);
    }
}
