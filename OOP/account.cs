// This code is AI generated
using System;
using System.Collections.Generic;

// Base abstract account class
public abstract class BankAccount
{
    public string AccountNumber { get; private set; }
    public string Owner { get; set; }
    protected decimal Balance { get; private set; }

    public BankAccount(string owner, string accountNumber)
    {
        Owner = owner;
        AccountNumber = accountNumber;
        Balance = 0;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Deposit must be positive");
        Balance += amount;
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Withdraw must be positive");
        if (Balance < amount) return false;
        Balance -= amount;
        return true;
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public abstract void PrintAccountInfo();
}

// Savings account with interest
public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public SavingsAccount(string owner, string accountNumber, decimal interestRate)
        : base(owner, accountNumber)
    {
        InterestRate = interestRate;
    }

    public void AddInterest()
    {
        Deposit(GetBalance() * InterestRate);
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine($"Savings Account {AccountNumber} ({Owner}) Balance: {GetBalance()}, Interest Rate: {InterestRate}");
    }
}

// Checking account with fee
public class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(string owner, string accountNumber, decimal fee)
        : base(owner, accountNumber)
    {
        TransactionFee = fee;
    }

    public override bool Withdraw(decimal amount)
    {
        // Withdraw amount + transaction fee
        return base.Withdraw(amount + TransactionFee);
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine($"Checking Account {AccountNumber} ({Owner}) Balance: {GetBalance()}, Fee: {TransactionFee}");
    }
}

// Interface for transaction history
public interface IHasTransactions
{
    void AddTransaction(string description, decimal amount);
    void PrintTransactions();
}

// Extended BankAccount with transaction history
public class TransactionalAccount : BankAccount, IHasTransactions
{
    private List<string> transactions = new List<string>();

    public TransactionalAccount(string owner, string accountNumber) : base(owner, accountNumber) { }

    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
        AddTransaction("Deposit", amount);
    }

    public override bool Withdraw(decimal amount)
    {
        bool success = base.Withdraw(amount);
        AddTransaction("Withdraw", success ? amount : 0);
        return success;
    }

    public void AddTransaction(string description, decimal amount)
    {
        transactions.Add($"{DateTime.Now}: {description} {amount}");
    }

    public void PrintTransactions()
    {
        Console.WriteLine("Transaction History:");
        foreach (var t in transactions) Console.WriteLine(t);
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine($"Transactional Account {AccountNumber} ({Owner}) Balance: {GetBalance()}");
    }
}

// Demonstration
public class Program
{
    public static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("Alice", "SA001", 0.03m),
            new CheckingAccount("Bob", "CA001", 1.50m),
            new TransactionalAccount("Charlie", "TA001")
        };

        // Deposit and withdraw polymorphically
        foreach (var acc in accounts)
        {
            acc.Deposit(1000m);
            acc.Withdraw(100m);
            acc.PrintAccountInfo();
        }

        ((SavingsAccount)accounts[0]).AddInterest();

        // Show interface working
        var ta = (TransactionalAccount)accounts[2];
        ta.Deposit(500m);
        ta.Withdraw(200m);
        ta.PrintTransactions();
    }
}
