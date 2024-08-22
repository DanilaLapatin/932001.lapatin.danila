#include "errproc.h"
#include <iostream>
#include <sys/types.h>
#include <sys/socket.h>
#include <stdio.h>
#include <stdlib.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>

int Socket(int domain, int type, int protocol) {
	int res = socket(domain, type, protocol);
	if (res == -1) {
		perror("can't create socket");
		exit(EXIT_FAILURE);
	}
	std::cout << "server socket successfully created\n";
	return res;
}

void Bind(int sockfd, const struct sockaddr* addr, socklen_t addrlen) {
	int res = bind(sockfd, addr, addrlen);
	if (res == -1) {
		perror("bind failed");
		exit(EXIT_FAILURE);
	}
	std::cout << "socket successfully binded with the address\n";
}

int Listen(int sockfd, int backlog) {
	int res = listen(sockfd, backlog);
	if (res == -1) {
		perror("listen failed");
		exit(EXIT_FAILURE);
	}
	std::cout << "socket is listening for messages from ports\n";

	return 0;
}

int Accept(int sockfd, struct sockaddr* addr, socklen_t* addrlen) {
	int res = accept(sockfd, addr, addrlen);
	if (res == -1) {
		perror("accept failed");
		exit(EXIT_FAILURE);
	}
	std::cout << "a socket has been created for the first connection request in the queue\n";
	return res;
}

int Connect(int sockfd, struct sockaddr* addr, socklen_t addrlen) {
	int res = connect(sockfd, addr, addrlen);
	if (res == -1) {
		perror("accept failed");
		exit(EXIT_FAILURE);
	}
	std::cout << "a socket has been created for the first connection request in the queue\n";
	return res;
}

void Inet_pton(int af, const char* src, void* dst) {
	int res = inet_pton(af, src, dst);
	if (res == 0) {
		printf("inet_pton failed: src does not contain a character"
			" string representing a valid network address in the specified"
			" address family");
		exit(EXIT_FAILURE);
	}
	if (res == -1) {
		perror("inet_pton failed");
		exit(EXIT_FAILURE);
	}
}