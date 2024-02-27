MaxN = int(input())
sum = 0
for x in [2**n for n in range(1, 100)]:
    sum += int((MaxN/(x-1)))
print(sum)