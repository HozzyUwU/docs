#pragma once

using std::endl;

void Fill(std::vector<Baza> &basege, int N)
{
	std::srand(std::time(NULL));
	for (int i = 0; i < N; i++)
	{
		char word = 'a' + rand() % 26;
		int key = rand() % 100;
		Baza test(word, key);
		basege.push_back(test);
	}
}

void Display(std::vector<Baza> basege)
{
	// UI
	for (int i = 0; i < basege.size()*2; i++)
	{
		std::cout << "-";
	}
	std::cout << endl;

	for (auto i = basege.cbegin(); i != basege.cend(); i++)
	{
		std::cout << *i;
	}

	// UI
	for (int i = 0; i < basege.size() * 2; i++)
	{
		std::cout << "-";
	}
	std::cout << endl;
}

void Task2(std::vector<Baza>& basege, Baza& (*func)(std::vector<Baza>), int N)
{
	// Finding min element in vector
	auto min = min_element(
		basege.begin(), // Forward iterator pointing to the beginning of the range
		basege.end()); // Forward iterator pointing to the end of the range
	//std::cout << "\nDebug:: " << min->key;
	
	Baza _min(min->letter, min->key);

	// Finding arithmetic mean
	Baza mean = func(basege);
	//std::cout << mean << endl;
	// Changing all elements greater than arithemetic mean to min element
	for (int i = 0; i < N; i++)
	{
		if (basege[i] > mean)
		{
			basege[i] = *min;
		}
	}
}