using ExpensesApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            bool exit = true;
            int option = -1;
            do
            {
                Console.WriteLine("1 .- New Card.");
                Console.WriteLine("2 .- New Expense.");
                Console.WriteLine("3 .- List expenses.");
                Console.WriteLine("4 .- Export to excel.");
                Console.WriteLine("5 .- Exit.");
                Console.Write("Select a option:");

                bool reslConver = Int32.TryParse(Console.ReadLine(), out option);

                if (reslConver)
                {
                    switch (option)
                    {
                        case 2:
                            this.NewExpense();
                            break;
                        case 3:
                            this.ListData();
                            break;
                    }

                    exit = !(option == 5);
                }

            } while (exit);
        }

        public async Task NewExpense()
        {
            Console.WriteLine("--------------------- Form ---------------------");
            Console.Write("Name:");
            string? name = Console.ReadLine();
            Console.Write("Amount:");
            double amount = 0.0;
            bool isValidAmount = double.TryParse(Console.ReadLine(), out amount);

            if (!isValidAmount)
            {
                Console.WriteLine("Check the amount.");
                Console.WriteLine("--------------------- Form ---------------------");
                return;
            }

            Console.Write("Description:");
            string? description = Console.ReadLine();
            Console.WriteLine("--------------------- Form ---------------------");
            using (AppExContext appContext = new AppExContext())
            {
                appContext.Expenses.Add(new Expense(name, description, amount));
                await appContext.SaveChangesAsync();
            }

        }

        public void ListData()
        {
            Console.WriteLine("--------------------- Data ---------------------");
            using (AppExContext appContext = new AppExContext())
            {
                if (appContext.Expenses.Any())
                {
                    Console.WriteLine($"Id - Name - Description - Amount");
                    appContext.Expenses.AsNoTracking().ToList().ForEach(ex => Console.WriteLine($"{ex.Id} - {ex.Name} - {ex.Description} - {ex.Amount}"));
                }
            }
            Console.WriteLine("--------------------- Data ---------------------");
        }
    }


}
