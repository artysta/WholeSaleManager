﻿namespace WholeSaleManager.Utility
{
	public static class StaticDetails
	{
		public const string Role_User_Indi = "Individual Customer";
		public const string Role_User_Comp = "Company Customer";
		public const string Role_Admin = "Admin";
		public const string Role_Employee = "Employee";

		public static double GetTotalPrice(double quantity, double price, double price50, double price100)
        {
			if(quantity < 50)
            {
				return price;
            }
			else
            {
				if(quantity < 100)
                {
					return price50;
                }
                else
                {
					return price100;
                }
            }
        }
	}
}
