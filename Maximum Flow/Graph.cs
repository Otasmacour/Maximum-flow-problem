using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Flow
{
    class Graph
    {
        public List<Node> nodes = new List<Node>();
        public Node source;
        public Node sink;
        public Graph(string inputPath) 
        {
            List<string> input = LoadingInput(inputPath);
            CreateGraph(input);
        }
        List<string> LoadingInput(string path)
        {
            List<string> input = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            return input;
        }
        void CreateGraph(List<string> input)
        {
            int index = 0;
            int nodesNumber = int.Parse(input[index]);
            index++;
            for(int i = 0; i < nodesNumber; i++) 
            {
                Node node = new Node();
                node.indexNode = i;
                nodes.Add(node);
            }
            for(int i = 0;i < nodesNumber; i++)
            {
                string line = input[index].Trim(' ');
                index ++;
                List<int> lineOfNumbers = line.Split(' ').Select(int.Parse).ToList();
                int numberOfEdges = lineOfNumbers[0];
                for (int j = 1;j < numberOfEdges * 2; j += 2)
                {
                    Node start = nodes[i];
                    Node destination = nodes[lineOfNumbers[j]];
                    Flow flow = new Flow();
                    flow.capacity = lineOfNumbers[j + 1];
                    start.outComing.Add(destination, flow);
                    destination.inComing.Add(start, flow);
                }
            }
            List<int> SourceAndSink = input[index].Trim(' ').Split(' ').Select(int.Parse).ToList();
            source = nodes[SourceAndSink[0]];
            sink = nodes[SourceAndSink[1]];
            index++;
        }
    }
}