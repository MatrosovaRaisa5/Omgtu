import os
from queue import PriorityQueue

def menu():
    print("Меню:")
    print("1. Информация об авторе")
    print("2. Условие задачи")
    print("3. Работа основной программы")
    print("4. Выход из программы")
    choice = input("Выберите пункт меню: ")   
    if choice == "1":
        print()
        print("Информация об авторе")
        print("ФИО: Матросова Раиса Евгеньевна")
        print("Университет, факультет, группа: ОмГТУ, ФИТиКС, ФИТ-232")
        print()
        menu()    
    elif choice == "2":
        print()
        print("Условие задачи. В данной программе мы находим минимальное расстояние между двумя станциями в зависимости от маршрутов различных компаний.")
        print()
        menu()         
    elif choice == "3":
        print("Работа основной программы")
        print()
        programma()
    elif choice == "4":
        print("Выход из программы.")
        os.system('clear')
    else:
        print("Выбран неверный пункт меню. Попробуйте снова.")
        print()
        menu()
        
        
def programma(): 
    while True:
        num_stations = int(input("Введите количество станций: "))
        if 1 <= num_stations <= 100:
            break
        else:
            print("Неправильное количество станций! Попробуйте еще раз! Вводите числа в промежутке [1,100] !")
    
    companies = []
    for i in range(3):
        print(f"\n{i+1} компания:")
        connections = []
        while True:
            input_data = input("Введите станции и стоимость через пробел (пример: A B 3): ")
            input_parts = input_data.split()
            if len(input_parts) == 3:
                connection = (input_parts[0], input_parts[1], int(input_parts[2]))
                connections.append(connection)
                print("Соединение станций добавлено!")
            else:
                print("Неправильный формат данных! Попробуйте еще раз!")
            cont = input("Продолжить ввод связей для этой компании? (Введите да/нет): ")
            if cont.lower() != "да":
                break
        companies.append(connections)
    
    start_station, end_station = input("\nВведите начальную и конечную станции (пример: A F): ").split()
    
    graph = {}
    for company in companies:
        for connection in company:
            station1, station2, cost = connection
            if station1 not in graph:
                graph[station1] = {}
            if station2 not in graph:
                graph[station2] = {}
            graph[station1][station2] = cost
            graph[station2][station1] = cost
    
    def prim(graph,start):
        pq = PriorityQueue()
        visited = set()
        for neighbor,cost in graph[start].items():
            pq.put((cost,neighbor))
    
        visited.add(start)
        min_distance = 0
        while not pq.empty():
            cost,station = pq.get()
            if station not in visited:
                visited.add(station)
                min_distance += cost
                for neighbor,ncost in graph[station].items():
                    pq.put((ncost,neighbor))
        
        return min_distance
    
    min_distance = prim(graph,start_station)
    print(f"Минимальное расстояние между {start_station} и {end_station} равно {min_distance}")
    
    menu()

menu()
