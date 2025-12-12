// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;

namespace SistemaNotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vectores de estudiantes y materias
            string[] estudiantes = { "Ana", "Luis", "Sofía" };
            string[] materias = { "Matemáticas", "Inglés", "Programación" };

            int cantidadEstudiantes = estudiantes.Length;
            int cantidadMaterias = materias.Length;

            // Matriz de notas: filas = estudiantes, columnas = materias
            double[,] notas = new double[cantidadEstudiantes, cantidadMaterias];

            Console.WriteLine("=== SISTEMA DE NOTAS (VECTORES + MATRIZ) ===\n");

            // 1. Ingreso de notas
            Console.WriteLine("INGRESO DE NOTAS:");
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                for (int j = 0; j < cantidadMaterias; j++)
                {
                    double notaValida;
                    bool entradaCorrecta;

                    do
                    {
                        Console.Write($"Ingrese la nota de {estudiantes[i]} en {materias[j]} (0.0 - 5.0): ");
                        string entrada = Console.ReadLine();

                        // Permitir coma o punto como separador decimal
                        entrada = entrada.Replace(',', '.');

                        entradaCorrecta = double.TryParse(
                            entrada,
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out notaValida
                        );

                        if (!entradaCorrecta || notaValida < 0.0 || notaValida > 5.0)
                        {
                            Console.WriteLine("⚠ Nota inválida. Intente de nuevo.\n");
                            entradaCorrecta = false;
                        }

                    } while (!entradaCorrecta);

                    notas[i, j] = notaValida;
                }

                Console.WriteLine();
            }

            // 2. Mostrar la tabla completa de notas
            Console.WriteLine("\n=== TABLA DE NOTAS ===");
            Console.Write("Estudiante\\Materia\t");
            for (int j = 0; j < cantidadMaterias; j++)
            {
                Console.Write(materias[j] + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.Write(estudiantes[i] + "\t\t");
                for (int j = 0; j < cantidadMaterias; j++)
                {
                    Console.Write(notas[i, j].ToString("0.0", CultureInfo.InvariantCulture) + "\t");
                }
                Console.WriteLine();
            }

            // 3. Promedio por estudiante (fila)
            Console.WriteLine("\n=== PROMEDIO POR ESTUDIANTE ===");
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                double suma = 0;
                for (int j = 0; j < cantidadMaterias; j++)
                {
                    suma += notas[i, j];
                }
                double promedio = suma / cantidadMaterias;
                Console.WriteLine($"Promedio de {estudiantes[i]}: {promedio.ToString("0.00", CultureInfo.InvariantCulture)}");
            }

            // 4. Promedio por materia (columna)
            Console.WriteLine("\n=== PROMEDIO POR MATERIA ===");
            for (int j = 0; j < cantidadMaterias; j++)
            {
                double suma = 0;
                for (int i = 0; i < cantidadEstudiantes; i++)
                {
                    suma += notas[i, j];
                }
                double promedio = suma / cantidadEstudiantes;
                Console.WriteLine($"Promedio en {materias[j]}: {promedio.ToString("0.00", CultureInfo.InvariantCulture)}");
            }

            Console.WriteLine("\nProceso finalizado. Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
