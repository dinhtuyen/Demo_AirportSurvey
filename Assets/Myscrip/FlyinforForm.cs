using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class FlyinforForm : MonoBehaviour, ITrackableEventHandler
{


    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowFlyinforForm = false;
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
            mShowFlyinforForm = true;
        }
        else
        {
            mShowFlyinforForm = false;
        }
    }

    void OnGUI()
    {
        if (mShowFlyinforForm)
        {
            GUI.Box(new Rect(0, 0, 400, 400), "Fly information Survey Form");
        }
    }


}