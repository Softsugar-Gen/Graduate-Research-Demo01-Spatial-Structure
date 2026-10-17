using UnityEngine;
using UnityEngine.UI;

public class MainCameraControl : MonoBehaviour
{
    //找控制相机旋转和缩放的滑动条
    public Slider cameraRotate;
    public Slider cameraZoom;

      public void CameraControl()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        float rotate_Value = cameraRotate.value;
        float zoom_Value = cameraZoom.value;
        mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x, rotate_Value,mainCamera.transform.eulerAngles.z);
        mainCamera.GetComponent<Camera>().orthographicSize = zoom_Value;
    }
}
