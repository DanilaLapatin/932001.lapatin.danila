

#include <iostream>

using namespace std;

int main()
{
    cout << "Please give a good rating!\n";
    cout <<"Input your rating: ";
    char a;
    cin >> a;
    
    if (a == '3' || a == '4' || a == '5' )
    {
        
        cout << "Not bad, " << a;
    }
    else
    {
        cout << "Eh...Sorry:(";
    }

    return 0;
}
// &Output:file.exe
