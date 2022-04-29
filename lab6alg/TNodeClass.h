#pragma once
template <typename T>
class TNode
{
public:
    // Static variables
    static TNode** head;
    static int count;

    // Data
    T data;

    // Links to next and prev objects
    TNode* next;
    TNode* prev;

    // Methods
    TNode* Find(T _data);
    void Push(T _data);
    void Append(T _data);
    // Later
    void InsertAfter(T _data, TNode* prevNode);
    void PrintList();
    void DeleteElem(T _data);
};


