#pragma once
Baza& FindMean(std::vector<Baza> basege)
{
	Baza temp(0, 0);

	for (auto i = basege.cbegin(); i != basege.cend(); i++)
	{
		temp.key += i->key;
		temp.letter += i->letter;
	}

	temp.key = temp.key / basege.size();
	temp.letter = 'a' + temp.letter / basege.size();

	return temp;
}
