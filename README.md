# Maximum-flow-problem
Implementation of Ford-Fulkerson Algorithm
input is read in the format:
# What the input should look like
The input describes an oriented graph, in the following format:
- On the first line is the number of nodes  
- On n lines are edge inputs based on the nth node in format "index number of that node (where the edge is pointing) + edge capacity"  
- The last line shows the source and sink, in format "index number of source + index number of sink"
Example of correct input:
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
