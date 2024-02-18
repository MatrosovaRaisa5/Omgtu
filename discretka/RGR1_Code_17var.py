import os
from queue import PriorityQueue

def menu():
    print("����:")
    print("1. ���������� �� ������")
    print("2. ������� ������")
    print("3. ������ �������� ���������")
    print("4. ����� �� ���������")
    choice = input("�������� ����� ����: ")   
    if choice == "1":
        print()
        print("���������� �� ������")
        print("���: ��������� ����� ����������")
        print("�����������, ���������, ������: �����, ������, ���-232")
        print()
        menu()    
    elif choice == "2":
        print()
        print("������� ������. � ������ ��������� �� ������� ����������� ���������� ����� ����� ��������� � ����������� �� ��������� ��������� ��������.")
        print()
        menu()         
    elif choice == "3":
        print("������ �������� ���������")
        print()
        programma()
    elif choice == "4":
        print("����� �� ���������.")
        os.system('clear')
    else:
        print("������ �������� ����� ����. ���������� �����.")
        print()
        menu()
        
        
def programma(): 
    while True:
        num_stations = int(input("������� ���������� �������: "))
        if 1 <= num_stations <= 100:
            break
        else:
            print("������������ ���������� �������! ���������� ��� ���! ������� ����� � ���������� [1,100] !")
    
    companies = []
    for i in range(3):
        print(f"\n{i+1} ��������:")
        connections = []
        while True:
            input_data = input("������� ������� � ��������� ����� ������ (������: A B 3): ")
            input_parts = input_data.split()
            if len(input_parts) == 3:
                connection = (input_parts[0], input_parts[1], int(input_parts[2]))
                connections.append(connection)
                print("���������� ������� ���������!")
            else:
                print("������������ ������ ������! ���������� ��� ���!")
            cont = input("���������� ���� ������ ��� ���� ��������? (������� ��/���): ")
            if cont.lower() != "��":
                break
        companies.append(connections)
    
    start_station, end_station = input("\n������� ��������� � �������� ������� (������: A F): ").split()
    
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
    print(f"����������� ���������� ����� {start_station} � {end_station} ����� {min_distance}")
    
    menu()

menu()
