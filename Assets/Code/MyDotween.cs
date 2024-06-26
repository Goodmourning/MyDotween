using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyDotween
{
    public enum TweenState
    {
        InProgress,
        Finished,
    }
    
    public class Tween
    {
        // private Transform _target;
        private Vector3 _startValue;
        private Vector3 _endValue;
        private float _duration;
        private float _elapsedTime;
        private bool _snapping = false;
        private TweenState _curState;
        private Func<Vector3> _getter;
        private Action<Vector3> _setter;
        private EasingMode _easingMode;

        public Tween(Func<Vector3> getter, Action<Vector3> setter, Vector3 endValue, float duration, bool snapping)
        {
            // _target = target;
            _getter = getter;
            _setter = setter;
            _startValue = _getter.Invoke();
            _endValue = endValue;
            _duration = duration;
            _snapping = snapping;
            _curState = TweenState.InProgress;
        }
        
        
        public void Kill()
        {
            _curState = TweenState.Finished;
        }

        public void Run()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _duration)
            {
                _elapsedTime = _duration;
            }

            var ratio = EasingFunction.Evaluate(_easingMode, _elapsedTime, _duration);
            var lerpX = Mathf.LerpUnclamped(_startValue.x, _endValue.x, ratio);
            var lerpY = Mathf.LerpUnclamped(_startValue.y, _endValue.y, ratio);
            var lerpZ = Mathf.LerpUnclamped(_startValue.z, _endValue.z, ratio);
            if (_snapping)
            {
                lerpX = Mathf.Round(lerpX);
                lerpY = Mathf.Round(lerpY);
                lerpZ = Mathf.Round(lerpZ);
            }
            _setter.Invoke(new Vector3(lerpX, lerpY, lerpZ));
        }
        
        public bool IsFinished()
        {
            return _curState == TweenState.Finished
                || _getter.Invoke() == _endValue;
        }

        public Tween SetEase(EasingMode mode)
        {
            _easingMode = mode;
            return this;
        }
    }

    public static class TweenHelper
    {
        public static Tween DoMove(this Transform transform, Vector3 endValue, float duration, bool snapping = false)
        {
            var tween = new Tween(() => transform.position, v => transform.position = v, endValue, duration, snapping);
            TweenManager.Instance.RegisterTween(tween);
            return tween;
        }
        
        public static Tween DoScale(this Transform transform, Vector3 endValue, float duration, bool snapping = false)
        {
            var tween = new Tween(() => transform.localScale, v => transform.localScale = v, endValue, duration, snapping);
            TweenManager.Instance.RegisterTween(tween);
            return tween;
        }
    }

}

