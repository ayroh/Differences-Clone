using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;

namespace CameraManage
{
    public class CameraManager : MonoBehaviour
    {

        [SerializeField] List<Camera> cameras;

        void Awake()
        {
            for(int i = 0; i < cameras.Count; i++)
            {
                float screenRatio = ((float)Screen.width / Screen.height);
                if (Constants.BaseCameraAspect / screenRatio > 1)
                {
                    cameras[i].orthographicSize = Constants.BaseCameraSize * Constants.BaseCameraAspect / screenRatio;
                }
            }
        }

    }

}

