using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CardFactory
{
    public static class CardFactory
    {
        public static List<Bitmap> GetCards(int cardsCount)
        {
            List<Bitmap> result = new List<Bitmap>();
            for (int i = 0; i < cardsCount; i++)
            {
                result.Add((Bitmap)(CardResource.ResourceManager.GetObject("Card" + i.ToString())));
            }
            return result;
        }
        public static Bitmap GetCardBack()
        {
            return CardResource.CardBack;
        }
    }
}
