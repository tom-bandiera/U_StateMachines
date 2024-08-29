using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace StateMachine.Runtime
{
    public class StateMachine : MonoBehaviour
    {
        #region Publics


	
        #endregion

        #region Unity API
		
    	    // Start is called before the first frame update
    		void Start()
    		{
                _currentState = new IdleState(_character);
            }

    		// Update is called once per frame
    		void Update()
    		{
			    var possibleNextState = _currentState.Tick(Time.deltaTime);

                if (possibleNextState != _currentState)
                {
                    _currentState.OnStateExit();
                    _currentState = possibleNextState;
                    _currentState.OnStateEnter();
                }
    		}

        #endregion

        #region Main methods

        private void ChangeState(State state)
        {
            _currentState.OnStateExit();
            _currentState = state;
            _currentState.OnStateEnter();
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        private State _currentState;

        [SerializeField] private Enemy _character;
        [SerializeField] private Animator _animator;

        #endregion
    }

}
