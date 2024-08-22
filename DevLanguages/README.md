В файле agregator.py содержатся класс-агрегатор новостей с сайтов
https://habr.com/ru/all,
https://tproger.ru/news,
https://stackoverflow.blog,
https://ichip.ru/novosti
и основная программа, написанные на языке Python.
Принцип работы объяснён в комментариях, на примере методов HabrAgregate() и HabrAgrNew().

Сначала имеющиеся на сайтах новостные статьи собираются в LIFO очередь методом put() и выводятся в основном потоке методом get(). 
Потом создаётся фоновый поток, который ищет новости на сайтах и, если находит, передаёт в очередь методом put(), из которой они выводятся в основном потоке методом get(). 

В файле TokenRing содержится консольное приложение, написаннае на языке Go(golang),эмулирующее работу протокоа передачи данных в локальной вычислительной сети TokenRing.
В комментариях описан принцип работы программы.
Основное:
В func main создаётся экземпляр структуры-сообщения Token, а так же массив channel для передачи ссылки на этот экземпляр Token. 
Потом в цикле с помощью go Sender(...) в легковесных потоках(горутинах) запускается функция Sender, выполняющая основные манипуляции с данными сообщения и обеспечивающая вывод.
