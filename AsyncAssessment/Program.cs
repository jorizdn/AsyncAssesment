using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAssessment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = await PourCoffee();
            await Console.Out.WriteLineAsync("Coffee is ready");

            Egg eggs = await FryEggs(2);
            await Console.Out.WriteLineAsync("Eggs are ready");

            Bacon bacon = await FryBacon(3);
            await Console.Out.WriteLineAsync("Bacon is ready");

            Toast toast = await ToastBread(2);
            await ApplyButter(toast);
            await ApplyJam(toast);
            await Console.Out.WriteLineAsync("toast is ready");

            Juice orange = await PourOJ();
            await Console.Out.WriteLineAsync("Orange juice is ready");
            await Console.Out.WriteLineAsync("Breakfast is ready!");

        }

        private static async Task<Juice> PourOJ()
        {
            await Console.Out.WriteLineAsync("Pouring orange juice");
            await Console.Out.WriteLineAsync("Pouring orange juice");
            return new Juice();
        }

        private static async Task ApplyJam(Toast toast) =>
            await Console.Out.WriteLineAsync("Putting jam on the toast");

        private static async Task ApplyButter(Toast toast) =>
            await Console.Out.WriteLineAsync("Putting butter on the toast");

        private static async Task<Toast> ToastBread(int slices)
        {
            var listSlices = new List<int>(slices);
            Parallel.ForEach(listSlices, new ParallelOptions { MaxDegreeOfParallelism = 2 }, async slice => await Console.Out.WriteLineAsync("Putting a slice of bread in the toaster"));

            await Console.Out.WriteLineAsync("Start toasting...");
            await Task.Delay(3000);
            await Console.Out.WriteLineAsync("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBacon(int slices)
        {
            await Console.Out.WriteLineAsync($"putting {slices} slices of bacon in the pan");
            await Console.Out.WriteLineAsync("cooking first side of bacon...");
            await Task.Delay(3000);

            var listSlices = new List<int>(slices);
            Parallel.ForEach(listSlices, new ParallelOptions { MaxDegreeOfParallelism = 2 }, async slice => await Console.Out.WriteLineAsync("flipping a slice of bacon"));

            await Console.Out.WriteLineAsync("cooking the second side of bacon...");
            await Task.Delay(3000);


            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int count)
        {
            await Console.Out.WriteLineAsync("Warming the egg pan...");
            await Task.Delay(3000);
            await Console.Out.WriteLineAsync($"cracking {count} eggs");
            await Console.Out.WriteLineAsync("cooking the eggs ...");
            await Task.Delay(3000);
            await Console.Out.WriteLineAsync("Put eggs on plate");

            return new Egg();
        }

        private static async Task<Coffee> PourCoffee()
        {
            await Console.Out.WriteLineAsync("Pouring coffee");
            return new Coffee();
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
