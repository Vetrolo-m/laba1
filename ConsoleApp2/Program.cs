using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomList<T>
{
    private T[] items;
    private int count;

    public CustomList(int size)
    {
        items = new T[size];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= items.Length)
            throw new InvalidOperationException("List is full.");
        items[count++] = item;
    }

    public T Remove()
    {
        if (count == 0)
            throw new InvalidOperationException("List is empty.");
        return items[--count];
    }

    public T Peek()
    {
        if (count == 0)
            throw new InvalidOperationException("List is empty.");
        return items[count - 1];
    }

    public int Count => count;

    public T[] ToArray()
    {
        T[] array = new T[count];
        Array.Copy(items, array, count);
        return array;
    }
}

public class Stack<T>
{
    private CustomList<T> list;

    public Stack(int size)
    {
        list = new CustomList<T>(size);
    }

    public Stack(Stack<T> other)
    {
        list = new CustomList<T>(other.list.Count);
        foreach (var item in other.list.ToArray())
        {
            list.Add(item);
        }
    }

    public void Push(T item)
    {
        list.Add(item);
    }

    public T Pop()
    {
        return list.Remove();
    }

    public T Peek()
    {
        return list.Peek();
    }

    public void Print()
    {
        var items = list.ToArray();
        Console.WriteLine("Stack contents: " + string.Join(", ", items));
    }

    public double Average()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        double sum = 0;
        foreach (var item in list.ToArray())
        {
            sum += Convert.ToDouble(item);
        }
        return sum / list.Count;
    }
}

public class Program
{
    public static void Main()
    {
        Stack<int> stack = new Stack<int>(5);
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        stack.Print();

        Console.WriteLine("Top element: " + stack.Peek());
        Console.WriteLine("Popped element: " + stack.Pop());

        stack.Print();

        Console.WriteLine("Average: " + stack.Average());
    }
}