namespace SignalRWebApi.TimerFeatures
{
    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; private set; }

        public TimerManager(Action action)
        {
            _action= action;
            _autoResetEvent= new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 5000, 15000);
            TimerStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();
            
            if ((DateTime.Now - TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
