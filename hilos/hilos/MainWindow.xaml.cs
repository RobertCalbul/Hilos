using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace hilos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Label> labels;
        Point PositionMouseScreen;
        public Label LabelSelected = new Label();
        public TextBox TextSelected = new TextBox();
        Point posActual;
        
        public MainWindow()
        {
            InitializeComponent();
            labels = new List<Label>(); 

        }
        Boolean flagLabel = false;
        Boolean flagText = false; 
        int contador = 0;
        private void Centro_Drop(object sender, DragEventArgs e)
        {
            SolidColorBrush scb = (SolidColorBrush)e.Data.GetData(typeof(SolidColorBrush));
            
            Console.WriteLine("scb: "+scb);
            if (scb == (SolidColorBrush)referencia.Fill) Centro.Fill = scb;
            else MessageBox.Show("No es el color correcto");
        }

        private void rec_mouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            Rectangle r = (Rectangle)sender;
            DataObject Do = new DataObject(r.Fill);
            DragDrop.DoDragDrop(r,Do,DragDropEffects.All);
         }
 
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            PositionMouseScreen = e.GetPosition(this.workSpace);
            pos.Content = "x: " + PositionMouseScreen.X + "   Windoww\ny: " + PositionMouseScreen.Y;
        }

        
        private void lIf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SolidColorBrush[] brushes = new SolidColorBrush[] 
                                        {   Brushes.Green, Brushes.BurlyWood,Brushes.CadetBlue,
                                            Brushes.Gray,Brushes.Chartreuse,Brushes.Chocolate,
                                            Brushes.AliceBlue,Brushes.Coral,Brushes.CornflowerBlue,
                                            Brushes.AntiqueWhite,Brushes.Cornsilk,Brushes.Crimson,
                                            Brushes.Aqua,Brushes.Cyan,Brushes.DarkBlue,Brushes.DarkCyan,
                                            Brushes.Aquamarine,Brushes.DarkGoldenrod,Brushes.DarkGray,
                                            Brushes.Azure,Brushes.DarkGreen,Brushes.DarkKhaki,
                                            Brushes.Beige,Brushes.DarkMagenta,Brushes.DarkOliveGreen,
                                            Brushes.Bisque,Brushes.DarkOrange,Brushes.DarkOrchid,
                                            Brushes.Black,Brushes.DarkRed,Brushes.DarkSalmon,
                                            Brushes.BlanchedAlmond,Brushes.DarkSeaGreen,Brushes.DarkSlateBlue,
                                            Brushes.Blue,Brushes.DarkSlateGray,Brushes.DarkTurquoise,
                                            Brushes.BlueViolet,Brushes.Brown,Brushes.DarkViolet
                                        };
            Label a = new Label() { Content="Label "+contador};
            a.Name = "s"+contador;
            a.Background = brushes[new Random().Next(brushes.Length)];
            a.HorizontalAlignment =System.Windows.HorizontalAlignment.Left;
            a.VerticalAlignment =  System.Windows.VerticalAlignment.Top;
            a.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.label_mouseDown);
            a.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.mouseLeftButtonDown);
            
            this.workSpace.Children.Add(a);
            a.Margin = new Thickness(500,500,0,0);
            contador++;
        }
        
        private void mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (Label)sender;
            LabelSelected = l;
            posActual = PositionMouseScreen;
            Console.WriteLine("PASO?");
            flagLabel = false; 
            
        }
        private void label_mouseDown(object sender, MouseButtonEventArgs e)
        {

            Label label = (Label)sender;
            Console.WriteLine(label.Name.ToString());
            flagLabel = true;
        }
        

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point posNext = PositionMouseScreen;

            int posx = 0;
            int posy = 0;
            posx += (Convert.ToInt32(posNext.X - posActual.X) + 1) * -1;
            posy += Convert.ToInt32(posNext.Y - posActual.Y) * -1;

            Console.WriteLine("WINDOWS MOUSE UP \nTEXT " + flagText + "\nLABEL   " + flagLabel);
                //LabelSelected.Margin = new Thickness(posNext.X, posNext.Y, 0, 0);
            if (flagLabel)
            {
                LabelSelected.Margin = new Thickness(posNext.X, posNext.Y, 0, 0);
                //TranslateTransform translate = new TranslateTransform(posx*-1, posy*-1);
                //LabelSelected.RenderTransform = translate;
                LabelSelected.Content = posx * -1 + "," + posy * -1;
                this.referencia.Margin = new Thickness(posNext.X, posNext.Y, 0, 0);
            }
            if (flagText)
            {
                TextSelected.Margin = new Thickness(posNext.X, posNext.Y, 0, 0);
                //TranslateTransform translate = new TranslateTransform(posx*-1, posy*-1);
                //LabelSelected.RenderTransform = translate;
                TextSelected.Text = posx * -1 + "," + posy * -1;
            }
            flagLabel = false;
            flagText = false;
        }
        //CREA TEXBOX
        int contC = 0;
        private void for_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SolidColorBrush[] brushes = new SolidColorBrush[] 
                                        {   Brushes.Green, Brushes.BurlyWood,Brushes.CadetBlue,
                                            Brushes.Gray,Brushes.Chartreuse,Brushes.Chocolate,
                                            Brushes.AliceBlue,Brushes.Coral,Brushes.CornflowerBlue,
                                            Brushes.AntiqueWhite,Brushes.Cornsilk,Brushes.Crimson,
                                            Brushes.Aqua,Brushes.Cyan,Brushes.DarkBlue,Brushes.DarkCyan,
                                            Brushes.Aquamarine,Brushes.DarkGoldenrod,Brushes.DarkGray,
                                            Brushes.Azure,Brushes.DarkGreen,Brushes.DarkKhaki,
                                            Brushes.Beige,Brushes.DarkMagenta,Brushes.DarkOliveGreen,
                                            Brushes.Bisque,Brushes.DarkOrange,Brushes.DarkOrchid,
                                            Brushes.Black,Brushes.DarkRed,Brushes.DarkSalmon,
                                            Brushes.BlanchedAlmond,Brushes.DarkSeaGreen,Brushes.DarkSlateBlue,
                                            Brushes.Blue,Brushes.DarkSlateGray,Brushes.DarkTurquoise,
                                            Brushes.BlueViolet,Brushes.Brown,Brushes.DarkViolet
                                        };
            TextBox b = new TextBox() { Text = "Label " + contC };
            b.Name = "s" + contador;
            b.Background = brushes[new Random().Next(brushes.Length)];
            b.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            b.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            b.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_PreviewMouseLeftButtonDown);
            b.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_PreviewDown);
            this.workSpace.Children.Add(b);
            b.Margin = new Thickness(0, 0, 0, 0);
            contC++;
        }


        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox l = (TextBox)sender;
            TextSelected = l;
            posActual = PositionMouseScreen;
            
            flagText = false;
            Console.WriteLine("TextBox_PreviewMouseLeftButtonDown     FALSE");
        }

        private void TextBox_PreviewDown(object sender, MouseButtonEventArgs e)
        {
            TextBox label = (TextBox)sender;
            
            flagText = true;
            Console.WriteLine("TextBox_PreviewDown   TRUE");
            //Window_MouseUp(sender, e);
        }
    }
}
