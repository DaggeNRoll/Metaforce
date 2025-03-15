using System;
using System.Collections.Generic;

namespace _Project.Codebase.Common
{
    public abstract class StateMachineBase
    {
        protected Dictionary<Type, IState> States;
        protected IState CurrentState;
    }

    public interface IState
    {
        void Enter();
        void Exit();
    }
}