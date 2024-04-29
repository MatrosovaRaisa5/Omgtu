using System;
using System.Collections.Generic;
using System.Linq;
class HelloWorld {
  static void Main() {
    List<string> element = new List<string>() { "ghfgfhgdfh", "hjh", "yuyu", "jhdkjshf", "uyruey", "tert", "ioio", "eiei", "adsds", "tyrte" };
    Console.WriteLine("Первый прогон");
    Chetnost(element);
    for (int i = 1; i <= element.Count; i++){
        if (i%2 == 0)
        {
            element.Remove(element[i]);
        }
    }
    Console.WriteLine("");
    Console.WriteLine("Второй прогон");
    Chetnost(element);
    }
     static void Chetnost(List<string> element)
    {
        var result = element.Where(e => e.Length%2==0).Select(e => e);
        foreach (string i in result){
        Console.Write(i+"   ");
    }
  }
}
