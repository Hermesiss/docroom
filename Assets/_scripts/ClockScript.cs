using UnityEngine;
using System.Collections;
using System;


public class ClockScript : MonoBehaviour
{

    private GameObject HourObj;
    private GameObject MinObj;
    private GameObject SecObj;
    private int hourInt;
    private int minuteInt;
    private int secondInt;

    private DateTime moment;
    // Use this for initialization
    void Start()
    {
        HourObj = transform.Find("Subdivision_Surface/Null/hour").gameObject;
        MinObj = transform.Find("Subdivision_Surface/Null/minute").gameObject;
        SecObj = transform.Find("Subdivision_Surface/Null/second").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        TeaParty();
    }

    void TeaParty()
    {
        moment = System.DateTime.Now;
        hourInt = moment.Hour;
        minuteInt = moment.Minute;
        secondInt = moment.Second;
        HourObj.transform.localEulerAngles = new Vector3(0, 0, hourInt * 30);
        MinObj.transform.localEulerAngles = new Vector3(0, 0, minuteInt * 6);
        SecObj.transform.localEulerAngles = new Vector3(0, 0, secondInt * 6);

    }
}
