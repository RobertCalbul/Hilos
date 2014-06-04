using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace hilos
{
    class ClassLabel
    {
        public int id {get;set;}
        public String nombre { get; set; }
        public int posx { get; set; }
        public int posy { get; set; }
        public Label ele { get; set; }
        public ClassLabel()
        { }
        public ClassLabel( String nombre,int posx, int posy)
        {
            this.nombre = nombre;
            this.posx = posx;
            this.posy = posy;
        }
        public ClassLabel(int id,String nombre, int posx, int posy, Label ele)
        {
            this.id = id;
            this.nombre = nombre;
            this.posx = posx;
            this.posy = posy;
            this.ele = ele;
        }

        public Label getLabel()
        {
            Label nueva = new Label();
            //nueva.Margin = new System.Windows.Thickness(this.posx, this.posy,0,0);
            nueva.Content = this.nombre;
            nueva.Width = 40;
            nueva.Height = 40;
            TranslateTransform translateTransform1 = new TranslateTransform(this.posx, this.posy);
            nueva.RenderTransform = translateTransform1;

            return nueva;
        }
       /* public ClassLabel getLabel()
        {
            Label nueva = new Label();
            //nueva.Margin = new System.Windows.Thickness(this.posx, this.posy,0,0);
            nueva.Content = this.nombre;
            nueva.Width = 40;
            nueva.Height = 40;
            TranslateTransform translateTransform1 = new TranslateTransform(this.posx, this.posy);
            nueva.RenderTransform = translateTransform1;
            //ClassLabel a =
            return new ClassLabel(this.id, this.nombre, this.posx, this.posy, this.ele);
        }*/

    }
}
