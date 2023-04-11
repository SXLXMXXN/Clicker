using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Clicker
{
    public class Controller
    {
        private MainWindow _mainWindow;
        public List<BaseAction> Actions = new List<BaseAction>();


        public void MouseMove(int coordX, int coordY)
        {
            // получаем текущее положение курсора
            Point currentPosition = MousePosition.GetMousePosition();

            // создаем анимацию движения курсора
            DoubleAnimation animationX = new DoubleAnimation(currentPosition.X, coordX, TimeSpan.FromSeconds(0.5));
            DoubleAnimation animationY = new DoubleAnimation(currentPosition.Y, coordY, TimeSpan.FromSeconds(0.5));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);

            // привязываем анимацию к свойству RenderTransform.TranslateTransform элемента
            TranslateTransform translateTransform = new TranslateTransform();
            this.RenderTransform = translateTransform;
            Storyboard.SetTarget(animationX, translateTransform);
            Storyboard.SetTarget(animationY, translateTransform);

            // запускаем анимацию
            storyboard.Begin();
            //Здесь newPosition -это новое положение курсора, к которому мы хотим его плавно переместить.Анимация будет длиться 0.5 секунды.
        }
    }
}
