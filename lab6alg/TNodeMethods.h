#pragma once
// Delete chosen element
template <typename T>
void TNode<T>::DeleteElem(T _data)
{
    // Find given element
    TNode* element = Find(_data);

    if (element == NULL)
    {
        std::cout << "\nChosen node can't be NULL\n";
        return;
    }

    if (element == *head)
    {
        *head = element->next;
        element->next->prev = NULL;
        return;
    }

    if (element->next == NULL)
    {
        element->prev->next = NULL;
    }
    else
    {
        element->next->prev = element->prev;
        element->prev->next = element->next;
    }
}

// Find element in list by value
template <typename T>
TNode<T>* TNode<T>::Find(T _data)
{
    // Declare variables to store T and TNode*
    T data;
    TNode* element = *head;

    // Go through entire list and find address of given value 
    while (element != NULL && element->data != _data)
    {
        element = element->next;
    }

    // Return element
    return element;
}

template <typename T>
void TNode<T>::InsertAfter(T _data, TNode* prev)
{
    // Check if the given prev node is NULL
    if (prev == NULL)
    {
        std::cout << "\nPrevious node can't be NULL\n";
        return;
    }

    // Create new instance
    TNode* newTNode = new TNode();
    newTNode->count++;

    // Find next element
    TNode* next = prev->next;

    // Assigning data in new node
    newTNode->data = _data;
    newTNode->next = next;
    newTNode->prev = prev;

    // Change pointer to next element in prev
    prev->next = newTNode;

    // Change pointer to prev element in next
    if (next != NULL)
    {
        next->prev = newTNode;
    }
}

template <typename T>
// Placing new TNode in front of list
void TNode<T>::Push(T _data)
{
    // Allocating new TNode
    TNode* newTNode = new TNode();
    newTNode->count++;

    // Assigning data
    newTNode->data = _data;

    // Setting link for next node as head
    (newTNode->next) = *head;

    // Changing prev node of head
    ((*head)->prev) = newTNode;

    // Changing head
    *head = newTNode;
}

// Function to add element after next element in list
template <typename T>
void TNode<T>::Append(T _data)
{
    // Create new node
    TNode* newTNode = new TNode();
    newTNode->count++;

    // Find last element in sequence based on head element
    TNode* last = *head;
    while (last->next != NULL)
    {
        last = last->next;
    }

    // Change pointer to next element in last one and set up all data
    last->next = newTNode;
    newTNode->data = _data;
    newTNode->next = NULL;
    newTNode->prev = last;
}

template <typename T>
void TNode<T>::PrintList()
{
    TNode* last = *head;
    std::cout << "\n<- Entire list ->" << std::endl;

    for (int i = 0; i < 3 * (last->count + 10); i++)
    {
        std::cout << "- ";
    }

    std::cout << std::endl;

    while (last != NULL)
    {
        std::cout << last->data << " (" << &(last->data) << ") ";
        last = last->next;
    }

    std::cout << std::endl;

    for (int i = 0; i < 3 * (last->count + 10); i++)
    {
        std::cout << "- ";
    }

    std::cout << std::endl;
}