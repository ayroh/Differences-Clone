using Objects;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Constants;

namespace ScoreManage
{
    public class Score : UIImageObject, IPoolable
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Animation scoreAnimation;

        public override PoolObjectType poolObjectType { get => PoolObjectType.Score; }

        public void PlayAnimation(string animationName) => scoreAnimation.Play(animationName);

        public override void Initialize(Transform parent = null)
        {
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
            gameObject.SetActive(true);
            mainImage.gameObject.SetActive(true);
            PlayAnimation(Constants.ScoreColorizeAnimationName);
        }

        public override void ResetObject(Transform parent = null)
        {
            gameObject.SetActive(false);
        }

    }

}

