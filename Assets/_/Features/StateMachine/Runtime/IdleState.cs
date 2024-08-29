using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Runtime
{
    public class IdleState : State
    {

        #region Publics

        #endregion

        #region Main methods

        public IdleState(ICanUseStateMachine character) : base(character) { }

        public override State Tick(float _deltaTime)
        {
            if (_character.HasFoundTarget())
            {
                return new ChasingState(_character);
            }

            return this;
        }

        #endregion

        #region Privates & Protected


        #endregion
    }

}
