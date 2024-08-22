using System;
using System.Windows.Forms;

namespace ProxyApp
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            PictureProxy proxy = new PictureProxy();//создание ЗАМЕСТИТЕЛЯ
            proxy.pictplace = pictureBox1;//передача заместителю ссылки на созданный на форме picturebox1
            proxy.Show(textBox1.Text);//вызов метода ЗАМЕСТИТЕЛЯ
        }


    }
    interface IPicture//интерфейс, реализуемый объектом и заместителем
    {
        void Show(string adress);
    }
    class Picture : IPicture//класс-объект
    {
        public PictureBox pictplace;//ссылка на picturebox для отображения картинки
        

        public void Show(string adress)
        {
            pictplace.LoadAsync(adress);//асинхронная загрузка изображения по адресу с использованием собственного функционала picturebox
        }
    }

    class PictureProxy : IPicture//класс-заместитель 
    {
        public PictureBox pictplace;//ссылка на picturebox для отображения картинки
        private Picture picture;
        public void Show(string adress)
        {

            pictplace.Load("proxy.png");//загрузка картинки-заместителя из корневой папки проекта
            
            if (picture == null)
            {
                picture = new Picture();
            }
            picture.pictplace = pictplace;//передача объекту ссылки на picturebox
            picture.Show(adress);

        }
    }
}
//ссылка на gif-изображение для примера
//https://i.gifer.com/embedded/download/OC9y.gif