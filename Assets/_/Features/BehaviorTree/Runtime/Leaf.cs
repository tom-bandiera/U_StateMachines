using BehaviorTree.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree.Runtime
{
    public class Leaf : NodeBase
    {
        public override State Process()
        {
            return State.SUCCESS;
        }
    }

    public class TellMeSomethingLeaf : Leaf
    {
        private string _text;

        public TellMeSomethingLeaf(string text)
        {
            _text = text;
        }

        public override State Process()
        {
            Debug.Log(_text);

            return State.SUCCESS;
        }
    }

    public class WaitForSecondsLeaf : Leaf
    {
        private float _duration;
        private float _timer;

        public WaitForSecondsLeaf(float duration)
        {
            _duration = duration;
        }

        public override State Process()
        {
            _timer += Time.deltaTime;

            if (_timer < _duration)
            {
                return State.RUNNING;
            }

            _timer = 0f;

            return State.SUCCESS;
        }
    }

    public class ReturnFailLeaf : Leaf
    {
        public override State Process()
        {
            return State.FAIL;
        }
    }

    public class ActivateGameObjectLeaf : Leaf
    {
        private GameObject _gameObject;
        private bool _isActive;

        public ActivateGameObjectLeaf(GameObject gameObject, bool isActive)
        {
            _gameObject = gameObject;
            _isActive = isActive;
        }

        public override State Process()
        {
            if (_gameObject == null) return State.FAIL;

            if (_isActive)
            {
                _gameObject.SetActive(true);
            } else
            {
                _gameObject.SetActive(false);
            }

            return State.SUCCESS;
        }
    }

    public class PatrolLeaf : Leaf
    {
        private NavMeshAgent _agent;
        private List<GameObject> _patrolPoints;
        private int _index;

        public PatrolLeaf(NavMeshAgent agent, List<GameObject> patrolPoints)
        {
            _agent = agent;
            _patrolPoints = patrolPoints;
        }

        public override State Process()
        {
            Debug.Log("Enter patrol process");
            var target = _patrolPoints[_index];
            _agent.SetDestination(target.transform.position);

            if (Vector3.SqrMagnitude(_agent.transform.position - target.transform.position)  < .5f)
            {
                _index++;
                if (_index >= _patrolPoints.Count)
                {
                    _index = 0;
                    return State.SUCCESS;
                }
            }

            return State.RUNNING;
        }
    }
}


