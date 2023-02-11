namespace UI
{
    public class Pause: BasePanel
    {
        private event PauseDelegate _pause;

        public void SubscribeResume(PauseDelegate pauseDelegate)
        {
            _pause += pauseDelegate;
        }

        protected override void OnContinue()
        {
            
            _pause?.Invoke();
        }
    }
}