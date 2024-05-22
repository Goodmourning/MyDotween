using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDoMove : ViewDotween
    {
        protected override void Start()
        {
            base.Start();
            InitValue = transform.position;
        }
        
        protected override void ExecuteButtonOnClicked()
        {
            CurrentTween = transform.DoMove(EndValue, Duration, Snapping).SetEase(EasingMode);
        }
        
        protected override void ResetButtonOnClicked()
        {
            transform.position = InitValue;
        }
    }
}