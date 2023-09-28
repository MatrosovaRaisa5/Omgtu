milkpm = 1000000000000000000.00
firms = 0
N=int(input()) 


for i in range(N):
   f = input()
   x1, y1, z1, x2, y2, z2, p1, p2 = [float(s) for s in f.split()]
   v1 = x1*y1*z1
   s1 = (2*x1*y1)+(2*y1*z1)+(2*z1*x1)
   v2 = x2*y2*z2
   s2 = (2*x2*y2)+(2*y2*z2)+(2*z2*x2)
   milkp = (p2*s1-p1*s2)/(v2*s1-v1*s2)

   if milkp < milkpm:
       milkpm = milkp
       firms = i+1

milkpm = round(milkpm*1000, 2)
print(firms, milkpm)



