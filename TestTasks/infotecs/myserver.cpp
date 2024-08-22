#include <iostream>
#include <sys/types.h>
#include <sys/socket.h>
#include <stdio.h>
#include <stdlib.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include "errproc.h"


int main() {
	int test = 1;
	int res_len;
	int client, server = Socket(AF_INET, SOCK_STREAM, 0);
	struct sockaddr_in addr = { 0 };
	socklen_t addrlen = sizeof(addr);
	addr.sin_family = AF_INET;
	addr.sin_port = htons(12345);
	//setsockopt(server, SOL_SOCKET, SO_REUSEADDR, &test, sizeof(int));
	Bind(server, (struct sockaddr*)&addr, sizeof(addr));
	ssize_t nread;
	int sum;
	Listen(server, 1);
	client = Accept(server, (struct sockaddr*)&addr, &addrlen);
	while (1) {
		
		res_len = recv(client, &sum, sizeof(int), 0);
		if (res_len == -1) {
			shutdown(client, 1);
			perror("recv failed");
			break;
		}
		if (res_len == 0) {
			shutdown(client, 1);
			std::cout << "END OF FILE occured" << std::endl;
			client = Accept(server, (struct sockaddr*)&addr, &addrlen);
			continue;
		}
		if (sum > 9 && sum % 32 == 0) {
			std::cout << "Server received data:\n\tdata: " << sum << "\n\tmessage length: " << res_len<<std::endl;
		}
		else std::cout << "Server error : invalid data" << std::endl;
	}
	close(client);
}