def floyd(weights):
    n = len(weights)
    next = [[None if i != j and weights[i][j] == float('inf') else j for j in range(n)] for i in range(n)]

    for i in range(n):
        for j in range(n):
            if weights[i][j] == 0:
                weights[i][j] = float('inf')

    for k in range(n):
        for i in range(n):
            for j in range(n):
                if weights[i][k] + weights[k][j] < weights[i][j]:
                    weights[i][j] = weights[i][k] + weights[k][j]
                    next[i][j] = next[i][k]

    return weights, next

def reconstruct_path(u, v, next):
    if next[u][v] == None:
        return []
    path = [u]
    while u != v:
        u = next[u][v]
        path.append(u)
    return path

def main():
    print("Введите количество вершин:")
    n = int(input())
    
    print(f"Введите матрицу смежности {n}x{n} построчно через пробел:")
    weights = []
    for i in range(n):
        row = list(map(int, input().split()))
        weights.append(row)
    
    shortest_paths, next = floyd(weights)
    
    print("Матрица кратчайших путей между всеми парами вершин:")
    for row in shortest_paths:
        print(" ".join(map(str, row)))

    print("Введите номер вершины из которой выходим:")
    a1 = int(input())-1
    print("Введите номер вершины в которую идём:")
    a2 = int(input())-1
    if a1 != a2:
        path = reconstruct_path(a1, a2, next)
        print(f"Восстановленный путь от {a1+1} до {a2+1}: {' -> '.join(map(lambda x: str(x+1), path))}")

main()
