﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private const string InvalidOperation = "Invalid Operation!";

    private List<T> items;
    private int currentIndex;

    public ListyIterator(params T[] initialItems)
    {
        this.items = new List<T>(initialItems);
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.items.Any() && this.HasNext)
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext => this.currentIndex < this.items.Count - 1;

    public string Print()
    {
        if (this.currentIndex > this.items.Count - 1)
        {
            throw new InvalidOperationException(InvalidOperation);
        }

        return this.items[this.currentIndex].ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
