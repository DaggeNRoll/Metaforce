using System;
using System.Collections.Generic;
using _Project.Codebase.Common;

namespace _Project.Codebase.Infrastructure
{
    public class GameStateMachine : StateMachineBase
    {
        public GameStateMachine()
        {
            States = new Dictionary<Type, IState>
            {
                
            };
        }
    }
}