using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTrees.Runtime
{
    public interface IStrategy
    {
        public Node.Status Process();
        public void Reset();
    }

    public class PatrolStrategy : IStrategy
    {
        private readonly Transform _entity;
        private readonly NavMeshAgent _agent;
        private readonly List<Transform> _patrolPoints;
        private readonly float _patrolSpeed;
        private int _currentIndex;
        private bool _isPathCalculated;

        public PatrolStrategy(Transform entity, NavMeshAgent agent, List<Transform> patrolPoints, float patrolSpeed = 2f)
        {
            _entity = entity;
            _agent = agent;
            _patrolPoints = patrolPoints;
            _patrolSpeed = patrolSpeed;
        }

        public Node.Status Process()
        {
            if (_currentIndex == _patrolPoints.Count) return Node.Status.Success;

            var target = _patrolPoints[_currentIndex];
            _agent.SetDestination(target.position);
            // _entity.LookAt(target.position);

            if (_isPathCalculated && _agent.remainingDistance < 0.1f)
            {
                _currentIndex++;
                _isPathCalculated = false;
            }

            Debug.Log(_agent.pathPending);

            if (_agent.pathPending)
            {
                _isPathCalculated = true;
            }

            return Node.Status.Runnning;
        }

        public void Reset() => _currentIndex = 0;
    }
}
