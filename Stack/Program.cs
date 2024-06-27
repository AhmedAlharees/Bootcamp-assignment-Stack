using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata;



/*
 * Stack is a type of data structure that uses LIFO(last in first out)
 * Stack contain operations like:
 * push(adding elements to the stack)
 * pop(removing elements from the stack)
 * 
 * How to implement the stack:
 * 1- create class with attributes called 
 * "element" for actuall data, "stackElement"
 * for number of elements in the stack
 * 
 * 2- Add two method
 * Push: takes element of type int, increase the stackElementsCounter 
 * Pop: doesn't take any values, only decrease the stackElementsCounter 
 * if bigger than zero.
 * 
 * 
 */

namespace Recursion {
    class Stack {
        public int[] stackList;
        public int stackElementsCounter;

        public Stack() {
            stackList = new int[5];
            stackElementsCounter = 0;
        }
        public void Push(int data) {
            if (stackElementsCounter < stackList.Length) {
                stackList[stackElementsCounter++] = data;
                return;
            }

            Console.WriteLine("Stack Overflow");
            return;
        } 

        public int Pop() {
            if (stackElementsCounter > 0) {
                return stackList[--stackElementsCounter]; 
            }

            Console.WriteLine("The stack is empty");
            return -1;
        }

        // Using selection sort Algorithm we can sort the stack list
        public void SortAcendingly() {
            if (IsEmpty()) {
                Console.WriteLine("Stack is empty");
                return;
            }

            // Selection Sort
            for (int i = 0; i < stackElementsCounter - 1; i++) {
                // chosing current index as the min
                int minIndex = i; 

                // the second loop going through the elements
                for (int j = i + 1; j < stackElementsCounter; j++) {
                    if (stackList[j] < stackList[minIndex]) {
                        minIndex = j;
                    }
                }

                // swap the elements
                int temp = stackList[minIndex];
                stackList[minIndex] = stackList[i];
                stackList[i] = temp;

            } 

        }

        // Cheking if stack is empty by checking stackElementCounter
        public bool IsEmpty() {
            // return the bool value of comparing stack counter with counter
            return stackElementsCounter == 0;
        }

        // Display the Element of the stack
        public void DisplayElements() {
            if (IsEmpty())
                return;

            for (int i = 0; i < stackElementsCounter; i++) {
                Console.Write(stackList[i]);
            }
;
        }

        // Sort the elements in decending order
        public void SortElemenetsDecendingly() {
            if (IsEmpty()) {
                Console.WriteLine("Stack is empty");
                return;
            }

            // Selection Sort
            for (int i = 0; i < stackElementsCounter - 1; i++) {
                // chosing current index as the max
                int maxIndex = i; 

                // the second loop going through the elements
                for (int j = i + 1; j < stackElementsCounter; j++) {
                    if (stackList[j] > stackList[maxIndex]) {
                        maxIndex = j;
                    }
                }

                // swap the elements
                int temp = stackList[maxIndex];
                stackList[maxIndex] = stackList[i];
                stackList[i] = temp;

            } 

        }

        // Reverse the Elements of the list using two pointers
        public void ReverseListElements() {
            if (IsEmpty()) return;

            // one pointer point to the start, and one the end
            int startPtr = 0;
            int endPtr = stackElementsCounter - 1;

            // checkt if start pointer still smaller than end pointer
            while (startPtr < endPtr) {
                // swap the two elements
                int temp = stackList[startPtr];
                stackList[startPtr] = stackList[endPtr];
                stackList[endPtr] = temp;

                // make the pointer reach break case
                startPtr++;
                endPtr--;
            }

        }

        // Check if an element in a stack is present or not
        public bool IsPresent(int element) {
            if (IsEmpty()) return false;

            // loop over the elements searching for the element 
            for (int i = 0; i < stackElementsCounter; i++)
                if (stackList[i] == element) return true;

            return false;
        }

        // Top and bottom elements of a stack
        public void TopAndBottom(out int top,out int bottom) {
            top = stackList[stackElementsCounter - 1];
            bottom = stackList[0];
        }

        // Swap top two elements
        public void SwapTopTwoElements() {
            int temp = stackList[stackElementsCounter - 1];
            stackList[stackElementsCounter - 1] = stackList[stackElementsCounter - 2];
            stackList[stackElementsCounter - 2] = temp;
        }


        public int GetNthElement(int index) {

            // check if index is out of range, return -1 
            if ((index < 0) || (index >= stackElementsCounter)) {
                Console.WriteLine("The index is out of range");
                return -1;
            } 

            // if index within range return the element
            int n = stackElementsCounter - index;
            return stackList[n];

        }


        
        public static void Main(string[] args) {
            Stack stack1 = new Stack();
            Stack stack2 = new Stack();
            stack1.Push(3);
            stack1.Push(2);
            stack1.Push(4);
            stack1.Push(0);
            stack1.Push(1);

            stack2.Push(20);
            stack2.Push(30);
            stack2.Push(90);
            stack2.Push(50);

            stack1.TopAndBottom(out int x, out int y);
            Console.WriteLine($"{x} {y}");




        }
    }
}


