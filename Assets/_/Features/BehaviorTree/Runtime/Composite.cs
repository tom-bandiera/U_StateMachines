using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public abstract class Composite : NodeBase
    {
        public List<NodeBase> m_children = new List<NodeBase>();
        protected int m_index;

        public override abstract State Process();
    }
}
