def input_graph():
    n = int(input("Введите количество вершин: "))
    matrix = []

    for i in range(n):
        print(f"Введите строку {i + 1} матрицы смежности, разделенную пробелами (0 - если соединения нет):")
        m = list(map(int, input().split()))
        if len(m) != n:
            print(f"Строка должна содержать {n} чисел. Попробуйте ввести строку {i + 1} снова.")
            return input_graph()
        matrix.append(m)

    for i in range(n):
        for j in range(n):
            if i != j and matrix[i][j] == 0:
                matrix[i][j] = float('infinity')

    return n, matrix

def dijkstra(n, matrix, start):
    short = [float('infinity')] * n
    short[start] = 0
    visited = set()
    parents = [-1] * n  
  
    while len(visited) < n:
        min = None
        for versh in range(n):
            if versh  not in visited:
                if min is None or short[versh] < short[min]:
                    min = versh 

        if min is None:
            break  

        visited.add(min)
        for versh in range(n):
            if matrix[min][versh] != float('infinity'):
                distance = matrix[min][versh]
                if short[min] + distance < short[versh]:
                    short[versh] = short[min] + distance
                    parents[versh] = min 
  
    return short, parents

def restore_path(parents, finish):
    path = []
    while finish != -1:
        path.append(finish + 1) 
        finish = parents[finish]
    path.reverse()  
    return path

n, matrix = input_graph()
start = int(input("Введите стартовую вершину (отсчет с 1): ")) - 1
if start < 0 or start >= n:
    print("Стартовая вершина вне допустимого диапазона. Попробуйте снова.")
else:
    short, parents = dijkstra(n, matrix, start)
    
    for versh, distance in enumerate(short):
        if distance == float('infinity'):
            print(f"Вершина {start + 1} не имеет пути к вершине {versh + 1}")
        else:
            path = restore_path(parents, versh)
            print(f"Кратчайшее расстояние от вершины {start + 1} до вершины {versh + 1} равно {distance}, Path: {' -> '.join(map(str, path))}")
