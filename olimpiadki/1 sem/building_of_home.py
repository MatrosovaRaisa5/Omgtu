s1 = s2 = s3 = s4 = s5 = s6 = su1 = su2 = su3 = m = m1 = m2 = 0
x, y, l, c1, c2, c3, c4, c5, c6 = map(int, input().split())
P = (x+y)*2 
    
if l > max(x, y):
    
    p1=P
    s1+=(l-x)*c2 + (l-x)*c3
    p1-=(l-x) + x 
    s1+= x*c1 + p1*c5 + p1*c4
        
    p2=P
    s2+=(l-y)*c2 + (l-y)*c3
    p2-=(l-y) + y
    s2+= y*c1 + p2*c5 + p2*c4
            
    p3=P
    s3=l*c2 + l*c6 + p3*c4 + p3*c5
            
    p4=P
    s4+=(l-x)*c2 
    p4-= x
    s4+= x*c1+ (l-x)*c6 + p4*c5 + p4*c4
            
    p5=P
    s5+=(l-y)*c2 
    p5-= y
    s5+= y*c1+ (l-y)*c6 + p5*c5 + p5*c4
    
    p6=P
    s6 += l * c2
    p6 -= l
    s6 += l*c3 + p6*c4 + p6*c5
    
    if l>=P:    
        s1 += (l-p)*c6 + (l-p)*c2
        s2 += (l-p)*c6 + (l-p)*c2
        s3 += (l-p)*c6 + (l-p)*c2
        s4 += (l-p)*c6 + (l-p)*c2
        s5 += (l-p)*c6 + (l-p)*c2
        su1 += (l-p)*c6 + (l-p)*c2
        su2 += (l-p)*c6 + (l-p)*c2
        su3 += (l-p)*c6 + (l-p)*c2
            
    print(min(s1, s2, s3, s4, s5, s6))

if l < max(x, y):
    
    pe1=P
    pe1-=l 
    su1+=c1*l + pe1*c4 + pe1*c5
    
    pe2=P
    su2=l*c2 + l*c3
    pe2-=l
    su2+=pe2*c4 + pe2*c5    
    
    pe3=P
    su3 += l * c2 + l*c6 + pe3 * c5 + pe3 * c4

    print(min(su1, su2, su3))
