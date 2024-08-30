namespace BehaviorTree.Runtime
{
    internal class CheckIfValueIsLessThanNode : Leaf
    {
        private Enemy value;
        private int v;

        public CheckIfValueIsLessThanNode(Enemy value, int v)
        {
            this.value = value;
            this.v = v;
        }

        public override State Process()
        {
            return this.value._value < this.v ? State.SUCCESS : State.FAIL;
        }
    }
}