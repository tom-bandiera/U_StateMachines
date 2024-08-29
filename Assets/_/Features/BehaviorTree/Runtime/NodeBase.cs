using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public abstract class NodeBase
    {
        public enum State
        {
            FAIL, SUCCESS, RUNNING
        }

        public abstract State Process();
    }
}
