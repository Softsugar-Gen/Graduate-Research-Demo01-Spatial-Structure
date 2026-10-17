using UnityEngine;

public class CameraReset : MonoBehaviour
{
    //找相机中心和房间中心的物体
    public GameObject cameraCenter;
    public GameObject roomCenter;

    void Start()
    {
        //cameraCenter = GameObject.Find("RoomCenter");
        //roomCenter = GameObject.Find("Floor");

        //游戏开始时运行一次重置相机方法
        RestartCamera();
    }

    public void RestartCamera()
    {
        //将相机中心物体的位置重置为房间中心物体的位置
        cameraCenter.transform.position = roomCenter.transform.position;
        Debug.Log("已回到房间原点");
    }
}
