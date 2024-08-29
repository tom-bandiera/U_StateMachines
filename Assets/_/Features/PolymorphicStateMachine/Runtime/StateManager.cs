using System;
using System.Collections.Generic;
using UnityEngine;

namespace PolymorphicStateMachine.Runtime
{
    public class StateManager<EState> : MonoBehaviour where EState : Enum
    {
        #region Publics

        

        #endregion

        #region Main methods

        private void Start() 
        {
            _currentState.EnterState();
        }

        private void Update() { }

        private void OnTriggerEnter(Collider other) { }

        private void OnTriggerStay(Collider other) { }

        private void OnTriggerExit(Collider other) { }


        #endregion

        #region Privates & Protected

        protected Dictionary<EState, BaseState<EState>> _states = new Dictionary<EState, BaseState<EState>>();
        protected BaseState<EState> _currentState;

        #endregion
    }

}
