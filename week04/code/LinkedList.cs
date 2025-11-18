using System.Collections;
using System.Dynamic;
using System.Globalization;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create the new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail =  newNode;
        }
        // If not empty, then only tail will be affected.
        else
        {
            newNode.Prev = _tail; // First set the current tail as the previous node of the new node
            _tail.Next = newNode; // Set the next node of the current tail to be the new node
            _tail = newNode; // update the tail to the new node
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // if the list has only one item set both head and tail to null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // if the list has more items, only update the tail
        else
        {
            _tail.Prev.Next = null; // Set the next of the previous node from tail to null 
            _tail = _tail.Prev; //Set the second from last node to be the new tail
        }
    }
    

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        //Store the current node in the 'curr' variable starting at the head
        //Use the 'while' loop to iterate throughthe list until curr is null and the value is found
        Node? curr = _head;
        while (curr is not null && curr.Data != value)
        {
            curr = curr.Next; // move to the next node
        }
           // If not found, throw
        if (curr is null)
        {
            return; // Value not found, exit the method
        }
        if (curr == _head)
        {
            RemoveHead(); //Calls the RemoveHead moethod to remove head node
        }
        else if (curr == _tail)
        {
            RemoveTail();//Calls the RemoveTail method to reomve tail node
        }
        else
        {
            curr!.Next!.Prev = curr.Prev; //Set the previous node of the next node to the previous node being removed
            curr.Prev!.Next = curr.Next; //Set the Next node of the previous node to the next node being removed
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        //Store the current node in the 'curr' variable starting at the head 
        Node? curr = _head;
        //Use the 'while' loop to iterate through the list until curr is null
        while (curr is not null)
        {
            //If the current node == oldValue, replace it with the new Value
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next; //Move to the next node
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        //Store the current node in the 'curr' variable starting at the tail
        //Use the 'while' loop to iterate through the list until curr is null
        var curr = _tail;// Since it is bacwards iteration, start at the tail
        while(curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Go backward in the linked list
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}