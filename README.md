BankAccount Event Example in C#

This project demonstrates the use of C# events and delegates through a simple bank account scenario.

Features

BankAccountPublisher: The publisher class that raises the TransactionOccurred event whenever a deposit or withdrawal is made.

BankAccountEventArgs: Custom event arguments containing the transaction type, amount, and current balance.

BankAlert: Subscriber class that listens to the event and prints transaction alerts to the console.

Demonstrates the Observer Pattern using EventHandler<T>.
