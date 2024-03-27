def ford_bellman(graph, start):
    dist = {}
    pred = {}  
    for versh in graph:
        dist[versh] = float('inf')
        pred[versh] = None
    dist[start] = 0
    
    for i in range(len(graph) - 1):
        for u in graph:
            for v, w in graph[u]:
                if dist[u] + w < dist[v]:
                    dist[v] = dist[u] + w
                    pred[v] = u  
    
    # Проверка на наличие контура отрицательного веса
    for u in graph:
        for v, w in graph[u]:
            if dist[u] + w < dist[v]:
                print("Граф содержит цикл отрицательного веса")
                return None, None

    return dist, pred

def reconstruct_path(start, end, pred):
    #Восстановление пути
    path = []
    current = end
    while current is not None:
        path.append(current)
        current = pred[current]
    path.reverse() 
    return path
    
graph = {
    'A': [('B', 1), ('E', 3)],
    'B': [('C', 8), ('D', 7), ('E', 1)],
    'C': [('D', 1), ('E', -5)],
    'D': [('C', 2)],
    'E': [('D', 4)] 
}

start = 'A'
dist, pred = ford_bellman(graph, start)

if dist is not None:
    for versh in dist:
        print("Расстояние от", start, "до", versh, "равно", dist[versh])
   
    print("Путь от", start, "до 'A':", reconstruct_path(start, 'A', pred))
    print("Путь от", start, "до 'B':", reconstruct_path(start, 'B', pred))
    print("Путь от", start, "до 'C':", reconstruct_path(start, 'C', pred))
    print("Путь от", start, "до 'D':", reconstruct_path(start, 'D', pred))
    print("Путь от", start, "до 'E':", reconstruct_path(start, 'E', pred))
    
else:
    print("В графе присутствует цикл отрицательного веса.")
