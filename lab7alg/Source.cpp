#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include "Baza.h"
#include "BazaUtilities.h"
#include "MainUtilities.h"

using namespace std;



int main() 
{
	// Creating vector to store data
	vector<Baza> data;

	int N;
	cout << "Enter number of elemets in vector -> ";
	cin >> N;

	// Filling vector with random data
	Fill(data, N);

	// Displaying data
	Display(data);

	Baza a('a', 1), b('s', 2);

	// Performing task number 2
	Task2(data, FindMean, N);

	Display(data);
	
	return 0;
}