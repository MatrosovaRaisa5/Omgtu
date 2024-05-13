def komv(graph, start=1):
    all_nodes = list(range(1, len(graph)+1))
    all_nodes.remove(start)
    min_path = float('inf')
    min_path_order = None

    def depth_search(node, visited, path, cost):
        nonlocal min_path, min_path_order
        if len(visited) == len(all_nodes) + 1:
            if graph[node-1][start-1] != 0 and cost + graph[node-1][start-1] < min_path:
                min_path = cost + graph[node-1][start-1]
                min_path_order = [node] + path + [node]
            return

        for next_node in all_nodes:
            if next_node not in visited and graph[node-1][next_node-1] != 0:
                depth_search(next_node, visited.union({next_node}), path + [node], cost + graph[node-1][next_node-1])

    depth_search(start, {start}, [], 0)

    return min_path, min_path_order

graph =  [
    [0, 41, 17, 23, 32],
    [13, 0, 45, 12, 37],
    [80, 45, 0, 50, 64],
    [23, 12, 50, 0, 67],
    [32, 37, 64, 67, 0]
]

min_path, min_path_order = komv(graph)
print(f"Минимальный путь: {min_path}")
print(f"Путь: {min_path_order}")
