using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Runtime
{
    public class AttackState : State
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

        public AttackState(ICanUseStateMachine character) : base(character)
        {
            _character = character;
        }

        public void OnStateEnter()
        {

        }

        public override State Tick(float _deltaTime)
        {
            if (!_character.IsTargetInAttackRange())
            {
                return new ChasingState(_character);
            }

            _character.DoAttack(_deltaTime);

            return this;
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        #endregion
    }

}
