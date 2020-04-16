using System;
using Full_GRASP_And_SOLID.Library;

//Cumpliendo con el patrón expert y el principio de responsabilidad única, se opta por una clase que imprima por pantalla
//De esta manera, las otra clases no tienene responsabilidad sobre el tipo de impresion, por ejemplo. 
namespace Full_GRASP_And_SOLID
{
    public class ConsolePrinter
    {
        public static void PrintTicket(Recipe recipe)

        {
            Console.WriteLine("---------------------\n");
            Console.WriteLine(recipe.RecipeToPrint());
            Console.WriteLine("\n---------------------");
        }
    }
}