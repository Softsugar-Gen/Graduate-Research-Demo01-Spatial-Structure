using UnityEngine;
using UnityEngine.UI;

public class DirectionalLightControl : MonoBehaviour
{
    //找控制光源的滑动条
    public Slider Temperaure;
    public Slider LightDirection;
    public Slider LightIntensity;
    public Slider LightColorR;
    public Slider LightColorG;
    public Slider LightColorB;

    public void LightControl()
    {
        //获取光源物体
        GameObject directionalLight = GameObject.Find("Directional Light");

        //获取滑块数据
        float TemperaureValue = Temperaure.value;
        float LightDirectionValue = LightDirection.value;
        float LightIntensityValue = LightIntensity.value;
        float LightColorRValue = LightColorR.value;
        float LightColorGValue = LightColorG.value;
        float LightColorBValue = LightColorB.value;

        //调整光源属性
        directionalLight.GetComponent<Light>().colorTemperature = TemperaureValue;
        directionalLight.transform.eulerAngles = new Vector3(directionalLight.transform.eulerAngles.x, LightDirectionValue, directionalLight.transform.eulerAngles.z);
        directionalLight.GetComponent<Light>().intensity = LightIntensityValue;
        directionalLight.GetComponent<Light>().color = new Color(LightColorRValue, LightColorGValue, LightColorBValue);
    }
}
