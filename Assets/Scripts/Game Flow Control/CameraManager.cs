using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;

public class CameraManager : MonoBehaviour
{

    [SerializeField] List<Camera> cameras;
 
    void Awake()
    {
        for(int i = 0; i < cameras.Count; i++)
        {
            cameras[i].orthographicSize = Constants.BaseCameraSize * ((float)Screen.height / Screen.width) * Constants.BaseCameraAspect;
        }
    }

}
