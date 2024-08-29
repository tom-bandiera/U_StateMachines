using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace StateMachine.Runtime
{
    public abstract class State 
    {
        #region Publics

        public State (ICanUseStateMachine character)
        {
            _character = character;
        }
	
        #endregion

        #region Unity API
		
    	// Start is called before the first frame update
    	void Start()
    	{
			
    	}

    	// Update is called once per frame
    	void Update()
    	{
			
    	}

        #endregion

        #region Main methods

        public abstract State Tick(float _deltaTime);
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        #endregion


        #region Privates & Protected

        protected ICanUseStateMachine _character;

        #endregion
    }

}
