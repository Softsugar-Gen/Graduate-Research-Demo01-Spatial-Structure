using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Camera cam;
    Vector3 mousePos;
    RaycastHit hit;

    public LayerMask floorMask;
    public LayerMask groundMask;

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

       if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (currentFurniture != null)
            {
                currentFurniture.transform.position = hit.point;

                if (Input.GetMouseButtonDown(0) && hit.collider.CompareTag("Floor"))
                {
                    trueFurniture = Instantiate(furniture, hit.point, Quaternion.identity);
                    Destroy(currentFurniture);
                }
            }
        }
    }
    public void SetFurniture(GameObject furniturePrefab)
    {
        furniture = furniturePrefab;
        currentFurniture = Instantiate(furniture, hit.point, Quaternion.identity);
    }
}

