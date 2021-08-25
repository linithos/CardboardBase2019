using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Google.XR.Cardboard;

public class CardboardSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (!Api.HasDeviceParams())
            Api.ScanDeviceParams();
    }

    // Update is called once per frame
    void Update()
    {
        if (Api.IsGearButtonPressed)
            Api.ScanDeviceParams();

        if (Api.IsCloseButtonPressed)
            Application.Quit();

        if (Api.HasNewDeviceParams())
            Api.ReloadDeviceParams();
    }
}
