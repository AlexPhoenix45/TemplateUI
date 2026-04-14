using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUIManager : MonoBehaviour
{
    public static LoadingUIManager Instance;

    [SerializeField] private Slider loadingSlider;

    private bool isAnimationCompleted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public static void SetLoadingGauge(float value)
    {
        Instance._SetLoadingGauge(value);
    }

    private void _SetLoadingGauge(float _value)
    {
        if (loadingSlider == null) return;

        loadingSlider.value = _value;
        if (_value >= 1f)
        {
            isAnimationCompleted = true;
        }
    }


    public static bool IsAnimationCompleted()
    {
        return Instance.isAnimationCompleted;
    }
}