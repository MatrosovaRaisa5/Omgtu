from collections import deque

def search(rGraph, s, t, pred):
    visited = [False] * len(rGraph)
    queue = deque()
    queue.append(s)
    visited[s] = True
    
    while queue:
        u = queue.popleft()
        
        for ind, val in enumerate(rGraph[u]):
            if visited[ind] == False and val > 0:
                queue.append(ind)
                visited[ind] = True
                pred[ind] = u
            
    return visited[t]

def ford_fulkerson(graph, source, sink):

    pred = [-1] * len(graph)
    max_flow = 0

    rGraph = [row[:] for row in graph]

    while search(rGraph, source, sink, pred):
        path_flow = float("Inf")
        s = sink
        
        while(s != source):
            path_flow = min(path_flow, rGraph[pred[s]][s])
            s = pred[s]

        v = sink
        while(v != source):
            u = pred[v]
            rGraph[u][v] -= path_flow
            rGraph[v][u] += path_flow
            v = pred[v]
            
        max_flow += path_flow
    
    return max_flow

graph = [[0, 16, 13, 0, 0, 0],
         [0, 0, 10, 12, 0, 0],
         [0, 4, 0, 0, 14, 0],
         [0, 0, 9, 0, 0, 20],
         [0, 0, 0, 7, 0, 4],
         [0, 0, 0, 0, 0, 0]] 

source = 0
sink = 5

print("Максимальный поток:", ford_fulkerson(graph, source, sink))
