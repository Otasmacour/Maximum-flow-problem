# Maximum-flow-problem
Implementation of Ford-Fulkerson Algorithm
input is read in the format:
# What the input should look like
The input describes an oriented graph, in the following format:
- On the first line is the number of nodes  
- On n lines are edge inputs based on the nth node in format "index number of that node (where the edge is pointing) + edge capacity"  
- The last line shows the source and sink, in format "index number of source + index number of sink"
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
- The e lines (number of edges in the graph) contain information that informs us about the final flow of that edge in format "From + index number of the starting node + to + index number of the destination node + - + current flow(of that edge)/capacity(of that edge)"
# What the output for the above input looks like
```txt
Max flow is - 13
The state of the flows in the graph at the end:
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
