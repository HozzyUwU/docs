#include <iostream>
#include "TNodeClass.h"
#include "TNodeMethods.h"
using namespace std;


// Declaring static variables(C++ rules)
template <typename T>
TNode<T>**::TNode<T>::head = NULL;

template <typename T>
int ::TNode<T>::count = 0;


int main()
{
    // Creating head node
    TNode<int>* headList = new TNode<int>();
    headList->count++;
    headList->next = NULL;
    (headList->head) = &headList;
    headList->data = NULL;

    // Default list
    headList->Push(2);
    headList->Push(7);
    headList->Push(10);
    headList->Append(12);
    headList->InsertAfter(99, headList->Find(7));

    headList->PrintList();

    cout << "\nWhat do u want from ur life?" << endl;
    cout << "\nAdd element at the begining of list <1>" << endl;
    cout << "Add element at the end of list <2>" << endl;
    cout << "Add element after chosen one <3>" << endl;
    cout << "Delete chosen element <4>" << endl;
    cout << "Please enough <0>" << endl;

    int a=1, x, y;
    while (a != 0)
    {
        cout << "\nEnter 1/2/3/4/0 ->";
        cin >> a;
        switch (a)
        {
        case 1:
        {
            cout << "\nEnter ur value ->";
            cin >> x;
            headList->Push(x);
            headList->PrintList();
            break;
        }
        case 2:
        {
            cout << "\nEnter ur value ->";
            cin >> x;
            headList->Append(x);
            headList->PrintList();
            break;
        }
        case 3:
        {
            cout << "\nEnter ur value ->";
            cin >> x;
            cout << "\nEnter prev element ->";
            cin >> y;
            headList->InsertAfter(x, headList->Find(y));
            headList->PrintList();
            break;
        }
        case 4:
        {
            cout << "\nEnter ur value ->";
            cin >> x;
            headList->DeleteElem(x);
            headList->PrintList();
            break;
        }
        default:
            break;
        }
    }
}