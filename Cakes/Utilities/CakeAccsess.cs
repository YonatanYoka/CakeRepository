using CakesData.Model;
using System;
using CakesData.DataAccess;

namespace CakesData.Utilities
{
    public static class CakeAccsess
    {

        public static Cake CreateCake(int size, int type, string _description)
        {
            using (var context = new DBContext())
            {
                try
                {
                    Cake newcake = new Cake()
                    {
                        CakeSize = (SizeInfo)size,
                        CakeType = (CakesInfo)type,
                        Description = _description,
                        CakeName = $"{(CakesInfo)type} {(SizeInfo)size} {_description.Substring(0, _description.Length / 2)}",
                        CakePrice = (size * 10) + (type * 15)
                    };

                    return newcake;

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }
}
