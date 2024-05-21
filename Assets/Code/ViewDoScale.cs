using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDoScale : MonoBehaviour
    {
        public Vector3 EndScale;
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
            _currentTween = transform.DoScale(EndScale, Duration, Snapping);
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