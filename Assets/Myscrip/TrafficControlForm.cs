using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class TrafficControlForm : MonoBehaviour, ITrackableEventHandler
{


    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowTrafficControlForm = false;
    private Rect mButtonRect = new Rect(50, 50, 120, 60);

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowTrafficControlForm = true;
        }
        else
        {
            mShowTrafficControlForm = false;
        }
    }

    void OnGUI()
    {
        if (mShowTrafficControlForm)
        {
            GUI.Box(new Rect(0, 0, 400, 400), "TrafficControl Survey Form");
        }
    }


}