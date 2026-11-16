using System;
using System.Text;

namespace Decorator.ChristmasTree
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Tree tree = new FirTree();
            tree.Show();
            Console.WriteLine();

            ToysDecorator toys = new ToysDecorator();
            toys.SetComponent(tree);
            toys.Show();
            Console.WriteLine();

            GarlandDecorator garland = new GarlandDecorator();
            garland.SetComponent(tree);
            garland.Show();
            Console.WriteLine();

            GarlandDecorator full = new GarlandDecorator();
            full.SetComponent(toys);
            full.Show();

            Console.Read();
        }
    }

    abstract class Tree
    {
        public abstract void Show();
    }

    class FirTree : Tree
    {
        public override void Show()
        {
            Console.WriteLine("Ялинка");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public void SetComponent(Tree tree)
        {
            this.tree = tree;
        }

        public override void Show()
        {
            if (tree != null)
            {
                tree.Show();
            }
        }
    }

    class ToysDecorator : TreeDecorator
    {
        private string balls = "червоні кульки";
        private string star = "золота зірка";
        private string icicles = "скляні бурульки";

        public override void Show()
        {
            base.Show();
            Console.WriteLine("  прикраси: {0}, {1}, {2}", balls, star, icicles);
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        public override void Show()
        {
            base.Show();
            Shine();
        }

        public void Shine()
        {
            Console.WriteLine("  гірлянда увімкнена, ялинка світиться");
        }
    }
}
