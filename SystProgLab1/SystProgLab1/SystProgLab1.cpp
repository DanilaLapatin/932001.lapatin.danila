// SystProgLab1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;
class Assembler
{
public:
    int add(int a, int b)
    {
        __asm {
    
            MOV eax, a;
            ADD eax, b;
            MOV a, eax;
        }
        return a;
    }
    int substr(int a, int b)
    {
        __asm {
    
           MOV eax, a;
           SUB eax, b;
           MOV a, eax;
            
        }
    return a;
    }
    int multipl(int a, int b)
    {
       __asm {
            MOV eax, a;
            IMUL b;//IMUL работает с отрицательными числами
            MOV a, eax;
        }
        return a;
    }

    int divis(int a, int b)
    {
       __asm {
           MOV eax, a;
           MOV ebx, b;
           MOV edx, 0;
           IDIV ebx;//IDIV работает с отрицательными числами
           MOV a, eax;
       }
       return a;
    }
    string great(int a, int b)//показывает, больше ли одно число другого
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            CMP eax, ebx;
            JG grt;//если greater
            JE ls;//если equal
            JL ls;//если less
            grt:
            MOV eax, 1;
            JMP result;
            ls :
            MOV eax, 0;
            JMP result;
            result :
            MOV a, eax;
        }
        if (a == 0)return"no,less";
        else return "yes,greater";
    }
    string GreatOrEq(int a, int b)//показывает, больше ли одно число другого
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            CMP eax, ebx;
            JG grtoreq;//если greater
            JE grtoreq;//если equal
            JL ls;//если less
            grtoreq:
            MOV eax, 1;
            JMP result;
            ls:
            MOV eax, 0;
            JMP result;
            result:
            MOV a, eax
        }
        if (a == 0)return"no,less";
        else return "yes,greater or equal";
    }
    string Less(int a, int b)//показывает, больше ли одно число другого
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            CMP eax, ebx;
            JG grt;//если greater
            JE grt;//если equal
            JL ls;//если less
            grt:
            MOV eax, 1;
            JMP result;
            ls:
            MOV eax, 0;
            JMP result;
            result:
            MOV a, eax
        }
        if (a == 0)return"yes,less";
        else return "no,greater";
    }
    string LessOrEq(int a, int b)//показывает, больше ли одно число другого
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            CMP eax, ebx;
            JG grt;//если greater
            JE ls;//если equal
            JL ls;//если less
            grt:
            MOV eax, 1;
            JMP result;
            ls:
            MOV eax, 0;
            JMP result;
            result:
            MOV a, eax
        }
        if (a == 0)return"yes,less or equal";
        else return "no,greater";
    }
    int Not(int a)
    {
        __asm {
            MOV eax, a;
            MOV ebx, 0;
            CMP eax, ebx;
            JE nul;// если not
            JG one;
            nul:
            MOV eax, 1;
            JMP result;
            one:
            MOV eax, 0;
            JMP result;
            result:
            MOV a, eax
        }
        return a;
    }
    int Or(int a, int b)
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            MOV ecx, 0;
            CMP eax, ecx;
            JE nex;// next
            JG one;
            JL nex;
            nex:
            cmp ebx, ecx;
            JE nul;
            JL nul;
            JG one;
            nul:
            MOV eax, 0;
            JMP result;
            one:
            MOV eax, 1;
            JMP result;
            result:
            MOV a, eax
        }
        return a;
    }
    int And(int a, int b)
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            MOV ecx, 0;
            CMP eax, ecx;
            JE nul;// если 
            JG nex;
            JL nex;
            nex:
            cmp ebx, ecx;
            JE nul;
            JL one;
            JG one;
            nul:
            MOV eax, 0;
            JMP result;
            one:
            MOV eax, 1;
            JMP result;
            result:
            MOV a, eax
        }
        return a;
    }
    int Xor(int a, int b)
    {
        __asm {
            MOV eax, a;
            MOV ebx, b;
            MOV ecx, 0;
            CMP eax, ecx;
            JE nexf;// если false
            JG nex;
            JL nex;
            nexf:
            CMP ebx, ecx;
            JG one;
            JE nul;
            JL one;    
            nex:
            CMP ebx, ecx;
            JG nul;
            JL nul;
            JE one;
            nul:
            MOV eax, 0;
            JMP result;
            one:
            MOV eax, 1;
            JMP result;
            result:
            MOV a, eax;
        }
        return a;
    }
    int Index(int* mass, int b)
    {

    __asm {
        MOV eax, mass;
        MOV ebx, b;
        MOV ecx, [4 * ebx + eax];
        MOV b, ecx;
    }

    return b;
    }
    int Shear(int a, char b)//char b, если int конфликт размеров операндов  
    {
    __asm {
        MOV eax, a;
        MOV cl, b;
        SHR eax, cl;
        MOV a, eax;
        }
        return a;
    }
    int ShearR(int a, char b)//char b, если int конфликт размеров операндов
    {
        __asm {
            MOV eax, a;
            MOV cl, b;
            SAR eax, cl;
            MOV a, eax;
        }
        return a;
    }
