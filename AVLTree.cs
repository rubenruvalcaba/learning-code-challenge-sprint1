using System;

public class AVLTree
{

    public class AVLNode
    {
        public int Value { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }
        public int Height { get; set; }
        public int BalanceFactor
        {
            get
            {
                return LeftHeight - RightHeight;
            }
        }

        public bool isLeftHeavy
        {
            get
            {
                return BalanceFactor > 0;
            }
        }

        public bool isRigthHeavy
        {
            get
            {
                return BalanceFactor < 0;
            }
        }

        public int LeftHeight
        {
            get
            {
                return (Left == null ? 0 : Left.Height);
            }
        }
        public int RightHeight
        {
            get
            {
                return (Right == null ? 0 : Right.Height);
            }
        }

        public AVLNode(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Value = {Value.ToString()} Height={Height.ToString()}";
        }





    }

    AVLNode root;

    public AVLTree(int[] values)
    {
        foreach (var i in values)
        {
            Insert(i);
        }
    }

    public void Insert(int value)
    {
        if (root == null)
            root = new AVLNode(value);
        else
            Insert(root, value);

    }

    private void Insert(AVLNode parentNode, int value)
    {
        if (value < parentNode.Value)
            if (parentNode.Left == null)
                parentNode.Left = new AVLNode(value);
            else
                Insert(parentNode.Left, value);
        else
        {
            if (parentNode.Right == null)
                parentNode.Right = new AVLNode(value);
            else
                Insert(parentNode.Right, value);
        }

        parentNode.Height = Math.Max(parentNode.LeftHeight, parentNode.RightHeight) + 1;
        Balance(parentNode);
      
    }

    private void Balance(AVLNode root)
    {
        if (root.isRigthHeavy)
        {
            if (root.Right.BalanceFactor > 0)
                Console.WriteLine("rotate right " + root.Right.Value.ToString());

            Console.WriteLine("Left rotate " + root.Value.ToString());
        }
        else if (root.isLeftHeavy)
        {
            if (root.Left.BalanceFactor < 0)
                Console.WriteLine("Left rotate" + root.Left.Value.ToString());
            Console.WriteLine("Right rotate " + root.Right.Value.ToString());
        }
    }


}