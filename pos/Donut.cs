using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos
{
	class Donut : IComparable<Donut>
	{
		string name;
		int price;
		public int AdditionalPrice1;
		public int AdditionalPrice2;
		public static int index = -1;

		public Donut(string name, int price, int ap1, int ap2)
		{
			this.name = name;
			this.price = price;
			this.AdditionalPrice1 = ap1;
			this.AdditionalPrice2 = ap2;
		}
		
		public int CompareTo(Donut donutToCompare)
		{
			if (this.price > donutToCompare.price)
				return -1;
			else if (this.price < donutToCompare.price)
				return 1;
			else
				return 0;
		}

		public string getName()
		{
			return name;
		}
		public int getPrice()
		{
			return price;
		}
		public string getInfo()
		{
			return name + "\t\t\t " + price.ToString() + "\n";
		}

	}
}
