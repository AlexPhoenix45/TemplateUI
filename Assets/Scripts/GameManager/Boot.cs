using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : GameMode
{
    public enum Status
    {
        INITIALIZE,
        FADEIN,
        IDLE,
        FADEOUT,
        FINALIZE,
    }

    private Status currentStatus = Status.INITIALIZE;
    private AsyncOperation asyncOp = null;
    private float timer = 0.0f;

    public override void Init()
    {
        currentStatus = Status.INITIALIZE;
    }

    public override void Update()
    {
        switch (currentStatus)
        {
            case Status.INITIALIZE:
            {
                currentStatus = Status.FADEIN;
                break;
            }
            case Status.FADEIN:
            {
                FadeUIManager.FadeIn();
                currentStatus = Status.IDLE;
                break;
            }
            case Status.IDLE:
            {
                if (FadeUIManager.IsAnimationCompleted())
                {
                    if (asyncOp == null)
                    {
                        asyncOp = SceneManager.LoadSceneAsync("Main");
                        asyncOp.allowSceneActivation = false;
                    }

                    timer += Time.unscaledDeltaTime;
                    var limit = 0.5f;
                    limit += asyncOp.progress >= 0.89f ? 0.5f : 0.0f;
                    timer = Mathf.Min(timer, limit);
                    LoadingUIManager.SetLoadingGauge(timer / 1.0f);

                    if (LoadingUIManager.IsAnimationCompleted() && asyncOp.progress >= 0.89f)
                    {
                        currentStatus = Status.FADEOUT;
                    }
                }

                break;
            }
            case Status.FADEOUT:
            {
                if (LoadingUIManager.IsAnimationCompleted())
                {
                    FadeUIManager.FadeOut();
                    currentStatus = Status.FINALIZE;
                }

                break;
            }
            case Status.FINALIZE:
            {
                if (FadeUIManager.IsAnimationCompleted())
                {
                    asyncOp.allowSceneActivation = true;
                    currentStatus = Status.INITIALIZE;
                    SystemManager.ChangeStatus(SystemManager.GameStatus.HOME);
                }

                break;
            }
            default:
                break;
        }
    }
}