using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace caso_semana11_tema6
{
  internal class Program
  {
    static int max_estudiante = 40;
    static int max_cursos = 4;
    static string[] nombre_cursos = { "matematicas", "programacion", "fisica", "base de datos" };
    static string[] estudiante = new string[max_estudiante];
    static double[,] matrizNotas = new double[max_estudiante, max_cursos];
    static int total_estudiantes = 0;
    static string rutaArchivo = "notas_cursos.txt";
    public static void RegistrarEstudiante()
    {
      Console.WriteLine("REGISTRO DE ESTUDIANTE");
      if (total_estudiantes >= max_estudiante)
      {
        Console.WriteLine("Se alcanzo la capacidad maxima");
        return;
      }
      string nombre = validador.LeerTexto("Ingresar nombres y apellidos: ");
      estudiante[total_estudiantes] = nombre;
      Console.WriteLine("Ingresar las notas de 0 a 20: ");
      for (int i = 0; i < max_cursos; i++)
      {
        matrizNotas[total_estudiantes, i] = validador.LeerDecimales
          ($"ingresar nota de{nombre_cursos[i]}:");
      }
      total_estudiantes++;
      Console.WriteLine(" estudiante registrado !!!");
    }
    public static void guardarArchivo()
    {
      if(total_estudiantes==0)
      {
        Console.WriteLine("sin registros a guardar");
        return;
      }
      using(StreamWriter escritor=new StreamWriter(rutaArchivo))
      {
        for(int i = 0;i < max_estudiante;i++)
        {
          string linea= estudiante[i];
          for(int j = 0;j < max_cursos; j++)
          {
            linea += "," + matrizNotas[i, j];
          }
          escritor.WriteLine(linea);
        }
      }
      Console.WriteLine("registro guardados !!! ");
    }
    public static void cargarRegistros()
    {
      Console.WriteLine("cargar registros desde archivos");
      if(!File.Exists(rutaArchivo))
      {
        Console.WriteLine("no existe el archivor");
        return;
      }
      total_estudiantes = 0;
      using (StreamReader lector = new StreamReader(rutaArchivo))
      {
        string linea;
        while((linea = lector.ReadLine()) != null &&
         total_estudiantes < max_estudiante)
        {
          string[] partes = linea.Split(',');
          if(partes.Length==max_cursos + 1)
          {
            estudiante[total_estudiantes]=partes[0];
            for(int i = 0;i < max_cursos; i++)
            {
              matrizNotas[total_estudiantes,i]=Convert.ToDouble(partes[i+1]);
            }
            total_estudiantes++;
          }
        }
      }
      Console.WriteLine("se cargaron los registros del archivo...!!!");
    }
    public static void mostrarRegistro()
    {
      Console.WriteLine(new string('=', 100));
      Console.WriteLine("\t\tREGISTRO GENERAL DE NOTAS POR CURSO");
      Console.WriteLine(new string('=', 100));
      if (total_estudiantes == 0)
      {
        Console.WriteLine("No existe registros...!!!");
        return;
      }
      Console.Write($"{"ESTUDIANTE",-25}|");
      for (int i = 0; i < max_cursos; i++)
      {
        Console.Write($"{nombre_cursos[i],-12}|");
      }
      Console.WriteLine("PROMEDIO");
      Console.WriteLine(new string('-', 100));
      for (int i = 0; i < total_estudiantes; i++)
      {
        Console.Write($"{estudiante[i],-25}|");
        double suma = 0;
        for (int j = 0; j < max_cursos; j++)
        {
          Console.Write($"{matrizNotas[i, j],-12:F1}|");
          suma += matrizNotas[i, j];
        }
        double promedio = suma / max_cursos;
        string estado = promedio >= 12 ? "Aprobado" : "Desaprobado";
        Console.WriteLine($"{promedio:F2}({estado})");
      }
    }
    static void Main(string[] args)
    {
      int opc = 0;
      while (opc !=5)
      {
        Console.Clear();
        Console.WriteLine("[1]registrar estudiante ");
        Console.WriteLine("[2]guardar archivo ");
        Console.WriteLine("[3]registros del archivo ");
        Console.WriteLine("[4]mostrar registros ");
        Console.WriteLine("[5]salir");
        opc = validador.LeerEntero("seleccionar opcion[1-5]:");
        switch (opc)
        {
          case 1:
            RegistrarEstudiante(); break;
          case 2:
            guardarArchivo(); break;
          case 3:
            cargarRegistros(); break;
          case 4:
            mostrarRegistro(); break;
          case 5:
            Console.WriteLine("muchos exitos paraq el nuevo semestre"); break;
        }
        Console.ReadKey();
      }
    }
  }
}