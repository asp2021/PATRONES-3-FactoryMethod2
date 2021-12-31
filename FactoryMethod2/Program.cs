using System;
using System.Collections.Generic;

namespace FactoryMethod2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FACTORY METHOD" + '\n');
            Console.WriteLine("El proceso de inicializacion se puede realizar dentro de una funcion en donde entra el patron de diseño factory metod" + '\n');


            PizzaStore nyStore = new NYPizzaStore();
            Pizza pizza = nyStore.OrderPizza(TypeOfPizza.Pepperoni);

            Console.WriteLine($"Pizza {pizza.Name} lista para ser entregada a Daniel");
            Console.ReadLine();
        }
    }

    public abstract class Pizza
    {
        public string Name { get; set; }
        protected string Dough;
        protected string Sauce;
        protected List<string> Toppings = new List<string>();

        public void Prepare()
        {
            Console.WriteLine($"Prepararando: {Name}");
            Console.WriteLine($"Colocando masa: {Dough}");
            Console.WriteLine($"Agregando salsa: {Sauce}");
            Console.WriteLine($"Agregando Capas: {string.Join(",", Toppings)}");

        }
        public void Bake() => Console.WriteLine($"Cocinar por 20 min");
        public void Cut() => Console.WriteLine($"Pizza fue cortada en partes iguales");
        public void Box() => Console.WriteLine($"Pizza colocada en caja oficial");

    }

    public enum TypeOfPizza
    {
        Pepperoni,
        Neapolitan,
        California
    }

    public abstract class PizzaStore
    {
        public abstract Pizza CreatePizza(TypeOfPizza type);

        public Pizza OrderPizza(TypeOfPizza type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

    }



    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(TypeOfPizza type)
        {
            //switch (name)
            //{
            //    case "pepperoni":
            //        return new NYPepperoniPizza();
            //    case "Neapolitan":
            //        return new NYNeapolitanPizza();
            //    case "California":
            //        return new NYCaliforniaPizza();
            //    default:
            //        return null;

            //}

            // aca utilizo refelction
            return (Pizza)Activator.
                CreateInstance(Type.GetType($"FactoryMethod2.NY{Enum.GetName(typeof(TypeOfPizza), type)}Pizza"));

        }

    }

    public class FLPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(TypeOfPizza type)
        {
            return (Pizza)Activator.
                 CreateInstance(Type.GetType($"FactoryMethod2.FL{Enum.GetName(typeof(TypeOfPizza), type)}Pizza"));
        }

    }

    internal class NYPepperoniPizza : Pizza
    {
        public NYPepperoniPizza()
        {
            Name = "Pepperoni";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Quesso mozarella");
        }
    }

    internal class NYCaliforniaPizza : Pizza
    {
        public NYCaliforniaPizza()
        {
            Name = "caifornia";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Quesso mozarella");
        }
    }

    internal class NYNeapolitanPizza : Pizza
    {
        public NYNeapolitanPizza()
        {
            Name = "Napolitana";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Quesso mozarella");
        }
    }


    #region Florida Pizza
    internal class FLPepperoniPizza : Pizza
    {
        public FLPepperoniPizza()
        {
            Name = "Pepperoni";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Quesso mozarella");
        }
    }

    internal class FLCaliforniaPizza : Pizza
    {
        public FLCaliforniaPizza()
        {
            Name = "caifornia";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Quesso mozarella");
        }
    }

    internal class FLNeapolitanPizza : Pizza
    {
        public FLNeapolitanPizza()
        {
            Name = "Napolitana";
            Dough = "delgada";
            Sauce = "Salsa de tomates";
            Toppings.Add("Quesso mozarella");
        }
    }

    #endregion


}


