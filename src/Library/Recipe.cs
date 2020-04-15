//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; } //"Método del objeto, del tipo clase Product, puede cambiar estado obj".

        public void AddStep(Step step)
        {
            this.steps.Add(step); //"Le agrega al "Array->steps" una instancia de Step".
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        public double GetProductionsCost()  /* "Recipe" tiene un "Array" de objetos "Step", estos tambien incluyen
        todos los datos de los "Equipment" y "Product".  */
        {
            double productcost = 0;
            double equipcost = 0;

            foreach(Step step in steps)
            {
                productcost += step.Quantity * step.Input.UnitCost;
                equipcost += ( (step.Time / 60) * (step.Equipment.HourlyCost) ) / 60; //Se hace regla de 3 para saber gato del equipo.
            }
            return productcost + equipcost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total: {GetProductionsCost()}");
        }
    }
}