using BehaviorTree.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}


