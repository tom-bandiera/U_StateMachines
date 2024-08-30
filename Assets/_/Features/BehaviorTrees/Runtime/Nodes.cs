using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTrees.Runtime
{
    public class Node
    {
        public enum Status { Success, Failure, Runnning }

        public readonly string m_name;

        public readonly List<Node> m_children = new();
        protected int _currentChildIndex;

        public Node(string name = "Node")
        {
            this.m_name = name;
        }

        public void AddChild(Node child) => m_children.Add(child);

        public virtual Status Process() => m_children[_currentChildIndex].Process();

        public virtual void Reset()
        {
            _currentChildIndex = 0;
            foreach (var child in m_children)
            {
                child.Reset();
            }
        }
    }

    public class Leaf : Node
    {
        private readonly IStrategy _strategy;

        public Leaf(string name, IStrategy strategy) : base(name)
        {
            _strategy = strategy;
        }

        public override Status Process() => _strategy.Process();

        public override void Reset() => _strategy.Reset();
    }

    public class BehaviorTree : Node
    {
        public BehaviorTree(string name) : base(name) { }

        public override Status Process()
        {
            while (_currentChildIndex < m_children.Count)
            {
                var status = m_children[_currentChildIndex].Process();

                if (status != Status.Success)
                {
                    return status;
                }

                _currentChildIndex++;
            }

            return Status.Success; 
        }
    }
}
