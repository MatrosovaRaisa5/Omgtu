#1
P = [1, 2, 3, 20]

n = 5
l = 7
m = 10

for i in range(len(P)):
    k = P[i]

    s = 0
    
    for j in range(k):
        s += 2*l + 2*n + 2*m + j*2*m
    print(P[i], '-', s)
    
print()

#2
for i in range(len(P)):
    k = P[i]
    
    s = 2*l*k + 2*n*k + (k**2 + k)*m

    print(P[i], "-", s)
