using ExpensesApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            try
            {
                await new Program().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message} {ex.Source}");
            }
            
        }

        public async Task Run()
        {
            //AppExContext appExContext = new AppExContext();
            //appExContext.Database.EnsureCreated();

            bool exit = true;
            int option = -1;
            do
            {
                Console.WriteLine("1 .- New Card.");
                Console.WriteLine("2 .- List cards.");
                Console.WriteLine("3 .- New Expense.");
                Console.WriteLine("4 .- List expenses.");
                Console.WriteLine("5 .- Export to excel.");
                Console.WriteLine("6 .- Exit.");
                Console.Write("Select a option:");

                bool reslConver = Int32.TryParse(Console.ReadLine(), out option);

                if (reslConver)
                {
                    switch (option)
                    {
                        case 1:
                            await this.NewCard();
                            break;
                        case 2:
                            await this.NewCard();
                            break;
                        case 3:
                            await this.NewExpense();
                            break;
                        case 4:
                            await this.ListDataExpenses();
                            break;
                        case 5:
                            this.ExportExpensesToExcel();
                            break;
                        case 6:
                            exit = false;
                            break;
                    }
                }

            } while (exit);
        }

        private void ExportExpensesToExcel()
        {
            throw new NotImplementedException();
        }

        private async Task NewCard()
        {
            Console.WriteLine("--------------------- Form ---------------------");
            Console.Write("Name:");
            string? name = Console.ReadLine();
            Console.Write("Last digits:");
            string? lastDigits = Console.ReadLine();
            Console.Write("Description:");
            string? description = Console.ReadLine();
            Console.WriteLine("--------------------- Form ---------------------");
            using (AppExContext appContext = new AppExContext())
            {
                appContext.Cards.Add(new Card(name, lastDigits, description));
                await appContext.SaveChangesAsync();
            }
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

        public async Task ListDataExpenses()
        {
            Console.WriteLine("--------------------- Data ---------------------");
            using (AppExContext appContext = new AppExContext())
            {
                if (appContext.Expenses.Any())
                {
                    Console.WriteLine($"Id - Name - Description - Amount");
                    (await appContext.Expenses.AsNoTracking().ToListAsync()).ForEach(ex => Console.WriteLine($"{ex.Id} - {ex.Name} - {ex.Description} - {ex.Amount}"));
                }
            }
            Console.WriteLine("--------------------- Data ---------------------");
        }
    }


}
