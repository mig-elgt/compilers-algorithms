using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GramaticasRegulares.Clases.Gramatica
{
    /*Esta clase se utilza para almacenar una linea de texto del algoritmo*/
    class CLineText
    {
        private string text;//Linea a imprimir
        private float posX;
        private float posY;
        private FontStyle estilo;

        public CLineText(string text, float cX, float cY)
        {
            this.text = text;
            posX = cX;
            posY = cY;
            estilo = FontStyle.Regular;
        }

        public CLineText(string text, float cX, float cY, FontStyle s)
        {
            this.text = text;
            posX = cX;
            posY = cY;
            estilo = s;
        }

        public FontStyle getFontStyle()
        {  
            return (estilo);
        }

        public string getText()
        {
            return(text);
        }

        public float getX()
        {
           return(posX);
        }

        public float getY()
        {
           return(posY);
        }
    }
}
