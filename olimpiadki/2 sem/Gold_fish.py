//работают не все тесты
f = open('input_s1_01.txt')
f = f.readlines()
n = int(f[0])
k = -1
words = []
for i in f:
    k += 1
    if k > n:
        gg = i
        break
    if k > 0:
        words.append(i[:-1])
gg = int(gg)
k = -1
start = []
for i in f:
    k += 1
    if k > n + gg + 1:
        l = i
        break
    if k > n + 1:
        start.append(i[:-1])
l = int(l)
final = []
k = -1
for i in f:
    k += 1
    if k > n + gg + 2 and k < n + gg + l + 2:
        final.append(i[:-1])
final.append(i)
startn = []
for i in start:
    for j in range(1,int(i[2:]) + 1):
        startn.append(i[0])
finaln = []
for i in final:
    for j in range(1,int(i[2:]) + 1):
        finaln.append(i[0])
k = 0
ans = 0
wordsn = []
for i in words:
    if ((i[0] in startn) and (i[-1] in finaln)):
        ans +=1
        startn.remove(i[0])
        finaln.remove(i[-1])
        wordsn.append(i)
print(ans)
