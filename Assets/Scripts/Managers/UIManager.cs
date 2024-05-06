using Cysharp.Threading.Tasks;
using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;

public class UIManager : Singleton<UIManager>
{
    [Header("References")]
    [SerializeField] private FactoryManager factoryManager;
    [SerializeField] private Camera mainCam;

    [Header("Values")]
    [SerializeField] private AnimationCurve bounceCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    public async void CreateCorrectCheckButton(Vector3 worldPos)
    {
        UIButtonObject uiButtonObject = factoryManager.GetCorrectCheckButton(mainCam.WorldToScreenPoint(worldPos));
        uiButtonObject.transform.localScale = new Vector3(.01f, .01f, .01f);
        uiButtonObject.SetButtonActive(false);

        float timer = .01f;
        float scaleValue = .01f;
        while(timer < Constants.CorrectCheckImageAnimationTime)
        {
            scaleValue = timer / Constants.CorrectCheckImageAnimationTime;
            uiButtonObject.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            timer += Time.deltaTime;
            await UniTask.NextFrame();
        }

        uiButtonObject.transform.localScale = Vector3.one;
        uiButtonObject.SetButtonActive(true);
    }

    //public async void ButtonShake
}
