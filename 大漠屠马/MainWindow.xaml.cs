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
using XXDM.MyDM;
using System.Threading;
namespace 大漠屠马
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static XDm dm = new XDm();
        private static readonly int hwnd = dm.FindWindow("GLFW30", "", 0);

        private string hongtou = "fbfbfb-000000|ffffff-000000|fdfdfd-000000";
        private double hongtoujd = 0.9;
        private int tmCount = 0;
        private bool isTuma = false;
        private int width = 1280, height = 1024;

        public MainWindow()
        {
            InitializeComponent();

            dm.SetClientSize(hwnd, width, height);
            dm.SetKeypadDelay("normal", 70);
            dm.EnableRealKeypad(1);
            dm.EnableRealMouse(1, 10, 50);

        }
        #region 回城
        private void huicheng()
        {
            Thread.Sleep(1000);
            //dm.GetClientSize(hwnd, out width, out height);
            //dm.CreateFoobarRect(hwnd, width - 200, 0, width, height);
            dm.SetWindowState(hwnd, 1);
            Console.WriteLine("绑定: " + dm.BindWindow(hwnd, "gdi", "normal", "normal", 0));
            dm.EnableIme(0);

            int nextMouseX, nextMouseY;

            Console.WriteLine("选择飞行技能:鼠标移动到({0},{1})", 790, 40);
            dm.MoveTo(790, 40);
            Thread.Sleep(120);
            dm.LeftClick();
            Thread.Sleep(600);
            Console.WriteLine("选择笼目镇:鼠标移动到({0},{1})", 920, 390);
            dm.MoveTo(920, 390);
            dm.LeftDoubleClick();
            Thread.Sleep(100);
            dm.LeftDoubleClick();
            Thread.Sleep(6066);
            dm.SetWindowState(hwnd, 1);
            Console.WriteLine("按住w");
            dm.SetWindowState(hwnd, 1);
            dm.KeyDown(XXDM.Helper.EnumHelper.KeyCode.w);
            Thread.Sleep(3555);
            bool isDao = false;


            for (int i = 0; i < 10; i++)
            {
                if (dm.FindColor(657, 116, 663, 122, "56ba9f-000000", 0.98, 1, out nextMouseX, out nextMouseY) == 1)
                //if (dm.FindPic(500, 0, 700, 500, img_pokemonCenter, "000000", 0.6, 1, out nextMouseX, out nextMouseY) != -1)
                {
                    dm.MoveTo(nextMouseX, nextMouseY);
                    isDao = true;
                    Console.WriteLine("到达护士面前");
                    Console.WriteLine("放开w");
                    dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.w);
                    Thread.Sleep(300);
                    Console.WriteLine("点击e");
                    dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.e);
                    break;
                }
                else
                {
                    Thread.Sleep(500);
                }

            }
            if (isDao == false)
            {
                Console.WriteLine("到达护士面前错误");
                Console.WriteLine("放开w");
                dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.w);
                Console.WriteLine("窗口句柄释放");
                dm.UnBindWindow();
                throw new Exception("到达护士面前错误");
            }






            isDao = false;
            int findCount = 0;
            for (int i = 0; i < 3;)
            {
                if (dm.FindColor(1015, 144, 1024, 152, "191919-000000", 0.98, 7, out nextMouseX, out nextMouseY) == 1)
                {
                    dm.MoveTo(nextMouseX, nextMouseY);
                    dm.LeftClick();
                    Console.WriteLine("对话点击下一步");
                    i++;
                    if (i == 2)
                    {
                        //Thread.Sleep(800);
                        //Console.WriteLine("点击e");
                        //dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.e);
                        int jishu = 0;
                        bool isDone = false;
                        while (jishu < 8)
                        {
                            Console.WriteLine("寻找是");
                            if (dm.FindColor(632, 602, 642, 612, "ffffff-000000|fcfcfc-000000|fdfdfd-000000", 1, 7, out nextMouseX, out nextMouseY) == 1)
                            {
                                Console.WriteLine("寻找是");
                                dm.MoveTo(nextMouseX, nextMouseY);
                                dm.LeftClick();
                                isDone = true;
                                break;

                            }
                            else
                            {
                                jishu++;
                                isDone = false;
                            }
                            Thread.Sleep(800);
                        }
                        if (isDone == false)
                        {
                            Console.WriteLine("点击是错误");
                            Console.WriteLine("窗口句柄释放");
                            dm.UnBindWindow();
                            throw new Exception("点击是错误");
                        }



                    }
                }
                else
                {
                    findCount++;
                    if (findCount > 100)
                    {
                        Console.WriteLine("对话出错");
                        Console.WriteLine("窗口句柄释放");
                        dm.UnBindWindow();
                        throw new Exception("到达精灵中心口错误");
                    }
                }
                Thread.Sleep(800);
            }

            Console.WriteLine("精灵恢复完毕");
            Thread.Sleep(1500);
            Console.WriteLine("按住s");
            dm.SetWindowState(hwnd, 1);
            dm.KeyDown(XXDM.Helper.EnumHelper.KeyCode.s);
            Thread.Sleep(1200);
            isDao = false;
            for (int i = 0; i < 100; i++)
            {
                if (dm.FindColor(650, 450, 652, 452, "e000000-000000", 1, 7, out nextMouseX, out nextMouseY) == 1)
                //if (dm.FindPic(500, 0, 700, 500, img_pokemonCenter, "000000", 0.6, 1, out nextMouseX, out nextMouseY) != -1)
                {
                    dm.MoveTo(nextMouseX, nextMouseY);
                    isDao = true;
                    Console.WriteLine("到达精灵中心口");
                    Console.WriteLine("放开s");
                    dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.s);
                    break;
                }
                else
                {
                    Thread.Sleep(20);
                }

            }
            if (isDao == false)
            {
                Console.WriteLine("到达精灵中心口错误");
                Console.WriteLine("放开s");
                dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.s);
                Console.WriteLine("窗口句柄释放");
                dm.UnBindWindow();
                throw new Exception("到达精灵中心口错误");
            }

            Thread.Sleep(300);
            Console.WriteLine("按住q");
            dm.SetWindowState(hwnd, 1);
            dm.KeyDown(XXDM.Helper.EnumHelper.KeyCode.q);
            Console.WriteLine("按住a");
            dm.KeyDown(XXDM.Helper.EnumHelper.KeyCode.a);
            Thread.Sleep(5500);
            Console.WriteLine("放开q");
            dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.q);

            isDao = false;
            for (int i = 0; i < 150; i++)
            {
                Console.WriteLine("寻找屠马厂顶点");
                if (dm.FindColor(870, 80, 1280, 90, hongtou, hongtoujd, 1, out nextMouseX, out nextMouseY) == 1)
                //if (dm.FindPic(820, 70, 1250, 120, img_ddd, "000000", 0.7, 2, out nextMouseX, out nextMouseY) != -1)
                {
                    dm.MoveTo(nextMouseX, nextMouseY);
                    isDao = true;
                    Console.WriteLine("到达屠马转角");
                    Console.WriteLine("放开a");
                    dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.a);
                    break;
                }
                else
                {
                    Thread.Sleep(500);
                }

            }
            if (isDao == false)
            {
                Console.WriteLine("到达屠马转角错误");
                Console.WriteLine("放开a");
                dm.KeyUp(XXDM.Helper.EnumHelper.KeyCode.a);
                Console.WriteLine("窗口句柄释放");
                dm.UnBindWindow();
                throw new Exception("到达屠马转角错误");
            }
            Thread.Sleep(1000);
            Console.WriteLine("点击w");
            dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.w);
            Thread.Sleep(1000);
            Console.WriteLine("点击w");
            dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.w);
            Thread.Sleep(400);




            Console.WriteLine("窗口句柄释放");
            dm.UnBindWindow();


        }
        #endregion

        #region 屠马
        private void tuma()
        {
            dm.SetWindowState(hwnd, 1);
            Console.WriteLine("绑定: " + dm.BindWindow(hwnd, "gdi", "normal", "normal", 0));
            dm.EnableIme(0);

            int nextMouseX = 850;
            int nextMouseY = 40;
            dm.MoveTo(nextMouseX, nextMouseY);
            dm.LeftClick();

            Thread.Sleep(4200);

            bool isDao = false;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("检查是否开始战斗");
                if (dm.FindColor(775, 451, 780, 453, "398643-000000|398542-000000|83cf8d-000000|82ce8c-000000|388442-000000", 0.98, 1, out nextMouseX, out nextMouseY) == 1)
                //if (dm.FindPic(500, 0, 1100, 650, img_tumapai, "000000", 0.7, 2, out nextMouseX, out nextMouseY) != -1)
                {
                    dm.MoveTo(nextMouseX, nextMouseY);
                    Thread.Sleep(500);
                    if (dm.FindColor(500, 70, 1090, 350, "f1eb65-000000|f2ea68-000000|f1ea66-000000", 0.98, 1, out nextMouseX, out nextMouseY) == 1)
                    {
                        Console.WriteLine("闪光！！！");
                        dm.MoveTo(nextMouseX, nextMouseY);
                        Console.Beep(800, 10000);
                        MessageBox.Show("发现闪光!");




                        Console.WriteLine("窗口句柄释放");
                        dm.UnBindWindow();
                        return;
                    }
                    isDao = true;
                    Console.WriteLine("准备好战斗");
                    Console.WriteLine("按e三xia ");
                    Thread.Sleep(1420);
                    dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.e);
                    Thread.Sleep(220);
                    dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.e);
                    Thread.Sleep(320);
                    dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.e);
                    Thread.Sleep(320);
                    dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.e);
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }

            }
            if (isDao == false)
            {
                Console.WriteLine("发生战斗错误");
                Console.WriteLine("窗口句柄释放");
                dm.UnBindWindow();
                throw new Exception("发生战斗错误");
            }

            Thread.Sleep(10000);
            isDao = false;
            Console.WriteLine("检查是否战斗结束");
            for (int i = 0; i < 40; i++)
            {
                if (dm.FindColor(1250, 50, 1254, 55, "000000-000000", 1, 1, out nextMouseX, out nextMouseY) != 1)
                //if (dm.FindPic(500, 0, 1100, 650, img_tumapai, "000000", 0.7, 2, out nextMouseX, out nextMouseY) != -1)
                {
                    dm.MoveTo(nextMouseX, nextMouseY);
                    Thread.Sleep(1000);
                    isDao = true;
                    Console.WriteLine("战斗成功结束");
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("战斗轮询---按下q键");
                    dm.KeyPress(XXDM.Helper.EnumHelper.KeyCode.q);
                }

            }
            if (isDao == false)
            {
                Console.WriteLine("战斗结束错误");
                Console.WriteLine("窗口句柄释放");
                dm.UnBindWindow();
                throw new Exception("战斗结束错误");
            }


            Console.WriteLine("窗口句柄释放");
            dm.UnBindWindow();
        }
        #endregion


        #region 按钮事件
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dm.CreateFoobarRect(hwnd, 180, 0, 80, 200);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn_XunDianTest.IsEnabled = false;
            double TMG = Convert.ToDouble(txt_TMG.Text);
            string TMG_Se = txt_TMG_Se.Text;
            int nextMouseX, nextMouseY;
            dm.SetWindowState(hwnd, 1);
            Console.WriteLine("绑定: " + dm.BindWindow(hwnd, "gdi", "normal", "normal", 0));
            if (dm.FindColor(500, 70, 1090, 350, TMG_Se, TMG, 1, out nextMouseX, out nextMouseY) == 1)
            //if (dm.FindPic(810, 65, 1250, 120, img_ddd, "000000", TMG, 2, out nextMouseX, out nextMouseY) != -1)
            {
                Console.WriteLine(nextMouseX + " " + nextMouseY);
                dm.MoveTo(nextMouseX, nextMouseY);
            }
            else
            {
                Console.WriteLine("未找到");
            }


            Console.WriteLine("窗口句柄释放");
            dm.UnBindWindow();
            btn_XunDianTest.IsEnabled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dm.SetWindowState(hwnd, 1);
            Console.WriteLine("绑定: " + dm.BindWindow(hwnd, "gdi", "normal", "normal", 0));
            dm.EnableIme(0);
            int nextMouseX = int.Parse(txtX.Text);
            int nextMouseY = int.Parse(txtY.Text);
            Console.WriteLine("鼠标移动到({0},{1})", nextMouseX, nextMouseY);
            dm.MoveTo(nextMouseX, nextMouseY);
            Console.WriteLine("窗口句柄释放");
            dm.UnBindWindow();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {

            Console.Beep();
            Console.WriteLine("置顶窗口");
            dm.SetWindowState(hwnd, 8);


            if (btnAuto.Content.ToString() == "自动屠马")
            {
                btnAuto.Content = "停止自动屠马";

                isTuma = true;
                Console.WriteLine("回城");
                huicheng();


                Task.Factory.StartNew(() =>
                {
                    int i = 1;
                    while (isTuma)
                    {
                        Console.WriteLine("屠马第{0}次 ", tmCount);
                        try
                        {
                            tuma();
                        }
                        catch
                        {
                            for (int q = 0; q < 20; q++)
                            {
                                Console.Beep();
                            }
                            huicheng();
                            if (i == 1)
                            {
                                break;
                            }
                            i = 1;
                        }
                        Dispatcher.Invoke(() =>
                        {
                            txtCount.Text = tmCount.ToString();
                        });
                        Thread.Sleep(1000);
                        if (i % 6 == 0)
                        {
                            Console.WriteLine("回程一波 ");
                            try
                            {
                                huicheng();
                            }
                            catch
                            {
                                for (int q = 0; q < 20; q++)
                                {
                                    Console.Beep();
                                }
                            }
                            Thread.Sleep(500);
                        }
                        i++;
                        tmCount++;

                    }
                    Console.WriteLine("自动屠马已经结束");
                    Console.WriteLine("取消置顶窗口");
                    dm.SetWindowState(hwnd, 9);
                    Dispatcher.Invoke(() =>
                    {
                        btnAuto.IsEnabled = true;
                        btnAuto.Content = "自动屠马";
                    });
                });

            }
            else
            {
                btnAuto.Content = "等待停止屠马...";
                btnAuto.IsEnabled = false;
                isTuma = false;


            }
        }

        private void btnTm_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                tuma();
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                huicheng();
            });
        }
        #endregion

    }
}
