namespace SlotsGame.Scripts
{
    public abstract class Game
    {
        public abstract class Signal
        {
            public class SpinStarted { }
            public class SpinEnded { }
            public class EffectsStarted { }
            public class EffectsEnded { }
            public class RoundEnded { }
        }
    }
}
