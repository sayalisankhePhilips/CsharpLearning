using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareBreakfast();
        }

        private static async void PrepareBreakfast()
        {
            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Task.WaitAll(eggsTask, baconTask, toastTask);

            Console.WriteLine("eggs are ready");
            Console.WriteLine("bacon is ready");
            ApplyButter(toastTask.Result);
            ApplyJam(toastTask.Result);
            Console.WriteLine("toast is ready");

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            _watch.Stop();
            Console.WriteLine("Breakfast is ready! Preparation time :" + _watch.ElapsedMilliseconds);
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Task<Toast> ToastBreadAsync(int slices)
        {
            return Task<Toast>.Run(()=> {
                return ToastBread(slices);
            });
        }

        private static Task<Egg> FryEggsAsync(int howMany)
        {
            return Task<Egg>.Run(() => {
                return FryEggs(howMany);
            });
        }

        private static Task<Bacon> FryBaconAsync(int slices)
        {
            return Task<Bacon>.Run(() => {
                return FryBacon(slices);
            });
        }

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }

    internal class Toast
    {
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }

    internal class Juice
    {

    }
}
