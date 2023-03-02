using System;
using System.Collections.Generic;
using System.Linq;

namespace DoublyLinkedList
{
    public class CustomLinkedList
    {
        public int Count { get; private set; }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public CustomLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public CustomLinkedList(int value) : this()
        {
            Node node = new Node()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            Count++;
            Head = node;
            Tail = node;
        }

        public CustomLinkedList(IEnumerable<int> list) : this(list.First())
        {

            bool isFirst = true;

            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    Node node = new Node()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };

                    Count++;
                    Tail.Next = node;
                    Tail = node;
                }
            }
        }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                this.Head = this.Tail = new Node()
                {
                    Value = element,
                    Next = null,
                    Previous = null
                };
            }
            else
            {
                Node newNode = new Node()
                {
                    Value = element,
                    Next = null,
                    Previous = null
                };

                newNode.Next = this.Head;
                this.Head.Previous = newNode;
                this.Head = newNode;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                this.Head = this.Tail = new Node()
                {
                    Value = element,
                    Next = null,
                    Previous = null
                };
            }
            else
            {
                Node newNode = new Node()
                {
                    Value = element,
                    Next = null,
                    Previous = null
                };

                newNode.Previous = this.Tail;
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("List is empty!");
            }

            int result = this.Head.Value;
            this.Head = this.Head.Next;

            if (this.Head == null)
            {
                this.Tail = null;
            }
            else
            {
                this.Head.Previous = null;
            }

            Count--;

            return result;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("List is empty!");
            }

            int result = this.Tail.Value;
            this.Tail = this.Tail.Previous;

            if (this.Tail == null)
            {
                this.Head = null;
            }
            else
            {
                this.Tail.Next = null;
            }

            Count--;

            return result;
        }

        public void ForEach(Action<int> action)
        {
            Node currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;
            Node currentNode = this.Head;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;
                index++;
            }

            return array;
        }
    }
}
