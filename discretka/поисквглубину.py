def input_versh_names(n):
    names_to_ind = {}
    ind_to_names = {}
    for i in range(n):
        name = input(f'Введите название вершины {i+1}: ')
        names_to_ind[name] = i
        ind_to_names[i] = name
    return names_to_ind, ind_to_names
def dfs(versh, visited, matrix, component):
    visited[versh] = True
    component.append(versh)
    for i in range(len(matrix[versh])):
        if matrix[versh][i] == 1 and not visited[i]:
            dfs(i, visited, matrix, component)
def find_components(n, matrix):
    visited = [False] * n
    components = []
    for i in range(n):
        if not visited[i]:
            component = []
            dfs(i, visited, matrix, component)
            components.append(component)
    return components
n = int(input('Введите количество вершин: '))
versh_names, ind_to_names = input_versh_names(n)
m = int(input('Введите количество ребер: '))
matrix = [[0] * n for _ in range(n)]
print('Введите ребра в формате "начало конец" (используйте названия вершин):')
for _ in range(m):
    start_name, end_name = input().split()
    start = versh_names[start_name]
    end = versh_names[end_name]
    matrix[start][end] = matrix[end][start] = 1
components = find_components(n, matrix)
print('Компоненты связности графа:')
for i, component in enumerate(components):
    print(f'Компонента {i+1}: {" ".join(ind_to_names[v] for v in component)}')
