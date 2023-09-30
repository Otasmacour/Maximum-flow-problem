# Maximum-flow-problem
Implementation of Ford-Fulkerson Algorithm
# What the input should look like
The input describes an oriented graph, in the following format:
- On the first line is the number of nodes  
- On n lines are numbers e, that tell, how many edges are coming out of the nth node, followed by the e of the edges in format "index number of that node (where the edge is pointing) + the capacity of the edge"  
- The last line shows the source and the sink, in format "source index number + sink index number"
# Example of correct input
```txt
7 
2 2 1 1 3
2 3 2 6 1 
1 3 10 
2 4 10 6 2
1 6 10
2 0 3 2 10 
0
5 6
```
# What does the output look like
- On the first line is the result, that tells us, what is the maximum possible flow in the graph
- The e lines (number of edges in the graph) contain information that informs us about the final flow of that edge in format "From + starting node index number + to + destination node index number + - + current flow(of that edge)/capacity(of that edge)"
# What the output for the above input looks like
```txt
Max flow is - 13
From 0 to 2 - 0/1
From 0 to 1 - 3/3
From 1 to 3 - 2/2
From 1 to 6 - 1/1
From 2 to 3 - 10/10
From 3 to 4 - 10/10
From 3 to 6 - 2/2
From 4 to 6 - 10/10
From 5 to 0 - 3/3
From 5 to 2 - 10/10
```
