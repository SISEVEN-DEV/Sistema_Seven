using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RedimensionarImagem
    {
        public static Image Redimensionar(Image originalImage, int maxWidth, int maxHeight)
        {
            // Calcula a proporção
            double ratioX = (double)maxWidth / originalImage.Width;
            double ratioY = (double)maxHeight / originalImage.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // Novo tamanho
            int newWidth = (int)(originalImage.Width * ratio);
            int newHeight = (int)(originalImage.Height * ratio);

            // Cria o novo bitmap redimensionado
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
    }
}
