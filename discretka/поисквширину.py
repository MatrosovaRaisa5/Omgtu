from collections import deque

n = int(input('Введите количество вершин: '))
m = int(input('Введите количество ребер: '))

print('Введите названия вершин:')
vertex_names = [input(f'Название вершины {i+1}: ') for i in range(n)]

name_to_index = {name: i for i, name in enumerate(vertex_names)}

matrix = [[0] * n for _ in range(n)]

print('Введите ребра в формате название1 название2:')
for _ in range(m):
    start_name, end_name = input().split()
    
    start = name_to_index[start_name]
    end = name_to_index[end_name]

    matrix[start][end] = matrix[end][start] = 1

print('Матрица смежности: ')
print(matrix)

def breadth_first_search(matrix, start_vertex):
    n = len(matrix)
    visited = [False] * n
    queue = deque([start_vertex])
    visited[start_vertex] = True
    component = []
    
    while queue:
        current = queue.popleft()
        component.append(current)
        for neighbor in range(n):
            if matrix[current][neighbor] == 1 and not visited[neighbor]:
                queue.append(neighbor)
                visited[neighbor] = True
    return component

def find_connected_components(matrix):
    n = len(matrix)
    visited = [False] * n
    components = []
    
    for vertex in range(n):
        if not visited[vertex]:
            component = breadth_first_search(matrix, vertex)
            components.append(component)
            for v in component:
                visited[v] = True
                
    return components

connected_components = find_connected_components(matrix)
print("Компоненты связности:")
for component in connected_components:
    print([vertex_names[i] for i in component])