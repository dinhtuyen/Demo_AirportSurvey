using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class SeccurityForm : MonoBehaviour, ITrackableEventHandler
{


    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowSecurityForm = false;
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
            mShowSecurityForm = true;
        }
        else
        {
            mShowSecurityForm = false;
        }
    }

    void OnGUI()
    {
        if (mShowSecurityForm)
        {
            GUI.Box(new Rect(0, 0, 400, 400), "Security Survey Form");
        }
    }


}