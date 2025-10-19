public class BankAccount
{
    // 1. Read-only auto-property. The account number can never be changed after creation.
    public string AccountNumber { get; }

    // 2. Public read, private write. The balance can only be changed by methods within this class.
    public decimal Balance { get; private set; }

    // 3. Fully public read/write property.
    public string AccountHolderName { get; set; }

    // 4. Auto-Property Initializer for a default value.
    public bool IsOverdraftProtected { get; set; } = false;

    // Constructor to initialize the required, read-only properties
    public BankAccount(string accountNumber, string accountHolderName, decimal initialBalance)
    {
        this.AccountNumber = accountNumber;
        this.AccountHolderName = accountHolderName;
        this.Balance = initialBalance; // OK to set here because 'set' is private
    }

    // Public methods to interact with the private state
    public decimal Deposit
    {
        set{

            if (value > 0)
            {
                Balance += value; // Modifying the private 'set' from within the class
                Console.WriteLine($"Deposited {value:C}. New balance is {Balance:C}.");
            }
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount:C}. New balance is {Balance:C}.");
        }
        else
        {
            Console.WriteLine("Withdrawal failed.");
        }
    }
}
