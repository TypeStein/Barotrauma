﻿using System.Collections.Generic;
using System.Linq;

namespace Barotrauma
{
    public class Memento<T>
    {
        public T Current { get; private set; }

        private Stack<T> undoStack = new Stack<T>();
        private Stack<T> redoStack = new Stack<T>();

        public void Store(T newState)
        {
            redoStack.Clear();
            if (!Current.Equals(default(T)))
            {
                undoStack.Push(Current);
            }
            Current = newState;
        }

        public T Undo()
        {
            if (undoStack.Any())
            {
                redoStack.Push(Current);
                Current = undoStack.Pop();
            }
            return Current;
        }

        public T Redo()
        {
            if (redoStack.Any())
            {
                undoStack.Push(Current);
                Current = redoStack.Pop();
            }
            return Current;
        }

        public void Clear()
        {
            undoStack.Clear();
            redoStack.Clear();
            Current = default(T);
        }
    }
}
