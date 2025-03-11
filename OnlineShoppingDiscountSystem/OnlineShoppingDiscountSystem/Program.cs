using System;

namespace OnlineShoppingDiscountSystem
{
    // Abstract class
    public abstract class Discount
    {
        public abstract decimal CalculateDiscount(decimal price);
    }

    // Seasonal discount class
    public class SeasonalDiscount : Discount
    {
        private decimal _discountPercentage;

        public SeasonalDiscount(decimal discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }

        public override decimal CalculateDiscount(decimal price)
        {
            return price * (_discountPercentage / 100);
        }
    }

    // Festival discount class
    public class FestivalDiscount : Discount
    {
        private decimal _flatDiscount;

        public FestivalDiscount(decimal flatDiscount)
        {
            _flatDiscount = flatDiscount;
        }

        public override decimal CalculateDiscount(decimal price)
        {
            return _flatDiscount;
        }
    }

    // Membership discount class
    public class MembershipDiscount : Discount
    {
        private decimal _discountPercentage;

        public MembershipDiscount(decimal discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }

        public override decimal CalculateDiscount(decimal price)
        {
            return price * (_discountPercentage / 100);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal originalPrice = 1000m;

            // Seasonal discount
            Discount seasonalDiscount = new SeasonalDiscount(10); // 10% discount
            decimal seasonalDiscountAmount = seasonalDiscount.CalculateDiscount(originalPrice);
            Console.WriteLine($"Seasonal Discount: {seasonalDiscountAmount}, Final Price: {originalPrice - seasonalDiscountAmount}");

            // Festival discount
            Discount festivalDiscount = new FestivalDiscount(150); // Flat $150 discount
            decimal festivalDiscountAmount = festivalDiscount.CalculateDiscount(originalPrice);
            Console.WriteLine($"Festival Discount: {festivalDiscountAmount}, Final Price: {originalPrice - festivalDiscountAmount}");

            // Membership discount
            Discount membershipDiscount = new MembershipDiscount(15); // 15% discount
            decimal membershipDiscountAmount = membershipDiscount.CalculateDiscount(originalPrice);
            Console.WriteLine($"Membership Discount: {membershipDiscountAmount}, Final Price: {originalPrice - membershipDiscountAmount}");
        }
    }
}