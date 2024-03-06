employees = {}

manager_subordinates = {}
def add_employee(emp_num, emp_name, manager_num):
    if emp_num not in employees:
        employees[emp_num] = {'name': emp_name, 'manager': manager_num}
    else:
        if emp_name:
            employees[emp_num]['name'] = emp_name
    if manager_num:
        if manager_num in manager_subordinates:
            manager_subordinates[manager_num].add(emp_num)
        else:
            manager_subordinates[manager_num] = {emp_num}
            
def get_subordinates(manager_identifier):
    subordinates = set()
    def find_subordinates(mgr_num):
        if mgr_num in manager_subordinates:
            for sub in manager_subordinates[mgr_num]:
                subordinates.add(sub)
                find_subordinates(sub)
    if manager_identifier.isdigit():
        find_subordinates(manager_identifier)
    else:
        for emp_num, info in employees.items():
            if info['name'] == manager_identifier:
                find_subordinates(emp_num)
                break
    sorted_subordinates = sorted(subordinates, key=lambda sub: int(sub))
    for subordinate in sorted_subordinates:
        print(f"{subordinate}: {employees[subordinate]['name'] or 'unknown name'}")
        
with open("input_s1_01.txt", "r") as file:
    lines = file.readlines()
i = 0

while i < len(lines):
    line = lines[i].strip()
    i += 1
    if line.upper() == "END":
        break
    emp_num, emp_name = (line.split(maxsplit=1) + [None])[:2]
    add_employee(emp_num, emp_name, None)

while lines[-1].strip().upper() == "END":
    lines.pop()
manager_identifier = lines[-1].strip()

for i in range(0, len(lines) - 1, 2):
    manager_info = lines[i].strip()
    subordinate_info = lines[i + 1].strip()
    manager_num, manager_name = (manager_info.split(maxsplit=1) + [None])[:2]
    subordinate_num, subordinate_name = (subordinate_info.split(maxsplit=1) + [None])[:2]
    add_employee(manager_num, manager_name, None)
    add_employee(subordinate_num, subordinate_name, manager_num)
    
get_subordinates(manager_identifier)