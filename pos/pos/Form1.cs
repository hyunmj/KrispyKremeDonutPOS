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
        List<int> l = new List<int>();
        int[] complete = new int[10];
		Donut donut;
		Queue<int> p = new Queue<int>();
        int[] picked = new int[50];
        int[] arr = { 12, 6, 1 };
        int minprice=99999999, price, minsum=9999999;
        bool alarm = false;

        private void partition(int n, int idx)
        {
            if (n == 0)
            {
                Pick(0, 0, l[0], 0);
                if (minprice > minsum)
                    minprice = minsum;
                //l에 있는대로 고르기
                return;
            }

            for(int i=idx;i<3;i++)
            {
                if (n - arr[i] >= 0)
                {
                    if (n >= 6 && i == 2)
                        continue;
                    l.Add(arr[i]);
                    partition(n - arr[i], i);
                    l.RemoveAt(l.Count - 1);
                }
            }
        }

        private void Pick(int start, int arridx, int topick, int sum)
        {
            if (arridx == l.Count)
            {
                
                int count6 = 0, count12 = 0;
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i] == 12)
                        count12++;
                    if (l[i] == 6)
                        count6++;
                }
                sum += count12 * 13000 + count6 * 7000;

                if (minsum > sum)
                {
                    minsum = sum;
                    l.CopyTo(complete,0);
                    int sum2 = 0;
                    for (int i = 0; i < donuts.Count; i++)
                    {
                        if (picked[i] == 2)
                            sum2 += donuts[i].getPrice();
                    }
                    if (sum2 > 7000)
                        alarm = true;
                    else
                        alarm = false;
                }

                    return;
            }

            if (topick == 0)
            {
                if (arridx == l.Count - 1)
                {
                    int count6 = 0, count12 = 0;
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (l[i] == 12)
                            count12++;
                        if (l[i] == 6)
                            count6++;
                    }

                    
                    sum += count12 * 13000 + count6 * 7000;
                    if (minsum > sum)
                    {
                        minsum = sum;
                        l.CopyTo(complete, 0);
                        int sum2 = 0;
                        for (int i = 0; i < donuts.Count; i++)
                        {
                            if (picked[i] == 2)
                                sum2 += donuts[i].getPrice();
                        }
                        if (sum2 > 7000)
                            alarm = true;
                        else
                            alarm = false;
                    }
                    return;
                }
                Pick(0, arridx + 1, l[arridx + 1], sum);
            }
                for (int i = start; i < donuts.Count; i++)
                {
                    if (picked[i]==0)
                    {
                        if (l[arridx] == 1)
                            picked[i] = 2;
                        else 
                            picked[i] = 1;
                        if (l[arridx] == 12)
                        {
                            Pick(i + 1, arridx, topick - 1, sum + donuts[i].AdditionalPrice1);
                            picked[i] = 0;
                        }
                        else if (l[arridx] == 6)
                        {
                            Pick(i + 1, arridx, topick - 1, sum + donuts[i].AdditionalPrice2);
                            picked[i] = 0;
                        }
                        else
                        {
                            Pick(i + 1, arridx, topick - 1, sum + donuts[i].getPrice());
                            picked[i] = 0;
                        } 
                    }

                }
            
        }
       

		private void Original_Click(object sender, EventArgs e)
		{
			donut = new Donut("오리지널글레이즈드", 1200, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//		MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();//받을 돈
		}

		private void ChocoHolic_Click(object sender, EventArgs e)
		{
			donut = new pos.Donut("초코홀릭", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Sugar_Click(object sender, EventArgs e)
		{
			donut = new pos.Donut("슈가코티드", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void UpdateForm(Donut donut)
		{
			Items.Text += donut.getInfo();
			sum += donut.getPrice();
			textBox3.Text = sum.ToString();//총계
			
		}

		//Clear
		private void button1_Click(object sender, EventArgs e)
		{
			donuts.Clear();
			Items.Clear();
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
            textBox4.Clear();
			sum = 0;
			result = 0;
			discount = 0;
            minprice = 9999999;
            minsum = 9999999;
        }

		private void PeanutCream_Click(object sender, EventArgs e)
		{
			donut = new Donut("땅콩크림빵", 1500, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void ChocolateIced_Click(object sender, EventArgs e)
		{
			donut = new Donut("초콜릿글레이즈드", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void ChocolateCake_Click(object sender, EventArgs e)
		{
			donut = new Donut("초콜릿케익", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void SourCreamCake_Click(object sender, EventArgs e)
		{
			donut = new Donut("사워크림케익", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Lotus_Click(object sender, EventArgs e)
		{
			donut = new Donut("로투스비스코프", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Orange_Click(object sender, EventArgs e)
		{
			donut = new Donut("오렌지글로스", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Green_Click(object sender, EventArgs e)
		{
			donut = new Donut("그린글로스", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Nutty_Click(object sender, EventArgs e)
		{
			donut = new Donut("너티코코아링", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Cheese_Click(object sender, EventArgs e)
		{
			donut = new Donut("뉴욕치즈케이크", 1600, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Yogurt_Click(object sender, EventArgs e)
		{
			donut = new Donut("딸기요거트", 2000, 700, 200);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Rice_Click(object sender, EventArgs e)
		{
			donut = new Donut("딸기찰떡도넛", 2200, 900, 400);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void StrawberryFilled_Click(object sender, EventArgs e)
		{
			donut = new Donut("스트로베리필드", 1300, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void Caramel_Click(object sender, EventArgs e)
		{
			donut = new Donut("카라멜아이스드", 1500, 0, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

        //Cal
        private void button2_Click(object sender, EventArgs e)
        {
            minprice = 99999999;
            minsum = 99999999;
            
            //Solve();
            partition(donuts.Count, 0);
            textBox1.Text = minprice.ToString();
            textBox2.Text = (sum - minprice).ToString();
            if (alarm)
                textBox4.Text += "특판 권유하세요!";
            for (int i = 0; i < complete.Length; i++)
                textBox4.Text += complete[i].ToString();
        }

        private void Loaker_Click(object sender, EventArgs e)
		{
			donut = new Donut("로아커도넛", 2000, 700, 200);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void StrawberryCandy_Click(object sender, EventArgs e)
		{
			donut = new Donut("딸기캔디도넛", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}

		private void RichStawberry_Click(object sender, EventArgs e)
		{
			donut = new Donut("리치딸치도넛", 1800, 500, 0);
			donuts.Add(donut);
			UpdateForm(donut);
			//MakeSet();
			//textBox1.Text = solve(donuts.Count() / 6).ToString();
		}


        
		

		public Form1()
		{
			InitializeComponent();
		}

	}
}
// 17.3.20 재귀 사용
