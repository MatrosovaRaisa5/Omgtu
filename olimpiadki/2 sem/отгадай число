with open('input_s1_01.txt', 'r') as f:
    lines = f.readlines()
N = int(lines[0].strip())

R = int(lines[-1].strip())

a = 1
b = 0

for i in range(1, N + 1):
    action, value = lines[i].split()
    if 'x' in value:
        num = int(value.replace('x', '') or '1')
        if action == "+":
            a += num
        elif action == "-":
            a -= num
        elif action == "*":
            a *= num
            b *= num
    else:
        value = int(value)
        if action == "+":
            b += value
        elif action == "-":
            b -= value
        elif action == "*":
            a *= value
            b *= value

if (R - b) % a == 0:
    X = (R - b) // a
    print(X)
else:
    print("Нет решения")
