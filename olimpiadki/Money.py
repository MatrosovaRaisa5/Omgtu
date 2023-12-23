p = list(map(int, input().split()))
n1, c1 = p[0], p[1:]
p = list(map(int, input().split()))
unluckyCount1, unluckyNumbers1 = p[0], p[1:]
p = list(map(int, input().split()))
n2, c2 = p[0], p[1:]
p = list(map(int, input().split()))
unluckyCount2, unluckyNumbers2 = p[0], p[1:]
startMoney = list(map(int, input().split()))
endMoney = [0] * n2

unluckyNumbers1.sort(reverse=True)
unluckyNumbers2.sort(reverse=True)

for i in unluckyNumbers1:
    for j in range(0, len(startMoney)):
        if startMoney[j] > i: startMoney[j] -= 1

for i in range(0, len(startMoney) - 1):
    startMoney[i+1] += startMoney[i] * c1[i]

for i in range(0, len(endMoney)):
    if i == 0: endMoney[-1] = startMoney[-1]
    else:
        endMoney[len(endMoney)- 1 - i] = endMoney[len(endMoney)- i] // c2[-i]
        endMoney[len(endMoney) - i] %= c2[-i]

unluckyNumbers1.sort()
unluckyNumbers2.sort()

for i in unluckyNumbers2:
    for j in range(0, len(endMoney)):
        if endMoney[j] >= i: endMoney[j] += 1

print(" ".join(str(i) for i in endMoney))
