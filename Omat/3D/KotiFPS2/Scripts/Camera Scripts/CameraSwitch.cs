using UnityEngine;
//using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    //[SerializeField]
    //private CinemachineVirtualCamera fpsCam;
    //[SerializeField]
    //private CinemachineFreeLook tpsCam;
    public bool camSwitch;
    private FPSCameraMover fpscam;

    private void Start()
    {
        fpscam = GetComponentInChildren<FPSCameraMover>(); 
    }

    void Update()
    {
        CamSwitch();
    }

    private void CamSwitch()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (camSwitch)
            {
                camSwitch = false;
            }
            else
            {
                camSwitch = true;
                fpscam.CameraReset();
            }
        }

        //if (camSwitch == true)
        //{
        //    fpsCam.Priority = 2;
        //    tpsCam.Priority = 1;
        //}
        //else
        //{
        //    fpsCam.Priority = 1;
        //    tpsCam.Priority = 2;
        //}
    }
}
