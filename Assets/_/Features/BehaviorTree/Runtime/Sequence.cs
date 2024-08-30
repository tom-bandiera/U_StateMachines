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

            // SUCCESS
            if (childState == State.SUCCESS)
            {
                m_index++;
                // SUCCESS ON ALL NODES
                if (m_index >= m_children.Count)
                {
                    m_index = 0;
                    return State.SUCCESS;
                }

                // SUCCESS BUT STILL NODES TO CHECK, CONTINUE RUNNING
                return State.RUNNING;
            }

            // FAIL, END SEQUENCE AND RETURN FAIL
            if (childState == State.FAIL)
            {
                m_index = 0;
                return State.FAIL;
            }


            // NOT SUCCESS OR FAIL => CONTINUE RUNNING UNTIL FAIL OR SUCCESS
            return State.RUNNING;
        }
    }

}
