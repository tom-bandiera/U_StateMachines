using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public class AllNodesCheckSelector : Composite
    {
        // 
        public override State Process()
        {
            foreach (var child in m_children)
            {
                var state = child.Process();

                Debug.Log(state);

                if (state == State.SUCCESS)
                {
                    return State.SUCCESS;
                }
                
                if (state == State.FAIL)
                {
                    continue;
                }

                return State.RUNNING;
            }

            return State.FAIL;
        }
    }
}
