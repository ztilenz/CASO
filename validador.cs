using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana11_tema6
{
  internal class validador
  {
    public static int LeerEntero(string mensaje)
    {
      int valor;
      while (true)
      {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out valor))
        {
          if (valor < 0 || valor > 20)
          {
            Console.WriteLine("error: el valor es entre [0-20]");
            continue;
          }
          return valor;
        }
        Console.WriteLine("error: el valor debe ser numerico entero");
      }
    }
    public static double LeerDecimales(string mensaje)
    {
      double valor;
      while (true)
      {
        Console.Write(mensaje);
        if (double.TryParse(Console.ReadLine(), out valor))
        {
          if (valor < 0 || valor > 20)
          {
            Console.WriteLine("error: la nota es entre [0-20]");
            continue;
          }
          return valor;
        }
        Console.WriteLine("error: el valor debe de ser numerico decimal");
      }
    }
    public static string LeerTexto(string mensaje)
    {
      while (true)
      {
        Console.Write(mensaje);
        string texto = Console.ReadLine()?.Trim();
        if(!string.IsNullOrEmpty(texto))
          return texto;
        Console.WriteLine("error: este cam po no puede estar vacio !!!");
      }
    }
  }
}