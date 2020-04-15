//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList(); //"ArrayList", catalogo de productos.

        private static ArrayList equipmentCatalog = new ArrayList(); //"ArrayList", catalogo de equipos.

        public static void Main(string[] args)
        {
            PopulateCatalogs(); //"Método de la clase Program".

            Recipe recipe = new Recipe(); //"Instancia receta".
            recipe.FinalProduct = GetProduct("Café con leche"); // ¿Para qué se consulta si existe ese objeto y luego se setea?
            recipe.AddStep(new Step(GetProduct("Café"), 10, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 15, GetEquipment("Hervidor"), 60));
            recipe.PrintRecipe();
        }

        private static void PopulateCatalogs() // ¿Este paso tiene alguna utilidad, porque no instanciar directamente?
        {
            AddProductToCatalog("Café", 100); //con los parametros necesarios para "product".
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost)); //"Instancia y agrega al Array".
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost)); //"Instancia y agrega al Array".
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault(); //¿Qué pasa so no se cumple?.
        }
    }
}
