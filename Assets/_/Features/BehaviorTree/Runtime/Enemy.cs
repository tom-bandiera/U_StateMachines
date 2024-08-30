using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree.Runtime
{
    public class Enemy : MonoBehaviour
    {
        #region Publics

        public float _value=20;
        private Sequence _mainNode;

        #endregion

        #region Unity API

        void Awake()
        {
            _mainNode = new Sequence();

            var patrol = new Selector();

            patrol.m_children.Add(new CheckIfValueIsLessThanNode(this,10));
            patrol.m_children.Add(new PatrolLeaf(gameObject.GetComponent<NavMeshAgent>(), _patrolPoints.m_patrolPointsList));
            

            var attack = new Sequence();
            attack.m_children.Add(new TellMeSomethingLeaf("ATTACK"));

            _mainNode.m_children.Add(patrol);
            _mainNode.m_children.Add(attack);
        }

        // Update is called once per frame
        void Update()
    	{
            _mainNode.Process();
    	}

        #endregion

        #region Main methods

        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] private PatrolPoints _patrolPoints;
	
        #endregion
    }

}
