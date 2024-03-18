# ����-�������
def ford_b(graph, start):
    dist = {}
    for versh in graph:
        dist[versh] = float('inf')
    dist[start] = 0
    
    for i in range(len(graph) - 1):
        for u in graph:
            for v, w in graph[u]:
                if dist[u] + w < dist[v]:
                    dist[v] = dist[u] + w
    
    for u in graph:
        for v, w in graph[u]:
            if dist[u] + w < dist[v]:
                print("���� �������� ���� �������������� ����")
                return None

    return dist

graph = {
    'P': [('Q', 2), ('R', 4)],
    'Q': [('S', 2)],
    'R': [('S', 4), ('T', 3)],
    'S': [],
    'T': [('S', -5)] 
}

start = 'P'
dist = ford_b(graph, start)

if dist is not None:
    for versh in dist:
        print("���������� ��", start, "��", versh, "�����", dist[versh])
