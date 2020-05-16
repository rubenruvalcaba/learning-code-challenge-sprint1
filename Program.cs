using System;
using System.Collections;
using System.Collections.Generic;

namespace dataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // MicrosoftExercises();            
            //PalindromeTest();            
            // ArrayExcercise();
            //LinkedListExcercise();
            //          StackExcercises();
            //QueueExcercise();
            // ArrayQueueExercise();
            //  QueueUsingStackExercise();
            //PriorityQueueExcercise();
            // HashTableExercise();
            //HashTableCollisionExercise();
            /*    TestGooglePairSum(new int[] { 1, 4, 2, 4 }, 8);
               TestGooglePairSum(new int[] { 1, 2, 3, 9 }, 8);
               TestGooglePairSum(new int[] { 10, 2, 18, 90 }, 29); */


            // Second Unit

            // SearchBinaryTreeExercise1();
            // TraverseBinaryTreeExercise();

            AVLTreeExcercise();

        }

        private static void AVLTreeExcercise()
        {
            var rightSkew = new AVLTree(new int[] { 10, 20, 30 });
            var leftSkew = new AVLTree(new int[] { 10, 30, 20 });
            Console.WriteLine("Watch tree value");

        }

        private static void SearchBinaryTreeExercise1()
        {
            var tree = new SearchBinaryTree(new int[] { 7, 9, 10, 4, 1, 6, 8 });

            Console.WriteLine("Find 10: {0}", tree.Find(10));
            Console.WriteLine("Find 8 {0} ", tree.Find(8));
            Console.WriteLine("Find 17: {0}", tree.Find(7));
            Console.WriteLine("Find 20: {0}", tree.Find(20));

        }

        private static void TraverseBinaryTreeExercise()
        {

            var tree = new SearchBinaryTree(new int[] { 20, 10, 30, 6, 14, 24, 3, 8, 26 });
            Console.WriteLine("Traverse pre-order: {0}",
                                    string.Join(",",
                                    tree.TraversePreOrder()));

            Console.WriteLine("Traverse in order:{0}",
                                    string.Join(",",
                                    tree.TraverseInOrder()));

            Console.WriteLine("Traverse postOrder{0}",
                                    string.Join(",",
                                    tree.TraversePostOrder()));

            var secondTree = new SearchBinaryTree(new int[] { 20, 10, 30, 7, 14, 24, 3, 8, 26 });
            Console.WriteLine("Trees are equals? {0}", tree.Equals(secondTree).ToString());


            var validateTree = new SearchBinaryTree();
            validateTree.CreateInvalidTree();
            Console.WriteLine("Is valid the tree? {0}", validateTree.Validate().ToString());

            var treeK = new SearchBinaryTree(new int[] { 20, 10, 6, 21, 3, 8, 30, 31 });
            Console.WriteLine("K 3:{0}",
                string.Join(",", treeK.NodesAtK(2)));


        }



        private static void HashTableCollisionExercise()
        {
            var testValues = new int[] { 1, 7, 8, 2, 10 };

            var ht = new HashTable(testValues.Length);
            for (var i = 0; i < testValues.Length; i++)
            {
                var k = testValues[i];
                ht.Put(k, "Value " + k);
            }

            for (var i = 0; i < testValues.Length; i++)
            {
                var k = testValues[i];
                Console.WriteLine($"GET {k}: {ht.Get(k)}");
            }

            var lastKey = testValues[testValues.Length - 1];
            ht.Delete(lastKey);
            Console.WriteLine("After delete: {0}", ht.Get(lastKey));

        }

        private static void MicrosoftExercises()
        {
            var arr = new int[] { 3, 8, 9, 4, 2, 7 };
            Console.WriteLine("Array [{0}]", string.Join(",", arr));
            Console.WriteLine("Greatest numer is: {0}",
                 MicrosoftExam.GreatestNumberInArray(arr));
            MicrosoftExam.SortArray(arr);
            Console.WriteLine("Sorted array: [{0}]",
                 string.Join(",", arr));

        }

        private static void PalindromeTest()
        {
            try
            {
                Console.WriteLine("Type the word to check:");
                var word = Console.ReadLine();
                Console.WriteLine($"The word '{word}' is palindrome: {IsWordPalindrome(word)}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

        }
        private static bool IsWordPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception("Word is not valid");

            var upperWord = word.ToUpper();
            var h = 0;
            var t = word.Length - 1;
            while (h < t)
            {
                if (upperWord[h] != upperWord[t])
                    return false;
                h++;
                t--;
            }
            return true;
        }

        private static void TestGooglePairSum(int[] array, int sum)
        {
            Console.WriteLine("{0} sums {1}? {2}", string.Join(",", array), sum,
                        Google.IsPairSumToNoSort(array, sum));
        }

        private static void HashTableExercise()
        {

            try
            {
                Console.WriteLine("Type the string to analyze to get the first non-repeated character");
                var input = Console.ReadLine();
                Console.WriteLine("First non-repeated character " + FirstNonRepeatedCharacter(input));
                Console.WriteLine("First repeated character is: " + FirstRepeatedCharacter(input));

                var intArray = new int[] { 1, 2, 2, 3, 3, 3, 4 };
                Console.WriteLine("HashTable most repeated int in: [{0}] is {1}",
                 string.Join(",", intArray),
                 MostRepeatedNumberInArray(intArray));

                var pairs = new int[] { 1, 7, 5, 9, 12, 3 };
                Console.WriteLine("HashTable countPairs on {0} to K:{1} = {2}",
                  string.Join(",", pairs), 2,
                  CountPairsWithDifference(pairs, 2)
                );



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static object CountPairsWithDifference(int[] input, int k)
        {
            var h = new HashSet<int>();
            foreach (var i in input)
                h.Add(i);
            var countPairs = 0;
            foreach (var i in input)
            {
                var pairValue = i + 2;
                if (h.Contains(pairValue))
                    countPairs++;
            }

            return countPairs;

        }

        private static int MostRepeatedNumberInArray(int[] input)
        {
            var hash = new Dictionary<int, int>();
            foreach (var key in input)
                if (hash.ContainsKey(key))
                    hash[key]++;
                else
                    hash.Add(key, 1);

            var max = 0;
            foreach (var item in hash)
                if (item.Value > max)
                    max = item.Value;

            return max;

        }

        private static char FirstRepeatedCharacter(string input)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (var c in input)
            {
                var thisChar = char.ToLower(c);
                if (set.Contains(thisChar))
                    return thisChar;
                set.Add(thisChar);
            }
            return '\0';
        }
        private static char FirstNonRepeatedCharacter(string input)
        {
            var ht = new Dictionary<char, int>();
            foreach (var c in input)
            {
                var thisChar = char.ToLower(c);
                if (ht.ContainsKey(thisChar))
                {
                    var currentValue = ht[thisChar];
                    ht[thisChar] = currentValue + 1;
                }
                else
                {
                    ht.Add(thisChar, 1);
                }
            }
            foreach (var c in input)
            {
                var thisChar = char.ToLower(c);
                if (ht[thisChar] == 1)
                    return thisChar;

            }

            throw new Exception("No non-repeated characters in input string ");

        }
        private static void PriorityQueueExcercise()
        {
            try
            {
                PriorityQueue q = new PriorityQueue();
                q.Enqueue(1);
                q.Enqueue(5);
                q.Enqueue(2);
                q.Enqueue(10);
                while (q.Count() > 0)
                    Console.WriteLine(q.Dequeue());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void QueueUsingStackExercise()
        {
            try
            {
                QueueUsingStack stack = new QueueUsingStack();
                stack.Enqueue(10);
                stack.Enqueue(20);
                stack.Enqueue(30);

                Console.WriteLine(stack.Dequeue());
                Console.WriteLine(stack.Dequeue());
                Console.WriteLine(stack.Dequeue());
                stack.Enqueue(40);
                Console.WriteLine(stack.Dequeue());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private static void ArrayQueueExercise()
        {
            try
            {
                ArrayQueue qArray = new ArrayQueue(4);
                qArray.Enqueue(10);
                qArray.Enqueue(20);
                qArray.Enqueue(30);
                qArray.Enqueue(40);
                Console.WriteLine(qArray.ToString());

                Console.WriteLine($"Peek {qArray.Peek()}");
                Console.WriteLine($"Is Empty {qArray.isEmpty()}");
                Console.WriteLine($"Is full {qArray.isFull()}");

                Console.WriteLine(qArray.Dequeue());
                Console.WriteLine(qArray.Dequeue());
                qArray.Enqueue(50);
                Console.WriteLine(qArray.Dequeue());
                Console.WriteLine(qArray.Dequeue());
                Console.WriteLine(qArray.Dequeue());
                Console.WriteLine(qArray.Dequeue());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        private static void QueueExcercise()
        {

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine(string.Join(",", queue.ToArray()));

            ReverseQueue(queue);
            Console.WriteLine(string.Join(",", queue.ToArray()));


        }

        private static void ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

        }

        private static void StackExcercises()
        {

            Console.WriteLine("Type the expression to check if is balanced");
            var expression = Console.ReadLine();
            Console.WriteLine($"Is balanced: {Stacks.IsStringBalanced(expression)}");

            var ms = new MyStack();
            ms.Push(10);
            ms.Push(20);
            ms.Push(30);
            while (ms.Count() > 0)
            {
                Console.WriteLine(ms.Pop());
            }

            /*
            Console.WriteLine("Type the string to reverse:");
            var strToReverse = Console.ReadLine();
            var reversedString = Stacks.StackReversingStringExcercise(strToReverse);
            Console.WriteLine(reversedString);
            */

        }

        private static void LinkedListExcercise()
        {
            var linkedList = new LinkedList();
            linkedList.addFirst(10);
            linkedList.addFirst(5);
            linkedList.Print();

            Console.WriteLine(" addLast");

            linkedList.Clear();
            linkedList.addLast(20);
            linkedList.addLast(30);
            linkedList.addLast(40);
            linkedList.Print();

            Console.WriteLine("Delete first");
            linkedList.deleteFirst();
            linkedList.Print();

            Console.WriteLine("Delete last");
            linkedList.Clear();
            linkedList.addLast(20);
            linkedList.addLast(30);
            linkedList.addLast(40);
            linkedList.Print();
            linkedList.deleteLast();
            linkedList.Print();

            Console.WriteLine("Index of ");
            linkedList.Clear();
            linkedList.addLast(20);
            linkedList.addLast(30);
            linkedList.addLast(40);
            linkedList.Print();
            Console.WriteLine("Index of 10: {0}", linkedList.indexOf(10));
            Console.WriteLine("Index of 30: {0}", linkedList.indexOf(30));
            Console.WriteLine("Contains 20: {0}", linkedList.Contains(20));
            Console.WriteLine("Contains 50: {0}", linkedList.Contains(50));

            Console.WriteLine("Linkedlist count = {0}", linkedList.Count);

            Console.WriteLine("To Array {0}", linkedList.ToArray().Length);

            Console.Clear();
            linkedList.Clear();
            linkedList.addLast(10);
            linkedList.addLast(20);
            linkedList.addLast(30);
            linkedList.addLast(40);
            Console.WriteLine("Reversing:");
            linkedList.Reverse();
            linkedList.Print();

            Console.Clear();
            linkedList.Clear();
            linkedList.addLast(10);
            linkedList.addLast(20);
            linkedList.addLast(30);
            linkedList.addLast(40);
            linkedList.Print();
            Console.WriteLine("Kth from the end: {0}", linkedList.GetKthFromTheEnd(1));

        }


        private static void ArrayExcercise()
        {
            Array numbers = new Array(3);
            numbers.Insert(1);
            numbers.Insert(2);
            numbers.Insert(3);
            numbers.Insert(4);

            numbers.RemoveAt(3);

            numbers.Print();

            Console.WriteLine($"Index of 2 = {numbers.IndexOf(2)}");
            Console.WriteLine($"Max: {numbers.Max()}");

            Array secondArray = new Array(3);
            secondArray.Insert(1);
            secondArray.Insert(4);
            secondArray.Insert(5);
            secondArray.Insert(2);

            Console.WriteLine("Second:");
            secondArray.Print();

            Console.WriteLine("Intersect:");
            var intersect = numbers.Intersect(secondArray);
            intersect.Print();

            Console.WriteLine("Reversed:");
            var reversed = numbers.Reverse();
            reversed.Print();

            Console.WriteLine("inserting 20 at 1");
            numbers.InsertAt(1, 20);
            numbers.Print();
        }
    }
}
