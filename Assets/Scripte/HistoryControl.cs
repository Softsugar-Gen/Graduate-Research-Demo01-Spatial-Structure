using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryControl : MonoBehaviour
{
    public Button history;
    public GameObject historyPanel;
    public GameObject size_C;
    public GameObject cam_C;
    public GameObject light_C;
    public GameObject Furn_C;
    public GameObject photoPrefab;
    public Transform content;

    bool isHistoryUp = false;

    void Start()
    {
        historyPanel.SetActive(false);
    }

    public void SetHistoryDown()
    {
        if(isHistoryUp)
        {
            isHistoryUp = false;
            size_C.SetActive(true);
            cam_C.SetActive(true);
            light_C.SetActive(true);
            Furn_C.SetActive(true);
            historyPanel.SetActive(false);
        }
        else
        {
            isHistoryUp = true;
            size_C.SetActive(false);
            cam_C.SetActive(false);
            light_C.SetActive(false);
            Furn_C.SetActive(false);
            historyPanel.SetActive(true);
        }
    }
    public void PhotoUpdate()
    {
        Directory.GetFiles(Application.dataPath + "/RoomHistory", "*.png");
        string[] files = Directory.GetFiles(Application.dataPath + "/RoomHistory", "*.png");
        foreach(string  file in files)
        {
            Debug.Log(file);
            byte[]photoData = File.ReadAllBytes(file);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(photoData);
            GameObject photo = Instantiate(photoPrefab, content);
            photo.GetComponentInChildren<RawImage>().texture = texture;
            photo.GetComponentInChildren<TMP_Text>().text = Path.GetFileNameWithoutExtension(file);  
        }if(!isHistoryUp)
        {
            foreach(Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
        
    }
}

