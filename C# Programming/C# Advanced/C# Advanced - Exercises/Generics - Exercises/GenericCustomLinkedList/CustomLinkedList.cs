using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCustomLinkedList
{
    public class CustomLinkedList<T>
    {
        public int Count { get; private set; }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public CustomLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public CustomLinkedList(T value) : this()
        {
            Node<T>node = new Node<T>()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            Count++;
            Head = node;
            Tail = node;
        }

        public CustomLinkedList(IEnumerable<T> list) : this(list.First())
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
                    Node<T> node = new Node<T>()
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

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                this.Head = this.Tail = new Node<T>()
                {
                    Value = element,
                    Next = null,
                    Previous = null
                };
            }
            else
            {
                Node<T> newNode = new Node<T>()
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

        public void AddLast(T element)
        {
            if (Count == 0)
            {
                this.Head = this.Tail = new Node<T>()
                {
                    Value = element,
                    Next = null,
                    Previous = null
                };
            }
            else
            {
                Node<T> newNode = new Node<T>()
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

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("List is empty!");
            }

            T result = this.Head.Value;
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

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("List is empty!");
            }

            T result = this.Tail.Value;
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

        public void ForEach(Action<T> action)
        {
            Node<T> currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            Node<T> currentNode = this.Head;

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
