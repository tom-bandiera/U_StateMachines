using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Runtime
{
    public class Sequence : Composite
    {
        public override State Process()
        {
            var childState = m_children[m_index].Process();

            if (childState == State.SUCCESS)
            {
                m_index++;
                if (m_index >= m_children.Count)
                {
                    m_index = 0;
                    return State.SUCCESS;
                }

                return State.RUNNING;
            }

            if (childState == State.FAIL)
            {
                m_index = 0;
                return State.FAIL;
            }

            return State.RUNNING;
        }
    }

}
