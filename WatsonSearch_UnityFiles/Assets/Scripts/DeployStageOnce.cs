//using System;
//using UnityEngine;
//using Vuforia;

//public class DeployStageOnce : VuforiaMonoBehaviour
//{

//    public GameObject AnchorStage;
//    private PositionalDeviceTracker _deviceTracker;
//    private GameObject _previousAnchor;

//    public void Start()
//    {
//        {
//            if (AnchorStage == null)
//            {
//                Debug.Log("AnchorStage must be specified");
//                return;
//            }
//        }

//        AnchorStage.SetActive(false);
//    }

//    public void Awake()
//    {
//        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforia)
//    }
//}

//// same anchor code from before

//var anchor = _deviceTracker.CreatePlaneAnchor(Guid.NewGuid().ToString(), result);

//// but now the anchor doesn't create a GameObject, so we will have to with the HitTestResult position and rotation values

//GameObject anchorGO = new GameObject();

//anchorGO.transform.position = result.Position;

       // anchorGO.transform.rotation = result.Rotation;

       // // Parent the stage to the new GameObject like you would have the anchor before

       //if(anchor != null) {

        //    AnchorStage.transform.parent = anchorGO.transform;

        //    AnchorStage.transform.localPosition = Vector3.zero;

        //    AnchorStage.transform.localRotation = Quaternion.identity;

        //    AnchorStage.SetActive(true);

        //}

        //// Clean up

        //if(_previousAnchor != null) {

        //    Destroy(_previousAnchor);

        //}

        // // Save it

        //_previousAnchor = anchorGO;
