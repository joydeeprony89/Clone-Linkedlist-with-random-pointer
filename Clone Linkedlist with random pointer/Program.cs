using System;

namespace Clone_Linkedlist_with_random_pointer
{
    class Program
    {
        class Node
        {
            public int data;
            public Node next, random;
            public Node(int x)
            {
                data = x;
                next = random = null;
            }
        }
        static void Main(string[] args)
        {

            Node start = new Node(1);
            start.next = new Node(2);
            start.next.next = new Node(3);
            start.next.next.next = new Node(4);
            start.next.next.next.next = new Node(5);

            // 1's random points to 3  
            start.random = start.next.next;

            // 2's random points to 1  
            start.next.random = start;

            // 3's and 4's random points to 5  
            start.next.next.random = start.next.next.next.next;
            start.next.next.next.random = start.next.next.next.next;

            // 5's random points to 2  
            start.next.next.next.next.random = start.next;

            Console.WriteLine("Original list : ");
            Print(start);

            Console.WriteLine("Cloned list : ");
            Node cloned_list = Clone(start);
            Print(cloned_list);
        }

        static void Print(Node current)
        {
            Node temp = current;
            while(temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }

        static Node Clone(Node current)
        {
            // copy each elemnet 
            Node temp = current;
            while(temp != null)
            {
                Node next = temp.next;
                temp.next = new Node(temp.data);
                temp.next.next = next;
                temp = next;
            }

            //copy random pointer
            temp = current;
            while (temp != null)
            {
                temp.next.random = temp.random.next;
                temp = temp.next.next;
            }
            // copy next pointer
            temp = current;
            Node copy = temp.next;
            Node clone = copy;
            while (temp != null && copy != null)
            {
                temp.next = copy.next;
                copy.next = temp?.next?.next;
                temp = temp?.next;
                copy = copy?.next;
            }

            return clone;
        }
    }
}
