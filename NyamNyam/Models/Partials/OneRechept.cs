using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamNyam.Models
{
    public partial class OneRechept
    {
        public double SumIng
        {
            get
            {
                double kolSum = 0;
                foreach (var item in App.DB.OneRechept.ToList())
                {
                    if (item.RecheptId == this.Rechept.Id)
                    {
                        kolSum = kolSum + (Double)item.Kol;
                    }
                }
                kolSum = kolSum * (Double)Rechept.Bludo.BaseServings;

                return kolSum;
            }
        }

        public bool IsEnableIngredient
        {
            get
            {
                if (this.SumIng <= this.Ingredient.Kol)
                    return true;
                return false;
            }
        }
    }
}
