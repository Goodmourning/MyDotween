using System;
using System.Data;
using System.Numerics;
using UnityEngine;

namespace MyDotween
{
    public static class EasingFunction
    {
        public static float Evaluate(EasingMode mode, float elapsedTime, float duration, float overshootOrAmplitude = 1.70158f)
        {
            switch (mode)
            {
                case EasingMode.Linear:
                    return elapsedTime / duration;
                case EasingMode.EaseInSine:
                    return (float) (-Math.Cos(elapsedTime / duration * 1.5707963705062866) + 1.0);
                case EasingMode.EaseOutSine:
                    return (float) Math.Sin(elapsedTime / duration * 1.5707963705062866);
                case EasingMode.EaseInOutSine:
                    return (float) (-0.5 * (Math.Cos(3.1415927410125732 * elapsedTime / duration) - 1.0));
                case EasingMode.EaseInBack:
                    return (float) ((elapsedTime /= duration) * elapsedTime * ((overshootOrAmplitude + 1.0) *  elapsedTime - overshootOrAmplitude));
                case EasingMode.EaseOutBack:
                    return (float) ((elapsedTime = (float) (elapsedTime / duration - 1.0)) *  elapsedTime * ((overshootOrAmplitude + 1.0) *  elapsedTime + overshootOrAmplitude) + 1.0);
                case EasingMode.EaseInOutBack:
                    return  (elapsedTime /= duration * 0.5f) < 1.0 ? (float) (0.5 * (elapsedTime * elapsedTime * (((overshootOrAmplitude *= 1.525f) + 1.0) *  elapsedTime - overshootOrAmplitude))) : (float) (0.5 * ( (elapsedTime -= 2f) *  elapsedTime * (((overshootOrAmplitude *= 1.525f) + 1.0) *  elapsedTime + overshootOrAmplitude) + 2.0));
                default:
                    Debug.LogError("Not Support Ease Mode: " + mode);
                    return 0;
            }
        }
    }
}