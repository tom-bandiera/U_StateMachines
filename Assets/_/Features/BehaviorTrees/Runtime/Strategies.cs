using Codice.Client.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTrees.Runtime
{
    public interface IStrategy
    {
        public Node.Status Process();
        public void Reset() { }
    }

    public class ConditionStrategy : IStrategy
    {
        readonly Func<bool> predicate;
        public ConditionStrategy(Func<bool> predicate)
        {
            this.predicate = predicate;
        }

        public Node.Status Process() => predicate() ? Node.Status.Success : Node.Status.Failure;
    }

    public class ActionStrategy : IStrategy
    {
        readonly Action doSomething;

        public ActionStrategy(Action doSomething)
        {
            this.doSomething = doSomething;
        }

        public Node.Status Process()
        {
            doSomething();
            return Node.Status.Success;
        }
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

            // Rotate Entity towards next patrol point
            var targetDirection = target.position - _entity.transform.position;
            targetDirection.y = 0; // Ensure no rotation on the X and Z axes
            var targetRotation = Quaternion.LookRotation(targetDirection);
            _entity.transform.rotation = Quaternion.Slerp(_entity.transform.rotation, targetRotation, Time.deltaTime * 5f);

            if (_agent.remainingDistance < 0.1f)
            {
                _currentIndex++;
            }

            return Node.Status.Running;
        }

        public void Reset() => _currentIndex = 0;
    }
}
