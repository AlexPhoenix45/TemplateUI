using System;
using NUnit.Framework;

public class Boot : GameMode
{
    public enum Status
    {
        INITIALIZE,
        FADEIN,
        IDLE,
        FADEOUT,
    }
    
    public static Status status = Status.INITIALIZE;

    public override void Init()
    {
        status = Status.INITIALIZE;        
    }

    public override void Update()
    {
        switch (status)
        {
            case Status.INITIALIZE:
            {
                FadeUIManager.FadeIn();
                
                break;
            }
            case Status.FADEIN:
            {
                
                break;
            }
            case Status.IDLE:
                break;
            case Status.FADEOUT:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }   
    }
}