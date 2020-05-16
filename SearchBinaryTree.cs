using System;
using System.Collections.Generic;

public class SearchBinaryTree
{

    private class Node
    {
        public readonly int Value;
        internal Node LeftChild;
        internal Node RightChild;
        public Node(int value)
        {
            Value = value;
        }

        internal void Insert(int value)
        {
            if (value > Value)
            {
                if (RightChild == null)
                {
                    RightChild = new Node(value);
                    return;
                }
                else
                {
                    RightChild.Insert(value);
                }
            }
            else if (value < Value)
            {
                if (LeftChild == null)
                {
                    LeftChild = new Node(value);
                    return;
                }
                else
                {
                    LeftChild.Insert(value);
                }
            }
        }

        internal bool Find(int value)
        {

            if (value < Value)
                if (LeftChild != null)
                    return LeftChild.Find(value);
                else
                    return false;
            else if (value > Value)
                if (RightChild != null)
                    return RightChild.Find(value);
                else
                    return false;
            else
                return true;

        }

        internal void TraversePreOrder(List<int> traversedList)
        {

            traversedList.Add(Value);


            if (LeftChild != null)
                LeftChild.TraversePreOrder(traversedList);


            if (RightChild != null)
                RightChild.TraversePreOrder(traversedList);

        }
        internal void TraverseInOrder(List<int> traversedList)
        {
            if (LeftChild != null)
                LeftChild.TraverseInOrder(traversedList);

            traversedList.Add(Value);

            if (RightChild != null)
                RightChild.TraverseInOrder(traversedList);

        }
        internal void TraversePostOrder(List<int> traversedList)
        {
            if (LeftChild != null)
                LeftChild.TraversePostOrder(traversedList);

            if (RightChild != null)
                RightChild.TraversePostOrder(traversedList);

            traversedList.Add(Value);

        }

        internal bool Validate()
        {
            if (LeftChild != null)
                if (!LeftChild.Validate(null, Value - 1))
                    return false;
            if (RightChild != null)
                if (!RightChild.Validate(Value + 1, null))
                    return false;

            return true;
        }

        private bool Validate(int? min, int? max)
        {
            if (min != null && Value < min.Value)
                return false;

            if (max != null && Value > max.Value)
                return false;

            if (LeftChild != null)
                if (!LeftChild.Validate(min, Value - 1))
                    return false;

            if (RightChild != null)
                if (!RightChild.Validate(Value + 1, max))
                    return false;

            return true;
        }
        internal void NodesAtK(List<Node> nodes, int parentLevel, int K)
        {
            var level = parentLevel + 1;
            if (level == K)
            {
                nodes.Add(this);
                return;
            }

            if (LeftChild != null)
                LeftChild.NodesAtK(nodes, level, K);

            if (RightChild != null)
                RightChild.NodesAtK(nodes, level, K);

        }

        public override string ToString()
        {
            return Value.ToString();
        }


    }

    private Node Root;

    public SearchBinaryTree()
    {

    }

    public SearchBinaryTree(int[] array)
    {
        foreach (var i in array)
            Insert(i);
    }

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        Root.Insert(value);

    }

    public bool Find(int value)
    {
        if (Root != null)
            return Root.Find(value);
        return false;
    }

    public int[] TraversePreOrder()
    {
        if (Root == null)
            return new int[] { };

        var Traversed = new List<int>();
        Root.TraversePreOrder(Traversed);

        return Traversed.ToArray();

    }
    public int[] TraverseInOrder()
    {
        if (Root == null)
            return new int[] { };

        var Traversed = new List<int>();
        Root.TraverseInOrder(Traversed);

        return Traversed.ToArray();

    }

    public int[] TraversePostOrder()
    {
        if (Root == null)
            return new int[] { };

        var Traversed = new List<int>();
        Root.TraversePostOrder(Traversed);

        return Traversed.ToArray();
    }

    public bool Equals(SearchBinaryTree tree)
    {

        if (tree == null)
            throw new Exception("Can't compare against a null tree");

        var leftTraverse = TraverseInOrder();
        var rightTraverse = tree.TraverseInOrder();
        for (var i = 0; i < leftTraverse.Length - 1; i++)
            if (leftTraverse[i] != rightTraverse[i])
                return false;

        return true;
    }

    public bool Validate()
    {
        if (Root == null)
            return true;

        if (!Root.Validate())
            return false;

        return true;
    }

    public void CreateInvalidTree()
    {
        Insert(20);
        Root.LeftChild = new Node(10);
        var left = Root.LeftChild;
        left.RightChild = new Node(21);
        left.LeftChild = new Node(6);
        left.LeftChild.Insert(3);
        left.LeftChild.Insert(8);

        Root.RightChild = new Node(30);
        var right = Root.RightChild;
        right.LeftChild = new Node(4);

    }

    public int[] NodesAtK(int K)
    {
        if (Root == null)
            return new int[] { };

        if (K == 0)
            return new int[] { Root.Value };

        var nodes = new List<Node>();
        var level = 0;
        if (Root.LeftChild != null)
            Root.LeftChild.NodesAtK(nodes, level, K);
        if (Root.RightChild != null)
            Root.RightChild.NodesAtK(nodes, level, K);

        var rValue = new List<int>();
        foreach (var n in nodes)
            rValue.Add(n.Value);

        return rValue.ToArray();


    }

}