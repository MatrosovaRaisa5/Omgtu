n, m = map(int, input('������� ��� ����� -������� ������ � ����� (����� ������): \n').split())
edges = []
for i in range(m):
    start, end, weight = map(int, input('������� ��� ����� - ��� ������� � ��� (����� ������): ' '\n').split())
    edges.append([weight, start, end])
edges.sort()
comp = [i for i in range(n)]
ans = 0
for weight, start, end in edges:
    if comp[start-1] != comp[end-1]:
        ans += weight
        a = comp[start-1]
        b = comp[end-1]
        for i in range(n):
            if comp[i] == b:
                comp[i] = a
print(ans)
