using System.Collections.Generic;
using UnityEngine;

namespace MyDotween
{
    public class TweenManager : MonoBehaviour
    {
        public static TweenManager Instance;
        private List<Tween> _runningTweens;
        
        public void RegisterTween(Tween tween)
        {
            _runningTweens.Add(tween);
        }

        private void Start()
        {
            _runningTweens = new List<Tween>();
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            for (int i = _runningTweens.Count - 1; i >= 0; i--)
            {
                if (_runningTweens[i].IsFinished())
                {
                    _runningTweens[i].Kill();
                    _runningTweens.RemoveAt(i);
                }
                else
                {
                    _runningTweens[i].Run();
                }
            }
        }
    }
}