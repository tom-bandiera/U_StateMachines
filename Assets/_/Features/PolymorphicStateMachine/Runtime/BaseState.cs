using System;
using UnityEngine;

namespace PolymorphicStateMachine.Runtime
{
    public abstract class BaseState<EState> where EState : Enum 
    {
        #region Publics

        #endregion

        #region Main methods

        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public abstract EState GetNextState();
        public abstract void OnTriggerEnter(Collider other);
        public abstract void OnTriggerStay(Collider other);
        public abstract void OnTriggerExti(Collider other);
	
        #endregion

        #region Privates & Protected
	
        #endregion
    }

}
