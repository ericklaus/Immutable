using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Immutable
{
    public class ImmutableStack<T>
    {
        private readonly T top;
        private readonly ImmutableStack<T> theRest;
        private readonly int count;

        public T Peek()
        {
            if(IsEmpty)
                throw new InvalidOperationException("The stack is empty");
            return top;
        }

        public ImmutableStack<T> Pop()
        {
            if(IsEmpty)
                throw new InvalidOperationException("The stack is emtpy");
            return theRest;
        }

        public ImmutableStack<T> Push(T element)
        {
            return new ImmutableStack<T>(element, this);
        }

        protected ImmutableStack()
        {
            theRest = null;
            count = 0;
        }

        private ImmutableStack(T top, ImmutableStack<T> theRest)
        {
            this.top = top;
            this.theRest = theRest;
            count = theRest.count + 1;
        }

        public bool IsEmpty
        {
            get { return count==0; }
        }

        public int Count
        {
            get { return count; }
        }

        public static ImmutableStack<T> EmptyStack = new ImmutableStack<T>();
    }
}
