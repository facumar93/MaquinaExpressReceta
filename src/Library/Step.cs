//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        //Cumpliendo con el patrón expert y el principio de responsabilidad única, la clase "Step" tiene la;
        //responsabilidad de conocer la cantidad de producto y el tiempo empleado en cada paso. También conoce las instancias de Product y Equipe.
        //Por tanto es el que debería calcular el gasto "subtotal".
        public double SubTotal 
        {
            get
            {
                return ((this.Quantity / 1000) * this.Input.UnitCost) + ((this.Time / 3600) * this.Equipment.HourlyCost) ; 
            }
        }

        //Cumpliendo con el patrón expert y el principio de responsabilidad única, la clase "Step" tiene la responsabilidad
        //retornar un "string" con información de su instancia.
        
         public string StepToPrint
        {
            get
            {
                return ($"Empleando {this.Quantity} gramos de '{this.Input.Description}' " +
                    $"usando '{this.Equipment.Description}' durante {this.Time} segunos\n");
            }
            
        }
    }
}