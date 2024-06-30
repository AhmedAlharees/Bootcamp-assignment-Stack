using System;
using System.Linq;

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


        // Return the element of position nth
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

        // Count a specific element from the stack
        public int CountElement(int  element) {
            if (IsEmpty()) return 0;

            int counter = 0;

            foreach (int value in stackList) {
                if (value == element) counter++;
            }

            return counter;
        }

        // Remove Duplicate from the stack
        // create temporary array with the same length of stack
        // create temporary counter
        // loop over all the elements in the stack
        // use the contains method to check if the element
        // ...exist in the tempArr or not
        // if not added it to the array
        public void RemoveDuplicates() {
            int[] tempArr = new int[stackList.Length];
            int tempElementCounter = 0;

            foreach (int value in stackList) {
                if (!tempArr.Contains(value)) {
                    tempArr[tempElementCounter++] = value;
                }
            }

            // point the stack list & counter to the temp array
            stackList = tempArr;
            stackElementsCounter = tempElementCounter;
        }
        

        // Merge two lists into one list
        public static int[] MergeTwoLists(Stack firstStack, Stack secondStack) {
            // create new array with the sum of elements from both lists
            int[] tempArr = new int[firstStack.stackElementsCounter + secondStack.stackElementsCounter];
            int elementsCounter = 0;

            // first loop takes the elements of the first stack
            for (int i = 0; i < firstStack.stackElementsCounter; i++) {
                tempArr[elementsCounter++] = firstStack.stackList[i];
            }

            // second loop takes the elements from the second stack
            for (int i = 0; i < secondStack.stackElementsCounter; i++) {
                tempArr[elementsCounter++] = secondStack.stackList[i];
            }

            
            return tempArr;
        } 




        
        public static void Main(string[] args) {
            Stack stack1 = new Stack();
            Stack stack2 = new Stack();
            stack1.Push(3);
            stack1.Push(1);
            stack1.Push(4);
            stack1.Push(4);
            stack1.Push(1);

            stack2.Push(20);
            stack2.Push(30);
            stack2.Push(90);
            stack2.Push(50);

            int[] arr = MergeTwoLists(stack1, stack2);

            foreach (int i in arr) {
                Console.WriteLine(i);

            }


        }
    }
}