int ShearL(int a, char b)//char b, если int конфликт размеров операндов
{
    __asm {
        MOV eax, a;
        MOV cl, b;
        SAL eax, cl;
        MOV a, eax;
    }
    return a;
}

    void BoubleSort(int* mass, int n) 
    {
    __asm {
            MOV edi, mass;
            MOV ecx, n;
            Bigloop :
            LEA ebx, [edi + ecx * 4];//поместить в ebx значение по адресу edi + ecx * 4
            MOV eax, [edi];
            smalloop :
            SUB ebx, 4;
            CMP eax, [ebx];
            JLE newiter;//если eax < значения по адресу ebx,то перехожд к метке newiter. jle работает с отрицательными числами
            XCHG eax, [ebx];//перестановка, change значений
            newiter:
            CMP ebx, edi;//сравнение адресов для не выхода за границы массива
            JNZ smalloop;//jump if not zero
            STOSD;//сохранение eax в ячейке памяти по адресу esi:edi, после чего edi+4, если df=0, или edi-4, если df= 1
            LOOP Bigloop;//ecx=ecx-1, если ecx!=0,выполнить переход по метке outerloop,иначе следующие инструкции
        }
    }
};
int main()
{
    Assembler Assm;
    int mass[7] = { 6,4,5,3,2,7,1 };
    cout<<"Add 17+45=" << Assm.add(17, 45) << endl;
    cout << "Sub 52-30=" << Assm.substr(52, 30)<<endl;
    cout << "Mul 40*(-7)= " << Assm.multipl(40, -7) << endl;
    cout << "Div 50/(-5)" << Assm.divis(40, -5) << endl;
    cout << "Greater 4>5?: " << Assm.great(4, 5) << endl;
    cout << "Greater or Equal 19>=19? " << Assm.GreatOrEq(19, 19) << endl;
    cout << "Less 5<4?:" << Assm.Less(5, 4) << endl;
    cout << "Less or Equal 5<=7?: " << Assm.LessOrEq(5, 7) << endl;
    cout << "Not Logic not 1?: " << Assm.Not(1) << endl;
    cout << "Or Logic 1 or 0?: " << Assm.Or(1,0) << endl;
    cout << "And Logic 1 and 0?: " << Assm.And(1, 0) << endl;
    cout << "Xor Logic 1 xor 0?:" << Assm.Xor(1, 0) << endl;
    cout << "Value by index 3 in array { 6,4,5,3,2,7,1 }?: " << Assm.Index(mass, 3) << endl;
    cout << "Shear 8, 1 bit: "<< Assm.Shear(8,1)<<endl;
    cout << "ShearR 16, one bit>: " << Assm.ShearR(16, 1) << endl;
    cout << "ShearL 8, one bit<: " << Assm.ShearL(8, 1) << endl;
    cout << "Bouble sort for array { 6,4,5,3,2,7,1 }:"<<endl;
    Assm.BoubleSort(mass,7);
    for(int i = 0; i < 6; i++) 
    {
        cout << mass[i] << ",";
    }
    cout << mass[6];
}

