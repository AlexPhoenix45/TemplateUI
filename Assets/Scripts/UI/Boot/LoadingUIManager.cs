using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUIManager : MonoBehaviour
{
    public static LoadingUIManager Instance;

    [SerializeField] private Slider loadingSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public static void In()
    {
        Instance._In();
    }

    private void _In()
    {
        
    }

    public static void Out()
    {
        
    }

    private void _Out()
    {
        
    }
}