using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Camera cam;
    Vector3 mousePos;
    RaycastHit hit;

    public LayerMask floorMask;

    //测试用prefabs
    public GameObject furniture;

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

        if (currentFurniture != null)
        {
            currentFurniture.transform.position = hit.point;
            if (Input.GetMouseButtonDown(1))
            {
                trueFurniture = Instantiate(furniture, hit.point, Quaternion.identity);
                Destroy(currentFurniture);
            }
        }
        Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask);
    }
    public void SetFurniture(GameObject furniturePrefab)
    {
        furniture = furniturePrefab;
        currentFurniture = Instantiate(furniture, hit.point, Quaternion.identity);
    }
}

