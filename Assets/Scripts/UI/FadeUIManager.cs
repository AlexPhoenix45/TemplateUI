using System;
using UnityEngine;

public class FadeUIManager : MonoBehaviour
{
    public static FadeUIManager Instance;
    
    [SerializeField] private Animator anim;
    
    private bool isAnimationCompleted = false;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public static void FadeIn()
    {
        Instance._FadeIn();
    }

    private void _FadeIn()
    {
        isAnimationCompleted = false;
        anim.Play("In");    
    }

    public static void FadeOut()
    {
        Instance._FadeOut();
    }

    private void _FadeOut()
    {
        isAnimationCompleted = false;
        anim.Play("Out");
    }

    private void OnAnimationCompleted()
    {
        isAnimationCompleted = true;
    }

    public static bool IsAnimationCompleted()
    {
        return Instance.isAnimationCompleted;
    }
}