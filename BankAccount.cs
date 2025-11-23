namespace Delegates
{
    internal class BankAccount
    {
        public class BankAccountEventArgs(TransactionTypes transaction_type, decimal amount, decimal balance) : EventArgs
        {
            public TransactionTypes TransactionType { get; } = transaction_type;
            public decimal Amount { get; } = amount;

            public decimal Balance { get; } = balance;
        }

        //Publisher
        public class BankAccountPublisher
        {
            private decimal _balance;

            public decimal Balance { get => _balance; set => _balance = value; }

            public event EventHandler<BankAccountEventArgs>? TransactionOccurred;

            protected virtual void OnTransactionOccurred(BankAccountEventArgs e)
            {
                TransactionOccurred?.Invoke(this, e);
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid deposit amount!");
                    return;
                }

                _balance += amount;

                OnTransactionOccurred(new BankAccountEventArgs(TransactionTypes.Added, amount, _balance));

            }


            public void Withdraw(decimal amount)
            {
                if (_balance < amount)
                {
                    Console.WriteLine($"Could Not Withdraw this amount cause your balance is low !");
                }

                _balance -= amount;

                OnTransactionOccurred(new BankAccountEventArgs(TransactionTypes.Removed, amount, _balance));
            }
        }

        //Subscriber
        public class BankAlert
        {
            public void BankNotifiaction(object? sender, BankAccountEventArgs e)
            {
                Console.WriteLine($"Alert from {sender}: Amount: {e.Amount} - Balance: {e.Balance:C}");
            }
        }

        static void Main(string[] args)
        {
            BankAccountPublisher account = new();
            BankAlert alert = new();

            account.TransactionOccurred += alert.BankNotifiaction;
            account.Balance = 100;
            account.Deposit(200);

            Console.ReadKey();
        }
    }
}
