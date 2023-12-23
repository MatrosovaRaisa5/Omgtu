from datetime import date

data1=input().split('.')
d1 = int(data1[0])
m1 = int(data1[1])
y1 = int(data1[2])

data2=input().split('.')
d2 = int(data2[0])
m2 = int(data2[1])
y2 = int(data2[2])

p = int(input())

summa = 0

k0 = date(y1, m1, d1)
k1 = date(y2, m2, d2)
delta = k1 - k0
print("Сколько всего дней проходит интенсификация", delta.days+1)
for i in range(0, delta.days +1):
    summa+=p
    p+=1
print("Объем произведенной продукции", summa)
