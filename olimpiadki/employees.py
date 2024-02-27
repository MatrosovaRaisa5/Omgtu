[16:37, 27.02.2024] Раиса: employees = {}
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

    for subordinate in subordinates:
        print(f"{subordinate}: {employees[subordinate]['name'] or 'unknown name'}")

manager_input = input("Введите начальника: ")
subordinate_input = input("Введите подчиненного: ")

while manager_input.upper() != "END":
    manager_num, manager_name = manager_input.split(maxsplit=1) + [None] if ' ' not in manager_input else manager_input.split(maxsplit=1)
    subordinate_num, subordinate_name = subordinate_input.split(maxsplit=1) + [None] if ' ' not in subordinate_input else subordinate_input.split(maxsplit=1)   
    add_employee(manager_num, manager_name, None)
    add_employee(subordinate_num, subordinate_name, manager_num)

    manager_input = input("Введите начальника: ")
    if manager_input.upper() == "END":
        break
    subordinate_input = input("Введите подчиненного: ")

manager_identifier = input("Введите номер или имя начальника, чтобы увидеть подчиненных: ")
get_subordinates(manager_identifier)
    