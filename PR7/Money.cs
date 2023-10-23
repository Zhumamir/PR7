using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money money1, Money money2)
        {
            if (money1.Currency != money2.Currency)
            {
                throw new InvalidOperationException("Cannot add money in different currencies.");
            }

            return new Money(money1.Amount + money2.Amount, money1.Currency);
        }

        public static bool operator ==(Money money1, Money money2)
        {
            return money1.Equals(money2);
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return !money1.Equals(money2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return Amount == other.Amount && Currency == other.Currency;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Amount, Currency).GetHashCode();
        }
    }
}
