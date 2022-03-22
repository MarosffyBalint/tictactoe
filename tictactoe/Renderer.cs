using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace tictactoe
{
    class Renderer : FrameworkElement
    {

        public ILogic logic;
        Size size;

        public void SetupLogic(ILogic logic)
        {
            this.logic = logic;
        }

        public void ReSize(Size size)
        {
            this.size = size;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (logic != null && size.Width >0 && size.Height > 0)
            {
                for (int i = 0; i < logic.Board.GetLength(1); i++)
                {
                    for (int j = 0; j < logic.Board.GetLength(0); j++)
                    {
                        double rectWidth = size.Width / logic.Board.GetLength(1);
                        double rectHeight = size.Height / logic.Board.GetLength(0);
                        switch (logic.Board[i,j])
                        {
                            case 'o':
                                drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri("o.PNG", UriKind.RelativeOrAbsolute))), new Pen(Brushes.Black, 10), new Rect(i * rectWidth, j * rectHeight, rectWidth, rectHeight));
                                break;
                            case 'x':
                                drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri("x.PNG", UriKind.RelativeOrAbsolute))), new Pen(Brushes.Black, 10), new Rect(i * rectWidth, j * rectHeight, rectWidth, rectHeight));

                                break;
                            default:
                                drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 10), new Rect(i * rectWidth, j * rectHeight, rectWidth, rectHeight));
                                break;
                        }
                    }
                }
            }

        }
    }
}
