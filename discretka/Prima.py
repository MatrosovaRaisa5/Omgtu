import sys
import heapq

def prim(graph, starting_vertex):
    mst = []
    visited = set([starting_vertex])
    edges = [
        (cost, starting_vertex, to)
        for to, cost in graph[starting_vertex].items()
    ]
    heapq.heapify(edges)

    while edges:
        cost, from_vert, to_vert = heapq.heappop(edges)
        if to_vert not in visited:
            visited.add(to_vert)
            mst.append((from_vert, to_vert, cost))

            for to_next, cost in graph[to_vert].items():
                if to_next not in visited:
                    heapq.heappush(edges, (cost, to_vert, to_next))
    return mst

num_vertices = int(input("������� ���������� ������: "))
num_edges = int(input("������� ���������� ������: "))

graph = {str(i): {} for i in range(num_vertices)}

print("������� �������� ������:")
for _ in range(num_vertices):
    vertex = input()
    graph[vertex] = {}
print("������� ����� � ������� '��������� �������', '�������� �������', '���':")
for _ in range(num_edges):
    start, end, weight = input().split()
    weight = int(weight)
    graph[start][end] = weight
    graph[end][start] = weight
starting_vertex = input("������� ��������� �������: ")
mst = prim(graph, starting_vertex)

print("����������� �������� ������:")
summ=0

for from_vert, to_vert, cost in mst:
    print(f"{from_vert} - {to_vert} : {cost}")
    summ+=cost

print(summ)
