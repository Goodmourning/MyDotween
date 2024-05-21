using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDoMove : MonoBehaviour
    {
        public Vector3 EndPosition;
        public bool Snapping;
        public float Duration;
        public EasingMode EasingMode;
        public Button ExecuteButton;
        public Button KillButton;

        private void Start()
        {
            ExecuteButton.onClick.AddListener(ExecuteButtonOnClicked);
            KillButton.onClick.AddListener(KillButtonOnClicked);
        }
        
        private Tween _currentTween;
        private void ExecuteButtonOnClicked()
        {
            _currentTween = transform.DoMove(EndPosition, Duration, Snapping);
        }
        
        private void KillButtonOnClicked()
        {
            if (_currentTween != null)
            {
                _currentTween.Kill();
                _currentTween = null;
            }
        }
    }
}