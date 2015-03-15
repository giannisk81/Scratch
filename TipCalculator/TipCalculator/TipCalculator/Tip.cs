using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator
{
    public class Tip
    {
        public static string BillAmount {get; set;}
        public static string TipAmount { get; set; }
        public static string TotalAmount { get; set; }

        public Tip()
        {
            BillAmount = string.Empty;
            TipAmount = string.Empty;
            TotalAmount = string.Empty;
        }

        public static void CalculateTip(string orAmount, double tipPr)
        {
            double billAmount = 0.0;
            double tipAmount = 0.0;
            double totalAmount = 0.0;

            double.TryParse(orAmount.Replace("£", "").Trim(), out billAmount);
            tipAmount = tipPr * billAmount;
            totalAmount = tipAmount + billAmount;

            BillAmount = string.Format("{0:C}", billAmount);
            TipAmount = string.Format("{0:C}", tipAmount);
            TotalAmount = string.Format("{0:C}", totalAmount);
        }
    }
}
