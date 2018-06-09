using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFactory : MonoBehaviour {

    /* Need to drag prefab reference into inspector to instantiate it in script */
    public GameObject PicturePrefab;
    /* Public reference to Google Service to drag into insepector as well */
    public GoogleService googleService;

    public void DeleteOldPictures() 
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    /* Instantiate Picture Prefab */
    public void CreateImages(List<string>URLList, int ResultNum, Vector3 CameraForward) 
    {
        int PictureIndex = 1;
        Vector3 Center = Camera.main.transform.position;

        foreach (string CurrURL in URLList) {
            Vector3 Position = GetPosition(PictureIndex, ResultNum, CameraForward);
            GameObject Picture = Instantiate(PicturePrefab, Position, Quaternion.identity, this.transform);
            Picture.GetComponent<PictureBehaviour>().LoadImage(CurrURL);
            PictureIndex++;
        }
    }

    Vector3 GetPosition(int PictureIndex, int RowNum, Vector3 CameraForward) {
        Vector3 Position = Vector3.zero;

        if (PictureIndex <= 5) {
            Position = CameraForward + new Vector3(PictureIndex * -3, 0, RowNum * 3.5f); 
        } else {
            Position = CameraForward + new Vector3((PictureIndex % 5) * 3, 0,  RowNum * 3.5f);
        }

        return Position;
    }
}
