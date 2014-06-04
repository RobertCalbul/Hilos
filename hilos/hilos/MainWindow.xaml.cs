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
        Point posActual;
        Point posNext;
        public MainWindow()
        {
            InitializeComponent();
            labels = new List<Label>(); 

        }

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

        int contador = 0;
        private void lIf_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Label a = new ClassLabel("label "+contador,90,10).getLabel();
            a.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.label_mouseDown);
            a.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.label_mouseUp);

            this.workSpace.Children.Add(a);
            contador++;
        }

        private void label_mouseDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (Label)sender;
            LabelSelected = l;
            posActual = PositionMouseScreen;
           // Console.WriteLine("DOWN >>>"+posActual.X+" "+posActual.Y);
            
        }
        private void label_mouseUp(object sender, MouseButtonEventArgs e)
        {

            Console.WriteLine("UP>>>" );

        }


        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            posNext = PositionMouseScreen;
           
            double posx = 0;
            double posy = 0;
            double tx = this.LabelSelected.Width / 2; 
            double ty = this.LabelSelected.Height / 2;
            posx = ((posActual.X-tx)-(posNext.X-tx));
            posy = ((posActual.Y-ty)-(posNext.Y-ty));
            Console.WriteLine("<<------------------->>");
            Console.WriteLine("comparacion actual Next\nx"+posActual.X + ">" + posNext.X + "\ny" + posActual.Y + ">" + posNext.Y);
            Console.WriteLine("\nposicion final\nx" +( posActual.X - posx )+ " y" + (posActual.Y-posy));
            TranslateTransform translate = new TranslateTransform(posx*-1, posy*-1);
            Console.WriteLine("\nposicion invertida\nx" + posx * -1 + " y" + posy * -1);
            LabelSelected.RenderTransform = translate;
        }


    }
}
