using Cysharp.Threading.Tasks;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utilities.Constants;

namespace Objects
{
    public class FoundParticle : UIParticle, IPoolable
    {
        public override PoolObjectType poolObjectType { get => PoolObjectType.FoundParticle; }

        public async void DragToPointAndRelease(Vector2 screenStartPoint, Vector2 screenEndPoint)
        {
            Vector2 startPoint = ScreenPointToTransformPoint(screenStartPoint);
            Vector2 endPoint = ScreenPointToTransformPoint(screenEndPoint);

            float timer = 0f;
            float currentTime = 0f;
            float animationTime = Constants.FoundParticleAnimationConstant * Vector2.Distance(endPoint, startPoint);
            while (timer < animationTime)
            {
                currentTime = timer / animationTime;
                transform.localPosition = new Vector2(
                                            Mathf.Lerp(startPoint.x, endPoint.x, currentTime),
                                            Mathf.Lerp(startPoint.y, endPoint.y, Curves.instance.foundParticleYAxisCurve.Evaluate(currentTime)));
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }

            transform.position = endPoint;
            ReleaseAfterAllParticlesFinished();
        }

        public async void ReleaseAfterAllParticlesFinished()
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            await UniTask.Delay((int)(particle.main.startLifetime.constant * 1000));
            PoolManager.instance.Release(this);
        }


        // Screen Point (0,0) is left-bottom but UICamera (0,0) is middle of the screen. To convert this I use Screen class.
        private Vector2 ScreenPointToTransformPoint(Vector2 screenPoint) => new Vector2(screenPoint.x - (Screen.width / 2), screenPoint.y - (Screen.height / 2));

    }
}