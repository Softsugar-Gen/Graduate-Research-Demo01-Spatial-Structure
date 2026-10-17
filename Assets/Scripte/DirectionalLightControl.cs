using UnityEngine;
using UnityEngine.UI;

public class DirectionalLightControl : MonoBehaviour
{
    //找控制光源的滑动条
    public Slider Temperaure;
    public Slider LightDirection;
    public Slider LightIntensity;

    public void LightControl()
    {
        //获取光源物体
        GameObject directionalLight = GameObject.Find("Directional Light");

        //获取滑块数据
        float TemperaureValue = Temperaure.value;
        float LightDirectionValue = LightDirection.value;
        float LightIntensityValue = LightIntensity.value;

        //调整光源属性
        directionalLight.GetComponent<Light>().colorTemperature = TemperaureValue;
        directionalLight.transform.eulerAngles = new Vector3(directionalLight.transform.eulerAngles.x, LightDirectionValue, directionalLight.transform.eulerAngles.z);
        directionalLight.GetComponent<Light>().intensity = LightIntensityValue;
    }
}
