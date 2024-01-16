internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("------------------------\n");
        Console.WriteLine("Matrices 05 - Captura de lista de calificaciones\r");
        Console.WriteLine("------------------------\n");

        int indiceAlumnos = 0;

        Console.WriteLine("¿Cuantos alumnos deseas capturar?");
        int numDeAlumnos = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("¿Cuantas materias seran capturadas?");
        int cantidadMaterias = Convert.ToInt32(Console.ReadLine());

        Console.Clear();
        int[,] materias = new int[numDeAlumnos, cantidadMaterias];
        string[] alumnos = new string[numDeAlumnos];
        decimal[] promedios = new decimal[numDeAlumnos];
 
        do
        {
            Console.WriteLine($"Captura el nombre del alumno {indiceAlumnos + 1} ?");
            alumnos[indiceAlumnos] = Convert.ToString(Console.ReadLine());
            promedios[indiceAlumnos] = 0;
            
            for (var calif = 0; calif < cantidadMaterias; calif++)
            {
                Console.WriteLine($"Captura la {calif + 1} materia del alumno {alumnos[indiceAlumnos]} ?");
                materias[indiceAlumnos, calif] = Convert.ToInt32(Console.ReadLine());
                promedios[indiceAlumnos] = promedios[indiceAlumnos] + materias[indiceAlumnos, calif];
            }
            promedios[indiceAlumnos] = promedios[indiceAlumnos] / numDeAlumnos;
            indiceAlumnos++;
            Console.Clear();

        } while (indiceAlumnos < numDeAlumnos);

        decimal promMenor = 0;
        string nomAlum = string.Empty;
        int[] califAlum = new int[cantidadMaterias];

        //Calculo de los promedios
        for (var i = 1; i < promedios.Length; i++)
        {
            for (var j = 0; j < promedios.Length; j++)
            {
                //Ordenar metodo de burbuja
                if (promedios[j] > promedios[i]) 
                {
                    promMenor = promedios[j];
                    promedios[j] = promedios[i];
                    promedios[i] = promMenor;

                    nomAlum = alumnos[j];
                    alumnos[j] = alumnos[i];
                    alumnos[i] = nomAlum;

                    //asigno las calificances menores del alumno 
                    for (int m1 = 0; m1 < materias.GetLength(1); m1++) 
                    {
                        califAlum[m1] = materias[j, m1];
                    }

                    for (int m2 = 0; m2 < materias.GetLength(1); m2++) 
                    {
                         materias[j, m2] =  materias[i, m2];
                    }

                    for (int m3 = 0; m3 < materias.GetLength(1); m3++)
                    {
                         materias[i, m3] =  califAlum[m3];
                    }
                }
            }
        }

        for (int j = 0; j < promedios.Length; j++)
        {
            Console.Write($"{alumnos[j]} ");
            Console.WriteLine();
        }

        for (int j = 0; j < promedios.Length; j++)
        {
            Console.Write($"{promedios[j]} ");
            Console.WriteLine();
        }

        PrintArray(materias);




    // Wait for the user to respond before closing.
        Console.Write("Presionr cualquier tecla para cerrar la aplicaición");
        Console.ReadKey();

    }

    static void PrintArray(int[,] inputArray)
    {
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                Console.Write($"{inputArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}