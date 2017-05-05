using UnityEngine;
using System.Collections;
using Vuforia;
using System;
public class ConveyorForm : MonoBehaviour, ITrackableEventHandler

{


    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowConveyorForm = false;
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
            mShowConveyorForm = true;
        }
        else
        {
            mShowConveyorForm = false;
        }
    }

    void OnGUI()
    {
        if (mShowConveyorForm)
        {
            GUI.Box(new Rect(0, 0, 400, 400), "Convey Survey Form");
            GUI.Button(new Rect(20, 30, 100, 100), "Button 1");
        }
    }


}