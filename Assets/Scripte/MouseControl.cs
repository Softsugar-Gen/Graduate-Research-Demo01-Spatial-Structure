using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Camera cam;
    Vector3 mousePos;
    RaycastHit hit;

    public LayerMask floorMask;

    //测试用prefabs
    public GameObject chair;

    GameObject currentFurniture;
    GameObject trueFurniture;
    private void Start()
    {
        //获取主摄像机位置
        cam = Camera.main;
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);

        //如果鼠标在floor物体中进行移动,且并没有选中的物品
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask))
        {
            //当鼠标在地板位置按下后，生成模型。反之不生成
            if (Input.GetMouseButtonDown(0))
            {
                //如果击中了floor物体
                if (hit.collider.CompareTag("Floor"))
                {
                    //保存一个可以拖动的物体
                    currentFurniture = Instantiate(chair, hit.point, Quaternion.identity);

                    //点击的三维坐标轴
                    Debug.Log(hit.point);
                }
                else
                {
                    return;
                }
            }

            //如果已经点击并生成了物体，才移动物体，并且销毁手上的
            if (currentFurniture != null)
            {
                currentFurniture.transform.position = hit.point;
                if (Input.GetMouseButtonDown(1))
                {
                    trueFurniture = Instantiate(chair, hit.point, Quaternion.identity);
                    Destroy(currentFurniture);
                }
            }

        }
    }
}

