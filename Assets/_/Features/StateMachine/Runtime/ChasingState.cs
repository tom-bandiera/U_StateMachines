using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Runtime
{
    public class ChasingState : State
    {

        #region Publics



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

        public ChasingState(ICanUseStateMachine character) : base(character)
        {
            _character = character;
        }

        public override State Tick(float _deltaTime)
        {
            if (!_character.HasFoundTarget())
            {
                return new IdleState(_character);
            }

            if (_character.IsTargetInAttackRange())
            {
                return new AttackState(_character);
            }

            _character.DoChasing(_deltaTime);
            
            return this;
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        #endregion
    }

}
