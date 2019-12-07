using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CardFactory
{
    public class CardFactory
    {
        public List<Bitmap> GetCards(int cardsCount)
        {
            List<Bitmap> result = new List<Bitmap>();
            for (int i = 0; i < cardsCount; i++)
            {
                result.Add((Bitmap)(CardResource.ResourceManager.GetObject("Card" + i.ToString())));
            }
            result.Add(CardResource.CardBack);
            return result;
        }
    }
}
