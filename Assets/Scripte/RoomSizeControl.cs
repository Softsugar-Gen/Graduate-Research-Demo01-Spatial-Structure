using UnityEngine;
using UnityEngine.UI;

public class RoomSizeControl : MonoBehaviour
{
    //找控制前后左右尺寸的滑动条
    public Slider horiz_Slide;
    public Slider vert_Slide;

    //游戏里的地板和底部方块
    public GameObject ground;
    public GameObject floor;

    //游戏里的墙壁
    public GameObject leftWall;
    public GameObject backWall;

    //获取默认房间数值
    float pastHoriz_value;
    float pastVert_value;

    //墙壁的尺寸/位置变化量
    float scaleDelta;
    float positionDelta;

    //保存底座到地板的距离
    float distX;
    float distZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //horizonalSlide = GameObject.Find("Horizontal").GetComponent<Slider>();
        //verticalSlide = GameObject.Find("Vertical").GetComponent <Slider>();
        pastHoriz_value = horiz_Slide.value;
        pastVert_value = vert_Slide.value;

        //计算地板和底部方块的距离
        distX = ground.transform.localScale.x - floor.transform.localScale.x;
        distZ = ground.transform.localScale.z - floor.transform.localScale.z;
    }

    public void SizeControl()
    {
        //获取滑块数据
        float horiz_value = horiz_Slide.value;
        float vert_value = vert_Slide.value;

        

        //实际调整数值
        floor.transform.localScale = new Vector3(horiz_value, floor.transform.localScale.y, vert_value);
        ground.transform.localScale = new Vector3(horiz_value + distX, ground.transform.localScale.y, vert_value + distZ);

        //调整墙壁位置大小
        //斜右向内收缩
        if(pastHoriz_value > horiz_value)
        {
            calculateDelta(pastHoriz_value,horiz_value);
            leftWall.transform.localScale -= Vector3.right * scaleDelta;
            backWall.transform.localPosition += Vector3.right * positionDelta;
            pastHoriz_value = horiz_value;
        }
        //斜右向外扩张
        if(pastHoriz_value < horiz_value)
        {
            calculateDelta(horiz_value, pastHoriz_value);
            leftWall.transform.localScale += Vector3.right * scaleDelta;
            backWall.transform.localPosition -= Vector3.right * positionDelta;
            pastHoriz_value = horiz_value;
        }
        //斜左向内收缩
        if(pastVert_value > vert_value)
        {
            calculateDelta(pastVert_value, vert_value);
            backWall.transform.localScale -= Vector3.forward * scaleDelta;
            leftWall.transform.localPosition += Vector3.forward * positionDelta;
            pastVert_value = vert_value;
        }
        //斜左向外扩张
        if(pastVert_value < vert_value)
        {
            calculateDelta(pastVert_value, vert_value);
            backWall.transform.localScale -= Vector3.forward * scaleDelta;
            leftWall.transform.localPosition += Vector3.forward * positionDelta;
            pastVert_value = vert_value;
        }
    }
    void calculateDelta(float a,float b)
    {
        scaleDelta = a - b;
        positionDelta = (a - b) / 2;
    }
}
