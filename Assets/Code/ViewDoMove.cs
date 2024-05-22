using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDoMove : ViewDotween
    {
        protected override void Start()
        {
            base.Start();
            InitValue = myTransform.position;
        }
        
        protected override void ExecuteButtonOnClicked()
        {
            CurrentTween = myTransform.DoMove(EndValue, Duration, Snapping).SetEase(EasingMode);
            OfficialTween = officialTransform.DOMove(EndValue, Duration, Snapping).SetEase(EasingFunction.ToEase(EasingMode));
        }
        
        protected override void ResetButtonOnClicked()
        {
            myTransform.position = InitValue;
            officialTransform.position = InitValue;
        }
    }
}