using System;
using Godot;

namespace ClumsyCraig.Payload
{
    public class CraigBody : KinematicBody2D
    {
        public Action WinAction = () => { };
        public Action<Config.EndGameTypes, Config.Parents> LoseAction = (type, parent) => { };

        public void OnWin()
        {
            WinAction.Invoke();
        }

        public void OnLose(Config.EndGameTypes type, Config.Parents parents)
        {
            LoseAction.Invoke(type, parents);
        }
    }
}