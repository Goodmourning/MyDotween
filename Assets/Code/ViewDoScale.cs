using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDoScale : ViewDotween
    {
        protected override void Start()
        {
            base.Start();
            InitValue = transform.localScale;
        }
        
        protected override void ExecuteButtonOnClicked()
        {
            CurrentTween = transform.DoScale(EndValue, Duration, Snapping).SetEase(EasingMode);
        }
        
        protected override void ResetButtonOnClicked()
        {
            transform.localScale = InitValue;
        }
    }
}