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
        public Func<Vector3> Getter;
        public Action<Vector3> Setter;

        public Tween(Func<Vector3> getter, Action<Vector3> setter, Vector3 endValue, float duration, bool snapping)
        {
            // _target = target;
            Getter = getter;
            Setter = setter;
            _startValue = Getter.Invoke();
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
            var lerpX = Mathf.Lerp(_startValue.x, _endValue.x, _elapsedTime / _duration);
            var lerpY = Mathf.Lerp(_startValue.y, _endValue.y, _elapsedTime / _duration);
            var lerpZ = Mathf.Lerp(_startValue.z, _endValue.z, _elapsedTime / _duration);
            Setter.Invoke(new Vector3(lerpX, lerpY, lerpZ));
        }
        
        public bool IsFinished()
        {
            return _curState == TweenState.Finished
                || Getter.Invoke() == _endValue;
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

    public enum EasingMode
    {
        Linear,
    }
}

