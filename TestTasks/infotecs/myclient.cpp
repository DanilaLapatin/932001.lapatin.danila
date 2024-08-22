#include <iostream>
#include <thread>
#include <sys/types.h>
#include <sys/socket.h>
#include <stdlib.h>
#include <stdio.h>
#include "errproc.h"
#include <thread>
#include <mutex>
#include <vector>
#include <unistd.h>
#include <arpa/inet.h>
#include <chrono>

using namespace std;


void BubbleSort(string& s) {
	cout << "BubbleSort begins\n";
	int j = 1;
	int sz = s.size();
	while (sz - j >= 1)	{
		for (int i = 0; i < sz - j;i++)	{
			if ((int)s[i] <(int)s[i + 1])	{
				auto h = s[i];
				s[i] = s[i + 1];
				s[i + 1] = h;
			}
		}
		j++;
	}
	cout << "BubbleSort done. Now data: "+s+"\n";
}
bool allDigits(string buf) {
	for (auto ch : buf)	{
		if ((int)ch < 48 || (int)ch>57)
			return 0;
	}
	return 1;
}
bool isDigit(char ch) {
	if ((int)ch < 48 || (int)ch>57)
		return 0;
	return 1;
}
class ThreadWork {
public:
	void processdata(string buf) {
		cout << "data before processing: " <<buf<<"\tdata size: "<<buf.size()<< std::endl;
		BubbleSort(buf);
		int sum;

		string b;
		for (int i = 0; i < buf.size();i++) {
			cout << i+"\n";
			if ((int)buf[i] % 2 == 0)
				b += "KB";
			else
				b += buf[i];
		}
		buffer.push_back(b);
		cout << "data after processing: " << b <<"\tdata size: " << b.size() << std::endl;
	}

	void reader() {
		cout << "First thread\n";
		string buf;
		while (1) {
			
			this->mtx.lock();
			cout << "mtx locked by 1 thread\n";
			cout << "input values: ";
			buf = "";
			cin >> buf;
			this->mtx.unlock();
			cout << "mtx unlocked by 1 thread\n";
			if (buf.size() <= 64 && allDigits(buf)) {
				cout << buf << " - valid data\n";
				this->mtx.lock();
				cout << "mtx locked by 1 thread\n";
				processdata(buf);
				this->mtx.unlock();
				cout << "mtx unlocked by 1 thread\n";
				std::this_thread::sleep_for(std::chrono::seconds(1));
			}
			else {
				cout << buf << " - invalid data\n";
				this->mtx.unlock();
			}
		}
	}
	void Sum(int client) {
		this->mtx.lock();
		cout << "mtx locked by 2 thread\n";
		cout << "Second thread\n";
		this->mtx.unlock();
		cout << "mtx unlocked by 2 thread\n";
		string b;
		int sum;
		while (1)
			while (buffer.size() != 0) {
				this->mtx.lock();//заблокировать мьютекс
				cout << "mtx locked by 2 thread\n";
				sum = 0;
				b = buffer.back();
				for (int i = 0; i < b.size();i++) {
					if (isDigit(b[i])) {
						cout << sum << " + " << (int)b[i] - (int)'0' << endl;
						sum += (int)b[i] - (int)'0';
					}
				}
				buffer.pop_back();
				send(client, &sum, sizeof(int), 0);
				std::cout << "client sent data: "<<sum<<endl;
				this->mtx.unlock();//разблокировать мьютекс
				cout << "mtx unlocked by 2 thread\n";

			}
	}	
	private:
		mutex mtx;
		vector <string> buffer;
		
};

int main()	{
	
	int client = Socket(AF_INET, SOCK_STREAM, 0);
	struct sockaddr_in addr = { 0 };
	socklen_t addrlen = sizeof(addr);
	addr.sin_family = AF_INET;
	addr.sin_port = htons(12345);
	Inet_pton(AF_INET, "127.0.0.1", &addr.sin_addr);
	Connect(client, (struct sockaddr *) &addr, sizeof(addr));
	ThreadWork ThrdWrk;
	int sum;
	/*while (1)
	{
		cout << "input values: ";
		cin >> sum;
		send(client, &sum, sizeof(int), 0);
	}*/
	
	thread rdr(&ThreadWork::reader,&ThrdWrk);
	thread prntr(&ThreadWork::Sum, &ThrdWrk, client);
	prntr.join();
	rdr.join();
	close(client);
	
}