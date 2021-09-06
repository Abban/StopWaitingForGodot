namespace ClumsyCraig
{
    public static class Config
    {
        public enum Parents
        {
            Dad,
            Mam
        }

        public enum EndGameTypes
        {
            Win,
            Noise,
            Spotted,
            Fall
        }
        
        public static class ObjectNames
        {
            public const string CraigBody = "CraigBody";
            public const string FingerBody = "Finger";
        }
        
        public static class Input
        {
            public const string Up = "up";
            public const string Right = "right";
            public const string Down = "down";
            public const string Left = "left";
            public const string Select = "select";
        }
    }
}
