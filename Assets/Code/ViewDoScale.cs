using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDoScale : ViewDotween
    {
        protected override void Start()
        {
            base.Start();
            InitValue = myTransform.localScale;
        }
        
        protected override void ExecuteButtonOnClicked()
        {
            CurrentTween = myTransform.DoScale(EndValue, Duration, Snapping).SetEase(EasingMode);
            OfficialTween = officialTransform.DOScale(EndValue, Duration).SetEase(EasingFunction.ToEase(EasingMode));
        }
        
        protected override void ResetButtonOnClicked()
        {
            myTransform.localScale = InitValue;
            officialTransform.localScale = InitValue;
        }
    }
}