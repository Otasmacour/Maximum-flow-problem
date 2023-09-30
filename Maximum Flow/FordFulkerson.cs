using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Flow
{
    class FordFulkerson
    {
        Graph graph;
        public int Solve(string inputPath) 
        {
            this.graph = new Graph(inputPath);
            bool run = true;
            while (run)
            {
                List<int> path = BFS(graph.nodes, graph.source, graph.sink);
                if(path.Count > 0) //The path exists
                {
                    FlowAdjustment(graph.nodes, path);
                }
                else
                {
                    int result = Result(graph.sink);
                    return result;
                }
            }
            PrintFlows();
            return 0;
        }
        public void PrintFlows()
        {
            foreach(Node node in  graph.nodes)
            {
                foreach(var item in node.outComing)
                {
                    Console.WriteLine("From " + node.indexNode.ToString()+" to "+item.Key.indexNode.ToString()+" - "+item.Value.currentFlow.ToString()+"/"+item.Value.capacity.ToString());
                }
            }
        }
        int Result(Node sink)
        {
            int maxFlow = 0;
            foreach(Flow flow in sink.inComing.Values)
            {
                maxFlow += flow.currentFlow;
            }
            return maxFlow;
        }
        static void FlowAdjustment(List<Node> nodes, List<int> path)
        {
            int bottleNeckKapacity = path[path.Count - 1];
            for (int i = 0; i < path.Count - 2; i++)
            {
                Node current = nodes[path[i]];
                Node predecessor = nodes[path[i + 1]];
                if (predecessor.outComing.ContainsKey(current))
                {
                    Flow flow = predecessor.outComing[current];
                    flow.currentFlow += bottleNeckKapacity;

                }
                else
                {
                    Flow flow = predecessor.inComing[current];
                    flow.currentFlow -= bottleNeckKapacity;
                }
            }
        }
        List<int> BFS(List<Node> nodes, Node source, Node sink)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(source);
            HashSet<Node> visited = new HashSet<Node>();
            Dictionary<Node, Node> predecessors = new Dictionary<Node, Node>();
            bool found = false;
            while (queue.Count != 0 & found == false)
            {
                Node node = queue.Dequeue();
                foreach (var item in node.outComing)
                {
                    Node adjacent = item.Key;
                    Flow flow = item.Value;
                    if (visited.Contains(adjacent) == false & flow.capacity - flow.currentFlow > 0)
                    {
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                        predecessors[adjacent] = node;
                        if (adjacent == sink)
                        {
                            found = true;
                        }
                    }
                }
                foreach (var item in node.inComing)
                {
                    Node adjacent = item.Key;
                    Flow flow = item.Value;
                    if (visited.Contains(adjacent) == false & flow.currentFlow > 0)
                    {
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                        predecessors[adjacent] = node;
                    }
                }
            }
            List<int> path = new List<int>();
            // Nodes Sink=>Source the last int is bottleNeckKapacity
            if (found)
            {
                Node current = sink;
                Flow floww = predecessors[current].outComing[current];
                int smallest = floww.capacity - floww.currentFlow;
                while (current != source)
                {
                    path.Add(current.indexNode);
                    Node predecessor = predecessors[current];
                    if (predecessor.outComing.ContainsKey(current))
                    {
                        Flow flow = predecessors[current].outComing[current];
                        if (flow.capacity - flow.currentFlow < smallest)
                        {
                            smallest = flow.capacity - flow.currentFlow;
                        }
                        current = predecessors[current];
                    }
                    else if (predecessor.inComing.ContainsKey(current))
                    {
                        Flow flow = predecessors[current].inComing[current];
                        if (flow.currentFlow < smallest)
                        {
                            smallest = flow.currentFlow;
                        }
                        current = predecessors[current];
                    }
                }
                path.Add(current.indexNode);
                path.Add(smallest);
            }
            return path;
        }
    }
}