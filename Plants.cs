using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Plants
    {
        public static Random rnd = new Random();
        public int height = 0;
        public virtual String GetInfo()
        {
            var str = String.Format("\nВысота: {0}", this.height);
            return str;
        }

    }
    public enum Color { Белый, Красный, Желтый, Синий };
    public enum Type { Роза, Хризантема, Тюльпан };
    public class Flower : Plants
    {
        public int number = 0;
        public Color color = Color.Синий;
        public Type type = Type.Роза;
        public override String GetInfo()
        {
            var str = "Цветок";
            str += String.Format("\nКоличество липестков: {0}\nЦвет: {1}\nТип: {2}", this.number, this.color, this.type);
            str += base.GetInfo();
            return str;
        }

        public static Flower Generate()
        {

            return new Flower
            {
                number = rnd.Next() % 21,
                color = (Color)rnd.Next(4),
                type = (Type)rnd.Next(3),
                height = rnd.Next() % 5 + 1

            };
        }
    }
    public class Shrub : Plants
    {
        public bool isFlower = false;
        public int number = 0;
        public override String GetInfo()
        {
            var str = "Кустарник";
            str += String.Format("\nНаличие цветов: {0}\nКоличество веточек: {1}", this.isFlower, this.number);
            str += base.GetInfo();
            return str;

        }
        public static Shrub Generate()
        {

            return new Shrub
            {
                number = rnd.Next() % 21,
                isFlower = rnd.Next() % 2 == 0,
                height = rnd.Next() % 10 + 1


            };
        }
    }
    public enum TypeTree { Хвойное, Листовое };
    public class Tree : Plants
    {

        public TypeTree typetree = TypeTree.Листовое;
        public int Rad = 0;
        public override String GetInfo()
        {
            var str = "Дерево";
            str += base.GetInfo();
            str += String.Format("\nТип: {0}\nРадиус: {1}", this.typetree, this.Rad);
            return str;
        }
        public static Tree Generate()
        {

            return new Tree
            {
                height = rnd.Next() % 100 + 1,
                typetree = (TypeTree)rnd.Next(2),
                Rad = rnd.Next() % 100 + 20


            };
        }

    }
}
