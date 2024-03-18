using System;
using System.Collections.Generic;
using System.Globalization;

class CallInfo {
    public string FromNumber;
    public string ToNumber;
    public DateTime CallDate;
    public int Minutes;
}

class Program {
    static void Main() {
        var callRecords = new List<CallInfo>();
        Console.WriteLine("Введите данные о звонках (формат: 'откуда куда дата(yyyy-MM-dd) длительность'), и 'end' для завершения ввода:");

        string input;
        while ((input = Console.ReadLine()) != "end") {
            var parts = input.Split(' ');
            if (parts.Length == 4) {
                callRecords.Add(new CallInfo {
                    FromNumber = parts[0],
                    ToNumber = parts[1],
                    CallDate = DateTime.ParseExact(parts[2], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Minutes = int.Parse(parts[3])
                });
            } else {
                Console.WriteLine("Неверный формат ввода, попробуйте еще раз.");
            }
        }

        Console.WriteLine("Введите номер абонента для поиска наиболее часто вызываемого номера:");
        var subscriber = Console.ReadLine();


        var callCounts = new Dictionary<DateTime, Dictionary<string, int>>();
        foreach (var call in callRecords) {
            if (call.FromNumber == subscriber) {
                if (!callCounts.ContainsKey(call.CallDate)) {
                    callCounts[call.CallDate] = new Dictionary<string, int>();
                }

                var dailyCalls = callCounts[call.CallDate];
                if (!dailyCalls.ContainsKey(call.ToNumber)) {
                    dailyCalls[call.ToNumber] = 0;
                }

                dailyCalls[call.ToNumber]++;
            }
        }

        foreach (var dateCalls in callCounts) {
            int maxCount = 0;
            string ChastNumber = null;
            foreach (var numberCount in dateCalls.Value) {
                if (numberCount.Value > maxCount) {
                    maxCount = numberCount.Value;
                    ChastNumber = numberCount.Key;
                }
            }
            Console.WriteLine($"Дата: {dateCalls.Key:d}, Чаще всего звонили на: {ChastNumber}");
        }

        Console.WriteLine("Введите дату для отображения номера с наибольшей длительностью разговора (формат: yyyy-MM-dd):");
        var specificDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var callDurations = new Dictionary<string, Dictionary<string, int>>();
        foreach (var call in callRecords) {
            if (call.CallDate.Date == specificDate) {
                if (!callDurations.ContainsKey(call.FromNumber)) {
                    callDurations[call.FromNumber] = new Dictionary<string, int>();
                }

                var fromDurations = callDurations[call.FromNumber];
                if (!fromDurations.ContainsKey(call.ToNumber)) {
                    fromDurations[call.ToNumber] = 0;
                }

                fromDurations[call.ToNumber] += call.Minutes;
            }
        }

        foreach (var fromDuration in callDurations) {
            int maxDuration = 0;
            string numberWithMaxDuration = null;
            foreach (var toDuration in fromDuration.Value) {
                if (toDuration.Value > maxDuration) {
                    maxDuration = toDuration.Value;
                    numberWithMaxDuration = toDuration.Key;
                }
            }
            Console.WriteLine($"Абонент: {fromDuration.Key}");
            Console.WriteLine($"Больше всего говорил с {numberWithMaxDuration}, {maxDuration} минут");
        }
    }
}