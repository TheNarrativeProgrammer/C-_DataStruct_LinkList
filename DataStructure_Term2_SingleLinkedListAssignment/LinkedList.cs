using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Term2_SingleLinkedListAssignment
{
    class LinkedList<T>
    {
        //MEMBER VARIABLES
        public Node<T> mHead;                       //points at Node at head of LL.
        public int mSize;

        //CONSTRUCTORS
        public LinkedList() { }                     //default constructor
                                                        //- LinkedList class is generic type, so it's constructor inhereits this.
                                                        //Don't need to include <T> in constructor

        public LinkedList(T[] inArrayCopy)          //Param constructor - Arrays
        {                                               //Creates Node with an array as mData variable
            for (int i = 0; i < inArrayCopy.Length; i++)
            {
                Append_akaAddToTail(inArrayCopy[i]);
            }
        }

        //FUNCTIONS

        public void AddToHead(T inData)
        {
            Node<T> newNode = new Node<T>();        //a) create new node
                                                        //Object type: Class of type Node & Generic
                                                        //Data Type: type of LinkedList Object calling this function

            newNode.mData = inData;                 //set mData of newNode

            newNode.mNext = mHead;                  //Set mNext of newNode to  mHead
                                                        //mHead is current begining Node. newNode is new beginning Node & it's mNext is currently mHead
            mHead = newNode;                        //Set mHead of LinkedList to newNode
            mSize++;

        }
        public void Append_akaAddToTail(T inData)
        {
            Node<T> newNode = new Node<T>();        //a) create new node
                                                        //Object type: Class of type Node & Generic
                                                        //Data Type: type of LinkedList Object calling this function

            newNode.mData = inData;                 //b) set member variable mData of newly created node to argument inData passed in.

            if(mHead == null)                       //c) check if list is empty - if mHead == null, then list isn't populated
            {
                mHead = newNode;                        //set mHead to newNode
                mSize++;                                    //newNode.mNext now equals null         increase size by 1
                return;
            }

                                                    //d) Iterator - find Node at END

            Node<T> iterator = mHead;                   //create iterator set to mhead (starting point of iteration)
                                                        //Object type: Class of type Node & Generic

            while (iterator.mNext != null)              //If current iteration mNext is NOT null - set iterator to mNext.   
            {                                               //Not at end of list
                iterator = iterator.mNext;
            }                                           //If current iteration mNext is null - set iterator.mNext to newNode 
            iterator.mNext = newNode;                       //Iterator at end.
                                                            //Set new end to newNode. Set mNext of iterator (current end) to newNode (new end)
            mSize++;                                        //increase size by 1
        }

        public void Insert(T inData, int index)
        {
            Node<T> newNode = new Node<T>();        //a) create new node

            newNode.mData = inData;                 //b) set mData in newNode

            int IndexSize = GetIndexSize();               //c) get size of list

            if(IndexSize<index)                      //d) Error check - if index is outside range of linkedList
            {
                Console.WriteLine("Index is out of range of list");
                return;
            }

            if(IndexSize == 0 || index == 0)         //e) check if empty or if inserting at index 0 - based on size
            {
                mHead = newNode;
                mSize++;
                return;
            }
                                                    //f) Iterator - find Node at position -  1 

            Node<T> iterator = mHead;                       //create iterator set to mhead (starting point of iteration)

            for (int i = 0; i < index-1; i++)               //iterate until iterator at position -1 (Node to inset newNode after)
            {
                iterator = iterator.mNext;
            }
            newNode.mNext = iterator.mNext;         //e) Set mNext of newNode to mNext of Iterator (current node)

            iterator.mNext = newNode;               //f) set mNext of Iterator (current node) to newNode

            mSize++;
        }

        public void RemoveFromBeginning_akaHead()
        {
            Console.WriteLine("==============================================================" + '\n');
            if (mHead == null)                       //Check if mHead is null, meaning list is empty
            {
                Console.WriteLine("Can't delete. Link list is empty");
                return;
            }

            Node<T> currentHead = mHead;            //Store current mHead of LL as variable

            mHead = mHead.mNext;                    //Set mHead of LL to mNext (Node after Head)

            Console.WriteLine("remove head :" + currentHead.mData);

            currentHead = null;                     //Set currentHead variable to null - which acts as deleting from list.
            mSize--;
        }

        public void RemoveFromEnd_akaTail()
        {
            Console.WriteLine("==============================================================" + '\n');
            if (mHead == null)                   //Check if mHead is null, meaning list is empty
            {
                Console.WriteLine("Can't delete. Link list is empty");
                return;
            }

            if(mHead.mNext == null)             //Check if mNext of mHead is null, meaning list is a single node
            {
                mHead = null;                       //Set mHead to null - which acts as deleting from list. 
                return;
            }

            Node<T> iterator = mHead;

            while(iterator.mNext.mNext != null)     //Traverse to the second-to-last node (mNext of mNext of current Node iterator equals)
            {
                iterator = iterator.mNext;
            }
            Console.WriteLine("remove tail :" + iterator.mNext.mData);
            iterator.mNext = null;                  //Delete last node      (Iterator on 2nd last node. iterator.mNext = last node)
                                                    //Both last node and 2nd last node mNext now equal NULL.
                                                    //Because there is no mNext referencing last node, it's deleted from list
                                                    //2nd last node (iterator current position) is now LAST NODE
            mSize--;
        }

        public void RemoveAtIndex(int index)
        {
            Console.WriteLine("==============================================================" + '\n');
            int indexSize = GetIndexSize();
            if(index > indexSize)                   //Check if index is outside index of LL
            {
                Console.WriteLine("index outside range");
                return;
            }

            if(index == 0)
            {
                RemoveFromBeginning_akaHead();
                return;
            }

            Node<T> iterator = mHead;

            for(int i = 0; i < index - 1; i++)        //Find node at position index-1 (node before the node-to-delete)
            {
                iterator = iterator.mNext;
            }                                           //Exit loop when iterator = node-BEFORE-node-to-delete  (iterator is current node)
            
            Node<T> nodeToDelete = iterator.mNext;  //Save node-to-delete as variable (iterator mNext is the node you're deleting)

            iterator.mNext = nodeToDelete.mNext;    //Set mNext of current node (iterator) to the mNext of node-to-delete
                                                            //can also write as - iterator.mNext = iterator.mNext.mNext

            Console.WriteLine("removed data : " + nodeToDelete.mData + ". at index " + index + '\n');

            nodeToDelete.mNext = null;              //set mNext of node-to-delete to null
                                                    //this removes from list since b/c no mNext references this node-to-delete and mNext set to null

            return;

        }

        public void ReplaceDataAtIndex(int index, T inData)
        {

            if(index > GetIndexSize())
            {
                Console.WriteLine("Index outside range");
                return;
            }

            if(index == 0)
            {
                mHead.mData = inData;
            }

            Node<T> iterator = mHead;
            for(int i = 0; i < index; i++)
            {
                iterator = iterator.mNext;
            }
            iterator.mData = inData;

        }

        public void GetDataAtIndex(int index)
        {
            Console.WriteLine("==============================================================" + '\n');
            Console.WriteLine("index: " + index);
            if(index > GetIndexSize())
            {
                Console.WriteLine("Index outside range");
                return;
            }
            Node<T> iterator = mHead;
            for(int i = 0; i < index ; i++)
            {
                iterator = iterator.mNext;
            }
            Console.WriteLine(iterator.mData);

        }

        public void PrintAllDataInListDetail()
        {
            Console.WriteLine("==============================================================");
            int IndexSize = GetIndexSize();
            if(IndexSize == 0)
            {
                Console.WriteLine("List is empty" + '\n');
                return;
            }

            Node<T> iterator = mHead;
            int indexCount = 0;

            while(iterator.mNext != null)
            {
                if(iterator == mHead)
                {
                    Console.Write(indexCount + ". Head : " + iterator.mData);
                    Console.WriteLine('\n');
                    iterator = iterator.mNext;
                    indexCount++;
                }
                else
                {
                    Console.Write(indexCount + ". " + iterator.mData);
                    Console.WriteLine('\n');
                    iterator = iterator.mNext;
                    indexCount++;
                }
                
            }
            Console.WriteLine(indexCount + ". " + "tail : " + iterator.mData);
            Console.WriteLine("==============================================================");
            Console.WriteLine("end of list - Null" + '\n');
            Console.WriteLine("linked list index is : " + IndexSize + "\n");
            Console.WriteLine("linked list size is : " + mSize + "\n");
            Console.WriteLine("==============================================================");
        }

        public void PrintAllDataInListStandard()
        {
            int IndexSize = GetIndexSize();
            if (IndexSize == 0)
            {
                Console.WriteLine("List is empty" + '\n');
                return;
            }

            Node<T> iterator = mHead;

            while (iterator.mNext != null)
            {
                Console.Write(iterator.mData);
                Console.WriteLine('\n');
                iterator = iterator.mNext;
            }
            Console.WriteLine(iterator.mData);
            Console.WriteLine("==============================================================");
        }


        public int GetIndexSize()
        {
            int IndexSize = 0;                       //set size to 0

            if(mHead == null)                       //Check if list is empty
            {
                return 0;                               //return 0 if empty
            }

                                                    //Iterator
            Node<T> iterator = mHead;                   //create iterator set to mhead - OBJ Type: Node class Generic
            while (iterator.mNext != null)              //iterate until mNext is null (end of list)
            {
                IndexSize++;                             //increase IndexSize by 1
                iterator = iterator.mNext;              //if mNext isn't null (not at end), set iterator to mNext, the next Node in list
            }
            return IndexSize;                            //exit loop when iterator.mNext is null (at end). Return IndexSize, now a count of size
        }
    }
}
