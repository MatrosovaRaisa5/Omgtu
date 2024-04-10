with open("input_s1_04.txt") as f:
    words = f.readline().split() 
    n = len(words)  
    conv = [""] * n  
    num = n - (n % 2) - 1 
    flip = False 
    for w in words:  
        word = w 
        k = len(w) - 1
        nw = [""] * len(w) 
        if len(w) % 2 != 0:
            word = word[::-1]
        for j in range(len(w)):
            nw[k] = word[0]
            word = word.replace(word[0], "", 1)[::-1]
            k -= 1
        conv[num] = "".join(nw)
        if not flip:
            num -= 2
        else:
            num += 2
        if num < 0:
            num = 0
            flip = True
    print(" ".join(conv))