using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Runtime
{
    public class Enemy : MonoBehaviour, ICanUseStateMachine
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

        public void DoIdle(float deltaTime)
        {
            if (_target == null) return;

            Debug.Log("Looking for u ...");

            if (HasFoundTarget())
            {
                Debug.Log("I found you! o.O");
            }
        }

        public void DoChasing(float deltaTime)
        {
            if (!IsTargetInAttackRange())
            {
                Vector3 chaseDirection = _target.transform.position - transform.position;
                transform.position += chaseDirection.normalized * _moveSpeed * deltaTime;
            }
        }

        public void DoAttack(float deltaTime)
        {
            Debug.Log("Attack");
        }

        public bool HasFoundTarget()
        {
            return Vector3.SqrMagnitude(_target.position - transform.position) <= _detectionRange * _detectionRange;
        }

        public bool IsTargetInAttackRange()
        {
            return Vector3.SqrMagnitude(_target.position - transform.position) <= _attackRange * _attackRange;
        }

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] private float _detectionRange = 5;
        [SerializeField] private float _attackRange = 1.5f;
        [SerializeField] private float _moveSpeed = 2;
        [SerializeField] private float _health = 100;
        [SerializeField] private float _stamina = 20;
        [SerializeField] private Transform _target;

        #endregion
    }

}
