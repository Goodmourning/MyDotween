using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MyDotween
{
    public class ViewDotween : MonoBehaviour
    {
        public Vector3 EndValue;
        public bool Snapping;
        public float Duration;
        public EasingMode EasingMode;
        public Button ExecuteButton;
        public Button KillButton;
        public Button ResetButton;

        public Transform myTransform;
        public Transform officialTransform;
        
        protected Vector3 InitValue;
        protected Tween CurrentTween;
        protected DG.Tweening.Tween OfficialTween;

        protected virtual void Start()
        {
            ExecuteButton.onClick.AddListener(ExecuteButtonOnClicked);
            KillButton.onClick.AddListener(KillButtonOnClicked);
            ResetButton.onClick.AddListener(ResetButtonOnClicked);
        }
        
        protected virtual void ExecuteButtonOnClicked()
        {
            
        }
        
        private void KillButtonOnClicked()
        {
            if (CurrentTween != null)
            {
                CurrentTween.Kill();
                CurrentTween = null;
            }
            if (OfficialTween != null)
            {
                OfficialTween.Kill();
                OfficialTween = null;
            }
        }
        
        protected virtual void ResetButtonOnClicked()
        {
            
        }
    }
}