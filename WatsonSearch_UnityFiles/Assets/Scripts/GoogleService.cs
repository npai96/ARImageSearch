using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Use: Communicate with Google API, return JSON of request to be parsed for URL's
 *      to load images
 */

public class GoogleService : MonoBehaviour {

    public PictureFactory pictureFactory;
    public Text buttonText;
    private const string API_KEY = "AIzaSyCZf0QdlnUu02jSfD52Mxf9mRDZq5voIEg"; 

    public void GetPicture() {
        StartCoroutine(PictureRoutine());
    }

    IEnumerator PictureRoutine() {
        buttonText.transform.parent.gameObject.SetActive(false);
        string query = buttonText.text;

        /* Make query URL-friendly */
        query = WWW.EscapeURL(query + " design");
        pictureFactory.DeleteOldPictures();

        /* Save CameraForward vector for later use when loading pictures */
        Vector3 CameraForward = Camera.main.transform.forward;

        int RowNum = 1;

        /* Loop through 10 at a time, as this is the upper limit for # searches in Google API */
        for (int i = 1; i < 60; i += 10) {
            
            string url = "https://www.googleapis.com/customsearch/v1?q=" + query +
                "&cx=003623769318945352620%3Aiovyyjqdnok&filter=1&num=10&searchType=image&start=" + i + "&fields=items%2Flink&key=" + API_KEY;
            WWW www = new WWW(url);
            yield return www;
            pictureFactory.CreateImages(ParseResponse(www.text), RowNum, CameraForward);
            RowNum++;
        }
        yield return new WaitForSeconds(5f);
        buttonText.transform.parent.gameObject.SetActive(true);
    }


    List<string> ParseResponse (string text) 
    {
        List<string> URLList = new List<string>();
        string[] URLArray = text.Split('\n');

        foreach(string line in URLArray) {
            if (line.Contains("link")) {
                string CurrURL = line.Substring(12, line.Length - 13);

                if ((CurrURL.Contains(".jpg")) || (CurrURL.Contains(".png"))) {
                    URLList.Add(CurrURL);
                }
            }
        }

        return URLList;
    }
}
