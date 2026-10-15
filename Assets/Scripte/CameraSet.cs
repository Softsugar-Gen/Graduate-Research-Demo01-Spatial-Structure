using UnityEngine;
using UnityEngine.UI;

public class CameraSet : MonoBehaviour
{
    public GameObject cameraCenter;
    public GameObject roomCenter;
    public Slider cameraRotate;
    public Slider cameraZoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cameraCenter = GameObject.Find("RoomCenter");
        //roomCenter = GameObject.Find("Floor");
        RestartCamera();
    }
    public void RestartCamera()
    {
        cameraCenter.transform.position = roomCenter.transform.position;
        Debug.Log("已回到房间原点");
    }
    public void CameraControl()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        float rotate_Value = cameraRotate.value;
        float zoom_Value = cameraZoom.value;
        mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x, rotate_Value,mainCamera.transform.eulerAngles.z);
        mainCamera.GetComponent<Camera>().orthographicSize = zoom_Value;
    }
}
