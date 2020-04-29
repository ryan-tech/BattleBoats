using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject RTSCameraRig;

    public GameObject YawNode;  // Child of RTS Camera Rig
    public GameObject PitchNode;// Child of Yaw Node
    public GameObject RollNode; // Child of Pitch Node

    public float cameraMoveSpeed = 500;
    public float cameraTurnRate = 10;
    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 currentPitchEulerAngles = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
          YawNode.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            YawNode.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            YawNode.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            YawNode.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
        }
        YawNode.transform.position = new Vector3(YawNode.transform.position.x, RTSCameraRig.transform.position.y, YawNode.transform.position.z);

        // Mouse Scroll Wheel handles the zoom
        //RTSCameraRig.transform.position = new Vector3(RTSCameraRig.transform.position.x, RTSCameraRig.transform.position.y + Input.mouseScrollDelta.y, RTSCameraRig.transform.position.z);
        //y += Input.mouseScrollDelta.y

        if(Input.GetKey(KeyCode.Q))
        {
          RTSCameraRig.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed, Space.World);

        }
        if(Input.GetKey(KeyCode.E))
        {
          RTSCameraRig.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed, Space.World);
          //YawNode.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);
        }



        if (Input.GetKeyUp(KeyCode.C))
        {
            if (isRTSMode)
            {
                YawNode.transform.SetParent(ControlMgr.inst.player_entity.cameraRig.transform);
                YawNode.transform.localPosition = Vector3.zero;
                YawNode.transform.localEulerAngles = Vector3.zero;
            }
            else
            {
                YawNode.transform.SetParent(RTSCameraRig.transform);
                YawNode.transform.localPosition = Vector3.zero;
                YawNode.transform.localEulerAngles = Vector3.zero;
            }
            isRTSMode = !isRTSMode;

        }



    }
    public bool isRTSMode = true;
}
