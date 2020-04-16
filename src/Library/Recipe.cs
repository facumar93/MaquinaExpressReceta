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

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        //Cumpliendo con el patrón expert y el principio de responsabilidad única, la clase "Recipe";
        //tiene la responsabilidad de conocer todas las instancias de "Step", debería calcular el gasto total;
        //de la receta. 
        public double GetProductionCost()
        {
            double result = 0;
            foreach(Step step in this.steps)
            {
                result += step.SubTotal;
            }
            return result;            
        }
        //Cumpliendo con el patrón expert y el principio de responsabilidad única, la clase "Recipe";
        //tiene la responsabilidad de conocer la "receta completa" que es su propia instancia.
        public string RecipeToPrint()
        {
            string result = string.Empty;
            foreach(Step step in this.steps)
            {
                result += step.StepToPrint;
            }
            result += $"\nTotal --> {this.GetProductionCost()} Pesos";
            return result; 
        }
    }
}