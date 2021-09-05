using System;
using ClumsyCraig.StateMachine.States;

namespace ClumsyCraig.StateMachine
{
    public static class LevelStates
    {
        public static readonly Type Start = typeof(StartScreen);
        public static readonly Type Playing = typeof(Playing);
        public static readonly Type Win = typeof(Win);
        public static readonly Type Reset = typeof(Reset);
        public static readonly Type LoseDad = typeof(LoseDad);
        public static readonly Type LoseMam = typeof(LoseMam);
    }
}