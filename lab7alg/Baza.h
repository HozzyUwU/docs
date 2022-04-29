#pragma once
class Baza
{
public:
	char letter;
	int key;

	Baza();
	Baza(char _word, int _key);
	
	friend bool operator < (const Baza& obj0, const Baza& obj1);
	friend bool operator > (const Baza& obj0, const Baza& obj1);
	//friend bool operator != (const Baza& obj0, const Baza& obj1);
	//friend bool operator == (const Baza& obj0, const Baza& obj1);

	friend std::ostream& operator << (std::ostream& stream, const Baza& obj);
	
};


std::ostream& operator << (std::ostream& stream, const Baza& obj) 
{
	stream << obj.key << ": " << obj.letter << std::endl;
	return stream;
}

//bool operator != (const Baza& obj0, const Baza& obj1)
//{
//	if (obj0.key == obj1.key && obj0.letter == obj1.letter)
//	{
//		return false;
//	}
//	return true;
//}

//bool operator == (const Baza& obj0, const Baza& obj1)
//{
//	if (obj0.key == obj1.key && obj0.letter == obj1.letter)
//	{
//		return true;
//	}
//	return false;
//}

bool operator > (const Baza& obj0, const Baza& obj1)
{
	if (obj0.key > obj1.key)
	{
		return true;
	}
	if ((obj0.key == obj1.key) && (obj0.letter > obj1.letter))
	{
		return true;
	}
	return false;
}

bool operator < (const Baza& obj0, const Baza& obj1)
{
	if (obj0.key < obj1.key)
	{
		return true;
	}
	if ((obj0.key == obj1.key) && (obj0.letter < obj1.letter))
	{
		return true;
	}
	return false;
}

Baza::Baza()
{
	letter = 'a';
	key = 69;
}

Baza::Baza(char _word, int _key)
{
	letter = _word;
	key = _key;
}