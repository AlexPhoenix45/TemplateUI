public class Home : GameMode
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
                    
                }
                break;
            }
            case Status.FADEOUT:
            {
                
                break;
            }
            case Status.FINALIZE:
            {
                
                break;
            }
            default:
                break;
        }
    }
}