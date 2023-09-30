using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Flow
{
    class Node
    {
        public int indexNode;
        public Dictionary<Node, Flow> inComing = new Dictionary<Node, Flow>();
        public Dictionary<Node, Flow> outComing = new Dictionary<Node, Flow>();
    }
}