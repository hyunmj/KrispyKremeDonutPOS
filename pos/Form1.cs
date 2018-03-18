using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
	public partial class Form1 : Form
	{
		int sum = 0, discount, result = 0;
		int sumOfAdditionalPrice1 = 0,
			sumOfAdditionalPrice2 = 0;
		List<Donut> donuts = new List<Donut>();
		Donut donut;
		Queue<int> p = new Queue<int>();

		private void Original_Click(object sender, EventArgs e)
		{
			donut = new Donut("오리지널글레이즈드", 1200, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//		MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void ChocoHolic_Click(object sender, EventArgs e)
		{
			donut = new pos.Donut("초코홀릭", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Sugar_Click(object sender, EventArgs e)
		{
			donut = new pos.Donut("슈가코티드", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void UpdateForm(Donut donut)
		{
			Items.Text += donut.getInfo();
			sum += donut.getPrice();
			textBox3.Text = sum.ToString();
			donuts.Sort();
			int ss = 0, count = 0;
			
			for(int i = donuts.Count()/6*6-1;i>=0;i--)
			{
				ss += donuts[i].AdditionalPrice1;
				count++;
				if (count % 12 == 0)
				{
					p.Enqueue(ss + 13000);
					ss = 0;
				}
			}
		}

		//도넛 6개 미만 : 낱개 판매
		private int PriceSum(int start, int end)
		{
			for(int i=start;i<end;i++)
			{
				result += donuts[i].getPrice();
			}
			//if (sum >= 7000)
			//{
			//	MessageBox.Show("도넛 6개에 7천원!(추가금액 발생할 수 있음)\n특판 권유하세요!", "특판");
			//}
			return result;
		}
/*
		//도넛 6~11개 : 특판 + 낱개
		private void SixTo11(int start)
		{ 
				for (int i = start; i < donuts.Count; i++)
				{
					if (i - start < 6)
						sumOfAdditionalPrice2 += donuts[i].AdditionalPrice2;
					else
						result += donuts[i].getPrice();
				}
				result += 7000 + sumOfAdditionalPrice2;
		}
*/
		private void button1_Click(object sender, EventArgs e)
		{
			donuts.Clear();
			Items.Clear();
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
			sum = 0;
			result = 0;
			discount = 0;
		}

		private void PeanutCream_Click(object sender, EventArgs e)
		{
			donut = new Donut("땅콩크림빵", 1500, 200, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void ChocolateIced_Click(object sender, EventArgs e)
		{
			donut = new Donut("초콜릿글레이즈드", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void ChocolateCake_Click(object sender, EventArgs e)
		{
			donut = new Donut("초콜릿케익", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void SourCreamCake_Click(object sender, EventArgs e)
		{
			donut = new Donut("사워크림케익", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Lotus_Click(object sender, EventArgs e)
		{
			donut = new Donut("로투스비스코프", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Orange_Click(object sender, EventArgs e)
		{
			donut = new Donut("오렌지글로스", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Green_Click(object sender, EventArgs e)
		{
			donut = new Donut("그린글로스", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Nutty_Click(object sender, EventArgs e)
		{
			donut = new Donut("너티코코아링", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Cheese_Click(object sender, EventArgs e)
		{
			donut = new Donut("뉴욕치즈케이크", 1600, 300, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Yogurt_Click(object sender, EventArgs e)
		{
			donut = new Donut("딸기요거트", 2000, 700, 200);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Rice_Click(object sender, EventArgs e)
		{
			donut = new Donut("딸기찰떡도넛", 2200, 900, 400);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void StrawberryFilled_Click(object sender, EventArgs e)
		{
			donut = new Donut("스트로베리필드", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Caramel_Click(object sender, EventArgs e)
		{
			donut = new Donut("카라멜아이스드", 1500, 200, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Loaker_Click(object sender, EventArgs e)
		{
			donut = new Donut("로아커도넛", 2000, 700, 200);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void StrawberryCandy_Click(object sender, EventArgs e)
		{
			donut = new Donut("딸기캔디도넛", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void RichStawberry_Click(object sender, EventArgs e)
		{
			donut = new Donut("리치딸치도넛", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			textBox1.Text = solve(donuts.Count() / 6).ToString();
		}




		//도넛 12개 : 어쏘티드 또는 특판 2개
		private int Twelve(int start)
		{
			for (int i = start; i < start + 12; i++)
			{
				sumOfAdditionalPrice1 += donuts[i].AdditionalPrice1;
				sumOfAdditionalPrice2 += donuts[i].AdditionalPrice2;
			}

				if (sumOfAdditionalPrice1 <= 1000)
					result += 13000 + sumOfAdditionalPrice1;
				else
				{
					result += 14000 + sumOfAdditionalPrice2;
				}
			return result;
		}


		private int solve(int n)
		{
			result = 0;

			if(n==0)
			{
				return PriceSum(0, donuts.Count());
			}
			if(n==1)
			{
				int sum = 0;
				for (int i=0;i<6;i++)
				{
					sum += donuts[i].AdditionalPrice2;
				}
				return 7000 + sum + PriceSum(n*6, donuts.Count());
			}
			if(n==2)
			{ 
				for (int i = 0; i < 6 * n; i++)
				{
					sumOfAdditionalPrice2 += donuts[i].AdditionalPrice2; //특판 추가금액 -> 특판가격=7000*n+sOAP2
				}
				int res = 7000 * n + sumOfAdditionalPrice2;
				return Math.Min(res, p.Peek()) + PriceSum(n * 6, donuts.Count());
			}

			for (int i=0;i<6*n;i++)
			{
				sumOfAdditionalPrice2 += donuts[i].AdditionalPrice2; //특판 추가금액 -> 특판가격=7000*n+sOAP2
			}
			int ret = 7000 * n + sumOfAdditionalPrice2;
			ret = Math.Min(ret, solve(n - 2) + p.Dequeue());
			return ret;
		}
		

		public Form1()
		{
			InitializeComponent();
		}

	}
}
// 17.3.20 재귀 사용
