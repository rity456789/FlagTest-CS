using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1612041_MiniGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const String DiaChiChua = "C:\\Users\\User\\source\\repos"; //Dia chi chua solution

        //khai bao cac du lieu
        String[] DiaChiHinhAnh = new String[10];
        String[] DapAn = new String[15];    // Dap an dung chi tu 1 den 10 ung voi 10 tam hinh, 5 dap an phu
        int[] ThuTu = new int[10];  //Phat sinh ngau nhien tu 1 den 10 de random cau hoi
        int[] TraiPhai = new int[10]; //Phat sinh ngau nhien dap an dung nam ben trai hoac phai

        int score = new int();
        int currentQ = new int();
        

        public void createRandom()
        {
            Random rd = new Random();
            for (int i=0;i<10;i++)
            {
                ThuTu[i] = rd.Next(0, 10);
                for (int j=0;j<i;j++)
                {
                    
                    if (ThuTu[i]==ThuTu[j]) //Hinh nay da duoc xuat hien
                    {
                        i--;   // Thi random lai
                        break;
                    }
                }
                
            }

            for(int i=0;i<10;i++)
            {
                TraiPhai[i] = rd.Next(0, 2);
            }
        }

        public void createData()    //bao gom luon create first question
        {
            score = 0;
            currentQ = 0;

            DiaChiHinhAnh[0] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\1.png";
            DiaChiHinhAnh[1] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\2.png";
            DiaChiHinhAnh[2] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\3.png";
            DiaChiHinhAnh[3] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\4.png";
            DiaChiHinhAnh[4] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\5.png";
            DiaChiHinhAnh[5] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\6.gif";
            DiaChiHinhAnh[6] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\7.jpg";
            DiaChiHinhAnh[7] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\8.gif";
            DiaChiHinhAnh[8] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\9.gif";
            DiaChiHinhAnh[9] = System.IO.Directory.GetCurrentDirectory().ToString() + "\\hinh\\10.jpg";

            DapAn[0] = "Germany";
            DapAn[1] = "France";
            DapAn[2] = "Argentina";
            DapAn[3] = "Uruguay";
            DapAn[4] = "Italia";
            DapAn[5] = "Japan";
            DapAn[6] = "Brazil";
            DapAn[7] = "Canada";
            DapAn[8] = "Croatia";
            DapAn[9] = "Portugal";
            DapAn[10] = "Thailand";
            DapAn[11] = "Russia";
            DapAn[12] = "Korea";
            DapAn[13] = "VietNam";
            DapAn[14] = "China";

            // create first question
            img.Source = new BitmapImage(new Uri(DiaChiHinhAnh[ThuTu[currentQ]]));
            Random rd = new Random();
            int temp;
            if (TraiPhai[currentQ] == 0)
            {
                btn1.Content = DapAn[ThuTu[currentQ]];
                do
                {
                    temp = rd.Next(0, 15);
                    btn2.Content = DapAn[temp];
                } while (temp == ThuTu[currentQ]);
            }
            else
            {
                btn2.Content = DapAn[ThuTu[currentQ]];
                do
                {
                    temp = rd.Next(0, 15);
                    btn1.Content = DapAn[temp];
                } while (temp == ThuTu[currentQ]);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            createRandom();
            createData();
        }

        

        private void onClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Content.ToString()== DapAn[ThuTu[currentQ]])
            {
                score += 10;
            }
            if (currentQ == 9)  //Da la cau hoi cuoi cung
            {
                StringBuilder str = new StringBuilder();
                str.Append($"Tro choi ket thuc, diem so cua ban la {score}.");
                MessageBox.Show(str.ToString());
                this.Close();
                return;
            };

            currentQ++;
            //Khoi tao cau hoi tiep theo
            img.Source = new BitmapImage(new Uri(DiaChiHinhAnh[ThuTu[currentQ]]));
            Random rd = new Random();
            int temp;
            if (TraiPhai[currentQ] == 0)
            {
                btn1.Content = DapAn[ThuTu[currentQ]];
                do
                {
                    temp = rd.Next(0, 15);
                    btn2.Content = DapAn[temp];
                } while (temp == ThuTu[currentQ]);
            }
            else
            {
                btn2.Content = DapAn[ThuTu[currentQ]];
                do
                {
                    temp = rd.Next(0, 15);
                    btn1.Content = DapAn[temp];
                } while (temp == ThuTu[currentQ]);
            }

        }
    }
}
